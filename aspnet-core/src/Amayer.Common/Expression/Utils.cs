using System;
using System.Collections.Generic;
using System.Text;

namespace Amayer.Common
{
   public  class Utils
    {

        /// <summary>
        /// 时间戳转换为日期（时间戳单位秒）
        /// </summary>
        /// <param name="TimeStamp"></param>
        /// <returns></returns>
        public static DateTime ConvertToDateTime(long timeStamp)
        {
            var dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            TimeSpan toNow = new TimeSpan(timeStamp);
            return dtStart.Add(toNow);
            //var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            //return start.AddMilliseconds(timeStamp).AddHours(8);
        }
        /// <summary>
        /// 日期转换为时间戳（时间戳单位秒）
        /// </summary>
        /// <param name="TimeStamp"></param>
        /// <returns></returns>
        public static long ConvertToTimeStamp(DateTime time)
        {
            DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(time.AddHours(-8) - Jan1st1970).TotalMilliseconds;
        }

        /// <summary>
        /// 生成唯一数
        /// </summary>
        public class UniqueData
        {
            private static object obj = new object();
            private static int _sn = 0;
            public static string Gener()
            {
                lock (obj)
                {
                    if (_sn == int.MaxValue)
                    {
                        _sn = 0;
                    }
                    else
                    {
                        _sn++;
                    }
                    //Thread.Sleep(100);
                    return DateTime.Now.ToString("yyyyMMdd") + _sn.ToString().PadLeft(5, '0');
                }
            }
        }
    }
}
