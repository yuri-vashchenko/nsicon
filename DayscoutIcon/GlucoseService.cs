
namespace DayscoutIcon
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Reflection;
    using System.Text;
    using System.Timers;

    public enum AlarmBlgl { NO, LOW, HIGH, LOWERTHENNORMAL, HIGHERTHENNORMAL }

    class GlucoseService
    {
        private Timer timer;
        private string useragent;
        
        private FrmDisclaimer frmDisclaimer;

        public delegate void BloodglucoseNewValueHandler(decimal blglvalue, DateTime blglDatetime, string direction);
        public delegate void BloodglucoseAlarmHandler(AlarmBlgl alarm, decimal blglvalue, DateTime blglDatetime);
        public delegate void ServiceStatusChangeHandler(bool isError, string message);

        public BloodglucoseNewValueHandler OnNewBloodsugarValue;
        public BloodglucoseAlarmHandler OnBloodsugarAlarmChange;
        public ServiceStatusChangeHandler OnStatusChange;

        /// <summary>
        /// Creating a new instance of GlucoseService.
        /// </summary>
        /// <param name="trayicon"></param>
        public GlucoseService()
        {
            //this.trayicon = trayicon;
            this.useragent = this.GetUserAgent();
            this.timer = new System.Timers.Timer(DayscoutIcon.Properties.Settings.Default.updateInterval); // Interval in ms.
            this.timer.Elapsed += UpdateGlucoseValues;
            //this.trayicon.setTrayiconBloodGlucoseNeedupdate("No connection to Nightscout server made.");
            if (!DayscoutIcon.Properties.Settings.Default.disclaimerAgreed)
            {
                this.timer.Stop();
                this.frmDisclaimer = new FrmDisclaimer(this.timer);
                this.frmDisclaimer.Show();
            }
            else
            {
                this.timer.Start();
            }
        }

        /// <summary>
        /// Set the new interval time in miliseconds of the timer of that polls the Nightscout server.
        /// </summary>
        /// <param name="msInterval"></param>
        public void setInterval(double msInterval)
        {
            this.timer.Interval = msInterval;
        }

        /// <summary>
        /// Get the interval time in miliseconds from the timer that polls the Nightscout server.
        /// </summary>
        /// <returns></returns>
        public double getInterval()
        {
            return this.timer.Interval;
        }

        /// <summary>
        /// Update the glucose values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UpdateGlucoseValues(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(DayscoutIcon.Properties.Settings.Default.serverUrl))
            {
                OnStatusChange(true, "No Nightscout server url set-up.");
                return;
            }

            if (String.IsNullOrEmpty(DayscoutIcon.Properties.Settings.Default.apiSecretSha1))
            {
                OnStatusChange(true, "No Nightscout API_SECRET set-up.");
                return;
            }

            OnStatusChange(false, "");
            string strJsonResponse = this.DownloadNightscoutEntries();
            if (String.IsNullOrEmpty(strJsonResponse))
            {
                // Network issue no output at all. 
                OnStatusChange(true, "Network issue");
                return;
            }

            JArray jsonEntries = JArray.Parse(strJsonResponse);
            if (jsonEntries.Count < 1)
            {
                // No entries to parse found
                OnStatusChange(true, "Network issue: got no recent entries.");
                return;
            }

            string jsonFirstEntry = jsonEntries[0].ToString();
            JObject jsonObjEntry = JObject.Parse(jsonFirstEntry);
            if (!jsonObjEntry.ContainsKey("sgv"))
            {
                // No sensor value.
                if (jsonEntries.Count < 2)
                {
                    OnStatusChange(true, "Network issue: got no recent entries.");
                    return;
                }

                // Get next entry.
                jsonFirstEntry = jsonEntries[1].ToString();
                jsonObjEntry = JObject.Parse(jsonFirstEntry);
                if (!jsonObjEntry.ContainsKey("sgv"))
                {
                    OnStatusChange(true, "Network issue: got no recent sensor entries.");
                    return;
                }
            }

            
            //Console.WriteLine("{0}", jsonObjEntry.ToString());
            decimal blglvalue = new Decimal((int)jsonObjEntry["sgv"]);
            if (DayscoutIcon.Properties.Settings.Default.bloodsugerUnitsIndex == 1)
            {
                Decimal mgdlMmolConversionRate = new Decimal(0.0555);
                blglvalue = Decimal.Multiply(blglvalue, mgdlMmolConversionRate);
            }

            //string datetimevalue = "";
            DateTime blglDatetime = new DateTime();
            if (jsonObjEntry.ContainsKey("sysTime"))
            {
                string sysTime = (string)jsonObjEntry["sysTime"];
                blglDatetime = DateTime.Parse(sysTime, new CultureInfo("us-en", false));
                // Display date and time as ISO 8601 without seconds (yyyy-mm-dd hh:mm)
                //datetimevalue = "\r\n" + string.Format("{0:D}-{1:D2}-{2:D2} {3:D2}:{4:D2}", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute);
            }

            string direction = "";
            if (jsonObjEntry.ContainsKey("direction"))
            {
                direction += (string)jsonObjEntry["direction"];
            }

            OnNewBloodsugarValue(blglvalue, blglDatetime, direction);
            decimal blglLow = DayscoutIcon.Properties.Settings.Default.alarmBlglLow;
            decimal blglLowerThenNormal = DayscoutIcon.Properties.Settings.Default.alarmBlglLower;
            decimal blglHigherThenNormal = DayscoutIcon.Properties.Settings.Default.alarmBlglHigher;
            decimal blglHigh = DayscoutIcon.Properties.Settings.Default.alarmBlglHigh;
            if (blglvalue.CompareTo(blglLow) < 0)
            {
                // Hypoglycemia alarm, show red flag
                OnBloodsugarAlarmChange(AlarmBlgl.LOW, blglvalue, blglDatetime);
            }
            else if (blglvalue.CompareTo(blglHigh) >= 0)
            {
                // Hyperglycemia alarm, show orange flag
                OnBloodsugarAlarmChange(AlarmBlgl.HIGH, blglvalue, blglDatetime);
            }
            else if (blglvalue.CompareTo(blglLowerThenNormal) < 0)
            {
                // becoming Hypoglycemia warning, yellow flag
                OnBloodsugarAlarmChange(AlarmBlgl.LOWERTHENNORMAL, blglvalue, blglDatetime);
            }
            else if (blglvalue.CompareTo(blglHigherThenNormal) > 0)
            {
                // becoming Hyperglycemia warning, yellow flag
                OnBloodsugarAlarmChange(AlarmBlgl.HIGHERTHENNORMAL, blglvalue, blglDatetime);
            }
            else
            {
                OnBloodsugarAlarmChange(AlarmBlgl.NO, blglvalue, blglDatetime);
            }
        }

        /// <summary>
        /// Download the lastest Nightscout entries in json.
        /// </summary>
        /// <returns>The entries in json as a string.</returns>
        private string DownloadNightscoutEntries()
        {
            //System.Net.ServicePointManager.Expect100Continue = false;
            System.Net.ServicePointManager.EnableDnsRoundRobin = true;
            System.Net.ServicePointManager.DnsRefreshTimeout = DayscoutIcon.Properties.Settings.Default.durationDNSCache;
            System.Net.ServicePointManager.DefaultConnectionLimit = 2;
            long milisecondsSinceEpoch = this.GetMsSinceEpochMinsGlucoseValidDuration();
            string urlEntries = DayscoutIcon.Properties.Settings.Default.serverUrl + "/api/v1/entries.json?count=2&find[date][$gte]=" + milisecondsSinceEpoch.ToString();
            HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(urlEntries);
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            System.Net.ServicePointManager.CheckCertificateRevocationList = true;
            request.Method = "GET";
            request.ContentType = "application/json";
            request.ProtocolVersion = HttpVersion.Version11;
            request.UserAgent = this.useragent;
            request.AllowAutoRedirect = true;
            request.Timeout = DayscoutIcon.Properties.Settings.Default.networkTimeout;
            request.Proxy = null;
            // Authentication
            request.Headers["API-SECRET"] = DayscoutIcon.Properties.Settings.Default.apiSecretSha1.ToLowerInvariant();
            WebResponse webresponse = null;
            string response = null;
            try
            {
                webresponse = request.GetResponse();
                using (BufferedStream bufferedstream = new BufferedStream(webresponse.GetResponseStream()))
                {
                    using (StreamReader streamreader = new StreamReader(bufferedstream, System.Text.Encoding.UTF8))
                    {
                        response = streamreader.ReadToEnd();
                    }
                }
            }
            catch (WebException webexc)
            {
                OnStatusChange(true, webexc.Message);
            }
            finally
            {
                if (webresponse != null)
                {
                    webresponse.Close();
                }
            }

            return response;
        }

        /// <summary>
        /// Get the user-agent string for this application for the http request.
        /// </summary>
        /// <returns></returns>
        private string GetUserAgent()
        {
            StringBuilder sbUserAgent = new StringBuilder(Assembly.GetExecutingAssembly().GetName().Name);
            sbUserAgent.Append(" ");
            sbUserAgent.Append(Assembly.GetExecutingAssembly().GetName().Version.Major.ToString());
            sbUserAgent.Append(".");
            sbUserAgent.Append(Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString());
            sbUserAgent.Append(".");
            sbUserAgent.Append(Assembly.GetExecutingAssembly().GetName().Version.Build.ToString());
            return sbUserAgent.ToString();
        }

        /// <summary>
        /// Get the number of miliseconds since epoch minus secondsGlucoseValueValid value in miliseconds.
        /// </summary>
        /// <returns></returns>
        private long GetMsSinceEpochMinsGlucoseValidDuration()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            // Accuracy of t.TotalSeconds lost to whole seconds by casting to long.
            long secondsEpochWGlucoseValid = (long)Math.Round(t.TotalSeconds, 0, MidpointRounding.AwayFromZero) - DayscoutIcon.Properties.Settings.Default.secondsGlucoseValueValid;
            long milisecondsEpochWGlucoseValid = secondsEpochWGlucoseValid * 1000;
            return milisecondsEpochWGlucoseValid;
        }
    }
}
