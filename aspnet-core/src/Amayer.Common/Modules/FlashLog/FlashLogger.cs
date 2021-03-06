﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Amayer.Common.Modules.FlashLog
{
    public class FlashLogger
    {
        string Service { get; set; }
        public FlashLogger(string service = null)
        {
            this.Service = service;
        }
        void EnqueueMessage(string message, FlashLogLevel level, Exception ex = null, string service = null)
        {
            LogQueue.Instance.EnqueueMessage(new FlashLogMessage
            {
                Message = message,
                Level = level,
                Exception = ex,
                Service = service
            });
        }
        public void Debug(string msg, Exception ex = null)
        {
            EnqueueMessage(msg, FlashLogLevel.Debug, ex, Service);
        }
        public void Error(string msg, Exception ex = null)
        {
            EnqueueMessage(msg, FlashLogLevel.Error, ex, Service);
        }
        public void Fatal(string msg, Exception ex = null)
        {
            EnqueueMessage(msg, FlashLogLevel.Fatal, ex, Service);
        }
        public void Info(string msg, Exception ex = null)
        {
            EnqueueMessage(msg, FlashLogLevel.Info, ex, Service);
        }
        public void Warn(string msg, Exception ex = null)
        {
            EnqueueMessage(msg, FlashLogLevel.Warn, ex, Service);
        }
    }
    public sealed class LogQueue
    {
        /// <summary>
        /// 记录消息Queue
        /// </summary>
        private readonly ConcurrentQueue<FlashLogMessage> _que;
        /// <summary>
        /// 信号
        /// </summary>
        private readonly ManualResetEvent _mre;
        /// <summary>
        /// 日志
        /// </summary>
        private static LogQueue _logQueue;
        private FlashLogWrite _log;
        //StartupPath
        private LogQueue()
        {
            _que = new ConcurrentQueue<FlashLogMessage>();
            _mre = new ManualResetEvent(false);
            _log = new FlashLogWrite();
            Register();
        }
        readonly static object locker = new object();
        /// <summary>
        /// 实现单例
        /// </summary>
        /// <returns></returns>
        public static LogQueue Instance
        {
            get
            {
                if (_logQueue == null)
                {
                    lock (locker)
                    {
                        if (_logQueue == null)
                        {
                            _logQueue = new LogQueue();
                        }
                    }
                }
                return _logQueue;
            }
        }
        /// <summary>
        /// 另一个线程记录日志，只在程序初始化时调用一次
        /// </summary>
        public void Register()
        {
            Thread t = new Thread(new ThreadStart(WriteLog));
            t.IsBackground = true;
            t.Start();
        }
        /// <summary>
        /// 从队列中写日志至磁盘
        /// </summary>
        private void WriteLog()
        {
            while (true)
            {
                // 等待信号通知
                _mre.WaitOne();
                FlashLogMessage msg;
                // 判断是否有内容需要如磁盘 从列队中获取内容，并删除列队中的内容
                while (_que.Count > 0 && _que.TryDequeue(out msg))
                {
                    // 判断日志等级，然后写日志
                    _log.Write(msg);
                }
                // 重新设置信号
                _mre.Reset();
            }
        }
        /// <summary>
        /// 日志入队
        /// </summary>
        /// <param name="message">日志文本</param>
        /// <param name="level">等级</param>
        /// <param name="ex">Exception</param>
        public void EnqueueMessage(FlashLogMessage flashLogMessage)
        {
            _que.Enqueue(flashLogMessage);
            // 通知线程往磁盘中写日志
            _mre.Set();
        }
    }
}
