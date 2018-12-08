using System;
using System.Text;

namespace DayscoutIcon
{
    class ConsoleBloodglucose
    {
        private const string BLGLUNITMMOL = "mmol/l";
        private const string BLGLUNITMGDL = "mg/dl";

        public ConsoleBloodglucose()
        {
            // Assign events
            Program.glucoseService.OnNewBloodsugarValue += new GlucoseService.BloodglucoseNewValueHandler(this.PrintBloodGlucoseDetails);
            Program.glucoseService.OnBloodsugarAlarmChange += new GlucoseService.BloodglucoseAlarmHandler(this.PrintBloodGlucoseAlarm);
            //Console.Title = "Bloodglucose console";
        }

        /// <summary>
        /// Print blood glucose details on console.
        /// </summary>
        /// <param name="bloodglucoseValue"></param>
        /// <param name="dt"></param>
        /// <param name="direction"></param>
        private void PrintBloodGlucoseDetails(decimal bloodglucoseValue, DateTime dt, string direction)
        {
            Console.Write("On ");
            Console.Write(dt.ToShortDateString());
            Console.Write(" ");
            Console.Write(dt.ToLongTimeString());
            Console.Write(" value of ");
            Console.WriteLine(getStrRoundedBlglWithUnit(bloodglucoseValue));
        }

        /// <summary>
        /// Print bloodglucose alarm(s).
        /// </summary>
        /// <param name="alarm"></param>
        /// <param name="bloodglucoseValue"></param>
        /// <param name="dt"></param>
        private void PrintBloodGlucoseAlarm(AlarmBlgl alarm, decimal bloodglucoseValue, DateTime dt)
        {
            if (alarm == AlarmBlgl.NO)
            {
                return;
            }

            Console.Write("ALARM on ");
            Console.Write(dt.ToShortDateString());
            Console.Write(" ");
            Console.Write(dt.ToLongTimeString());
            Console.Write(" ");
            switch (alarm)
            {
                case AlarmBlgl.LOW:
                    Console.WriteLine(" LOW BLOODGLUCOSE! ");
                    Console.Beep();
                    Console.Beep();
                    break;
                case AlarmBlgl.HIGH:
                    Console.WriteLine(" HIGH BLOODGLUCOSE! ");
                    Console.Beep();
                    break;
                case AlarmBlgl.LOWERTHENNORMAL:
                    Console.WriteLine(" lower then normal bloodglucose. ");
                    break;
                case AlarmBlgl.HIGHERTHENNORMAL:
                    Console.WriteLine(" higher then normal bloodglucose. ");
                    break;
            }
        }

        /// <summary>
        /// Round bloodglucose value as string with for displaying with bloodglucose unit.
        /// </summary>
        /// <param name="blglValue"></param>
        /// <returns>The blood glucose value rounded.</returns>
        private string getStrRoundedBlglWithUnit(decimal blglValue)
        {
            int numDecimals = DayscoutIcon.Properties.Settings.Default.displayMmolDecimalsRouding;
            StringBuilder sbRoundedBlglWithUnit = new StringBuilder(Math.Round(blglValue, numDecimals, MidpointRounding.AwayFromZero).ToString());
            sbRoundedBlglWithUnit.Append(" ");
            if (DayscoutIcon.Properties.Settings.Default.bloodsugerUnitsIndex == 1)
            {
                sbRoundedBlglWithUnit.AppendLine(BLGLUNITMMOL);
            }
            else
            {
                sbRoundedBlglWithUnit.AppendLine(BLGLUNITMGDL);
            }

            return sbRoundedBlglWithUnit.ToString();
        }
    }
}
