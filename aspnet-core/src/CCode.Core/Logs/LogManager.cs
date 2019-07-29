using Amayer.Common.Modules.FlashLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCode.Logs
{
    public class LogManager
    {
        static FlashLogger _lc流程;
        public static FlashLogger lc流程
        {
            get
            {
                if (_lc流程 == null)
                {
                    _lc流程 = new FlashLogger("流程");
                }
                return _lc流程;
            }
        }
        static FlashLogger _sql;
        public static FlashLogger SqlExcute
        {
            get
            {
                if (_sql == null)
                {
                    _sql = new FlashLogger("Sql");
                }
                return _sql;
            }
        }
    }
}
