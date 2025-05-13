using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{
    
    public class GrowthChartBLL
    {
        public static List<WfABoysZScores> GetWfABoysZScores()
        {
            var wfaBoysscores = new List<WfABoysZScores>();

            wfaBoysscores.Add(new WfABoysZScores() { MonthName = "0", SD0 = 3.3M, SD1 = 3.9M, SD2 = 4.4M, SD3 = 5M, SD1Neg = 2.9M, SD2Neg = 2.5M, SD3Neg = 2.1M });
            wfaBoysscores.Add(new WfABoysZScores() { MonthName = "6", SD0 = 7.9M, SD1 = 8.8M, SD2 = 9.8M, SD3 = 10.9M, SD1Neg = 7.1M, SD2Neg = 6.4M, SD3Neg = 5.7M });
            wfaBoysscores.Add(new WfABoysZScores() { MonthName = "12", SD0 = 9.6M, SD1 = 10.8M, SD2 = 12M, SD3 = 13.3M, SD1Neg = 8.6M, SD2Neg = 7.7M, SD3Neg = 6.9M });
            wfaBoysscores.Add(new WfABoysZScores() { MonthName = "18", SD0 = 10.9M, SD1 = 12.2M, SD2 = 13.7M, SD3 = 15.3M, SD1Neg = 9.8M, SD2Neg = 8.8M, SD3Neg = 7.8M });
            wfaBoysscores.Add(new WfABoysZScores() { MonthName = "24", SD0 = 12.2M, SD1 = 13.6M, SD2 = 15.3M, SD3 = 17.1M, SD1Neg = 10.8M, SD2Neg = 9.7M, SD3Neg = 8.6M });
            wfaBoysscores.Add(new WfABoysZScores() { MonthName = "30", SD0 = 13.3M, SD1 = 15M, SD2 = 16.9M, SD3 = 19M, SD1Neg = 11.8M, SD2Neg = 10.5M, SD3Neg = 9.4M });
            wfaBoysscores.Add(new WfABoysZScores() { MonthName = "36", SD0 = 14.3M, SD1 = 16.2M, SD2 = 18.3M, SD3 = 20.7M, SD1Neg = 12.7M, SD2Neg = 11.3M, SD3Neg = 10M });
            wfaBoysscores.Add(new WfABoysZScores() { MonthName = "42", SD0 = 15.3M, SD1 = 17.4M, SD2 = 19.7M, SD3 = 22.4M, SD1Neg = 13.6M, SD2Neg = 12M, SD3Neg = 10.6M });
            wfaBoysscores.Add(new WfABoysZScores() { MonthName = "48", SD0 = 16.3M, SD1 = 18.6M, SD2 = 21.2M, SD3 = 24.2M, SD1Neg = 14.4M, SD2Neg = 12.7M, SD3Neg = 11.2M });
            wfaBoysscores.Add(new WfABoysZScores() { MonthName = "54", SD0 = 17.3M, SD1 = 19.8M, SD2 = 22.7M, SD3 = 26M, SD1Neg = 15.2M, SD2Neg = 13.4M, SD3Neg = 11.8M });
            wfaBoysscores.Add(new WfABoysZScores() { MonthName = "60", SD0 = 18.3M, SD1 = 21M, SD2 = 24.2M, SD3 = 27.9M, SD1Neg = 16M, SD2Neg = 14.1M, SD3Neg = 12.4M });

            return wfaBoysscores;

        }

       
    }
}