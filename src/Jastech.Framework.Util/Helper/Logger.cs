﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Reflection.Emit;

namespace Jastech.Framework.Util.Helper
{
    public static class Logger
    {
        #region 필드
        private static string _logDir = "";

        private readonly static object _objLock = new object();
        #endregion

        #region 메서드
        public static void Initialize(string filePath = "")
        {
            if (filePath == "")
                _logDir = Path.Combine(Directory.GetCurrentDirectory(), "Log");
            else
                _logDir = filePath;

            if (!Directory.Exists(_logDir))
                Directory.CreateDirectory(_logDir);
        }

        public static void Write(LogType logType, string logMessage)
        {
            string logpath = GetLogPath(logType);
            string strDir = logpath.Substring(0, logpath.LastIndexOf('\\'));
            string time = GetTimeString(DateTime.Now);
            string message = "[" + time + "] " + "[" + logType.ToString() + "] " + logMessage;
            message = message.Replace("\r\n", "");

            if (!Directory.Exists(strDir))
                Directory.CreateDirectory(strDir);

            lock (_objLock)
            {
                StreamWriter log = new StreamWriter(logpath, true);
                using (log)
                {
                    log.WriteLine(message);
                }
            }
        }

        public static void Write(LogType logType, string[] logMessages)
        {
            string logpath = GetLogPath(logType);
            string strDir = logpath.Substring(0, logpath.LastIndexOf('\\'));

            if (!Directory.Exists(strDir))
                Directory.CreateDirectory(strDir);

            lock (_objLock)
            {
                StreamWriter log = new StreamWriter(logpath, true);
                using (log)
                {
                    for (int index = 0; index < logMessages.Length; index++)
                    {
                        string message = logMessages[index];
                        message = message.Replace("\r\n", "");

                        log.WriteLine(message);
                    }
                }
            }
        }

        public static void Write(LogType logType, string logMessage, DateTime tm)
        {
            string logpath = GetLogPath(logType);
            string strDir = logpath.Substring(0, logpath.LastIndexOf('\\'));
            string time = GetTimeString(tm);
            string message = "[" + time + "] " + logMessage;
            message = message.Replace("\r\n", "");

            if (!Directory.Exists(strDir))
                Directory.CreateDirectory(strDir);

            lock (_objLock)
            {
                StreamWriter log = new StreamWriter(logpath, true);
                using (log)
                {
                    log.WriteLine(message);
                }
            }
        }

        public static void Debug(LogType logType, string logMessage)
        {
            string logpath = GetDebugPath();
            string strDir = logpath.Substring(0, logpath.LastIndexOf('\\'));

            if (!Directory.Exists(strDir))
                Directory.CreateDirectory(strDir);

            string time = GetTimeString(DateTime.Now);
            string message = "[" + time + "] " + "[" + logType.ToString() + "] " + logMessage;
            message = message.Replace("\r\n", "");

            lock (_objLock)
            {
                StreamWriter log = new StreamWriter(logpath, true);
                using (log)
                {
                    log.WriteLine(message);
                }
            }
        }

        public static void Debug(LogType logType, string logMessage, DateTime dateTime)
        {
            string logpath = GetDebugPath();
            string strDir = logpath.Substring(0, logpath.LastIndexOf('\\'));

            if (!Directory.Exists(strDir))
                Directory.CreateDirectory(strDir);

            string time = GetTimeString(dateTime);
            string message = "[" + time + "] " + "[" + logType.ToString() + "] " + logMessage;
            message = message.Replace("\r\n", "");

            lock (_objLock)
            {
                StreamWriter log = new StreamWriter(logpath, true);
                using (log)
                {
                    log.WriteLine(message);
                }
            }
        }

        private static string GetDebugPath()
        {
            string logPath = string.Format(@"{0}\{1}\log_{2:0000}{3:00}{4:00}_" + "Debug.log", _logDir, DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            return logPath;
        }

        private static string GetLogPath(LogType logType)
        {
            string logPath = string.Format(@"{0}\{1}\log_{2:0000}{3:00}{4:00}_" + logType.ToString() + ".log", _logDir, DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            return logPath;
        }

        private static string GetErrorLogPath(ErrorType logType)
        {
            string logPath = string.Format(@"{0}\{1}\log_{2:0000}{3:00}{4:00}_" + "Error" + ".log", _logDir, DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            return logPath;
        }

        public static void Error(ErrorType logType, string logMessage)
        {
            string logpath = GetErrorLogPath(logType);
            string strDir = logpath.Substring(0, logpath.LastIndexOf('\\'));

            if (!Directory.Exists(strDir))
                Directory.CreateDirectory(strDir);

            string time = GetTimeString(DateTime.Now);
            string message = "[" + time + "] " + "[" + logType.ToString() + "] " + logMessage;
            message = message.Replace("\r\n", "");

            lock (_objLock)
            {
                StreamWriter log = new StreamWriter(logpath, true);
                using (log)
                {
                    log.WriteLine(message);
                }
            }
        }

        public static void Error(ErrorType logType, string logMessage, DateTime dateTime)
        {
            string logpath = GetErrorLogPath(logType);
            string strDir = logpath.Substring(0, logpath.LastIndexOf('\\'));

            if (!Directory.Exists(strDir))
                Directory.CreateDirectory(strDir);

            string time = GetTimeString(dateTime);
            string message = "[" + time + "] " +"[" +logType.ToString()+"] "  + logMessage;
            message = message.Replace("\r\n", "");

            lock (_objLock)
            {
                StreamWriter log = new StreamWriter(logpath, true);
                using (log)
                {
                    log.WriteLine(message);
                }
            }
        }

        public static void WriteException(LogType logType, Exception exception, DateTime tm)
        {
            string logpath = GetLogPath(logType);
            string strDir = logpath.Substring(0, logpath.LastIndexOf('\\'));
            string time = GetTimeString(tm);
            string message = "[" + time + "] " + exception.StackTrace + " : " + exception.Message;
            message = message.Replace("\r\n", "");

            if (!Directory.Exists(strDir))
                Directory.CreateDirectory(strDir);

            lock (_objLock)
            {
                StreamWriter log = new StreamWriter(logpath, true);
                using (log)
                {
                    log.WriteLine(message);
                }
            }
        }

        public static string GetTimeString(DateTime tm)
        {
            string strTime = string.Format(@"{0:00}{1:00} {2:00}:{3:00}:{4:00}.{5:000}ms",
               tm.Month, tm.Day, tm.Hour, tm.Minute, tm.Second, tm.Millisecond);

            //DateTime now = DateTime.Now;
            //string strTime = string.Format(@"{0:00}{1:00} {2:00}:{3:00}:{4:00} / {5:00}:{6:00}:{7:00}.{8:000}ms",
            //    tm.Month, tm.Day, tm.Hour, tm.Minute, tm.Second, now.Hour, now.Minute, now.Second, now.Millisecond);
            return strTime;
        }
        #endregion
    }

    public static class ParamTrackingLogger
    {
        private static readonly List<string> _paramChangedLogMessages = new List<string>();

        public static bool IsEmpty => _paramChangedLogMessages.Count == 0;

        public static void AddLog(string message)
        {
            string fullMessage = $"[{Logger.GetTimeString(DateTime.Now)}] {message}";
            _paramChangedLogMessages?.Add(fullMessage);
        }

        public static void WriteLogToFile()
        {
            string[] messages = _paramChangedLogMessages?.ToArray();
            if (messages != null)
                Logger.Write(LogType.Parameter, messages);

            ClearChangedLog();
        }

        public static void AddChangeHistory<T>(string component, string parameter, T oldValue, T newValue)
        {
            AddLog($"{component} {parameter} value changed. {oldValue} -> {newValue}");
        }

        public static void ClearChangedLog() => _paramChangedLogMessages?.Clear();
    }

    public enum LogType
    {
        System,
        Device,
        Comm,
        Inspection,
        Imaging,
        Seq,
        Error,
        Parameter,
        GUI,
    }

    public enum ErrorType
    {
        Motion,
        Grabber,
        Camera,
        PLC,
        LightCtrl,
        SEQ,
        Inspection,
        Etc,
        Comm,
        Macron,
        Apps,
    }
}
