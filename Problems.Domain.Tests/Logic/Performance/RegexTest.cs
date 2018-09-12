﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Performance
{
    [TestClass]
    public class RegexTest
    {
        [TestMethod]
        public void GetAndParseLogRecords_Test()
        {
            // Act:
            var logRecords = GetAndParseLogRecords().ToArray();

            // Assert:
            Assert.AreEqual(5, logRecords.Length);
            Assert.AreEqual(LogLevel.INFO, logRecords[0].Level);
            Assert.AreEqual("test message 2", logRecords[1].JoinMessageRows());
            Assert.AreEqual(4, logRecords[3].MessageRows.Count);
        }

        // a first log record line can start from "Header-Footer", so "^" is commented
        // in order to match in this case
        private static readonly Regex _regex = new Regex(//@"^" +
            @"(?<Created>\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}[.,\,]\d{3}) " +
            @"\[(?<Thread>\d+)\] " +
            @"(?<Level>FATAL|ERROR|WARN|INFO |DEBUG) " +
            @"(?<AppenderName>LogFileAppender|SmtpAppender|<ADD OTHER APPENDER NAMES HERE>) " +
            @"(?<Message>.*)$");

        private const string _logText = @"
[Header]\r\n[Footer]\r\n[Header]\r\n[Footer]\r\n[Header]\r\n2018-07-26 07:33:57,072 [11] INFO  LogFileAppender test message 1
2018-07-26 07:33:57,135 [11] DEBUG LogFileAppender test message 2
2018-07-26 07:34:33,178 [40] ERROR LogFileAppender test message 3
2018-07-26 08:21:04,162 [6] DEBUG LogFileAppender  test message 4.1
test message 4.2
test message 4.3
test message 4.4
2018-07-26 11:52:02,131 [26] INFO  LogFileAppender test message 5
[Footer]\r\n
";

        private static StreamReader CreateTestStreamReader()
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(_logText);
            MemoryStream stream = new MemoryStream(byteArray);
            var bufferSize = 1024 * 1024;
            return new StreamReader(stream, Encoding.UTF8, true, bufferSize);
        }

        private static IEnumerable<LogRecordModel> GetAndParseLogRecords()
        {
            // TODO: consider Header-Footer in the first line of a log file
            using (var sr = CreateTestStreamReader())
            {
                var record = CreateFirstLogRecord(sr);
                if (record == null)
                {
                    yield break;
                }

                string line;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    var match = _regex.Match(line);

                    if (match.Success)
                    {
                        // new log record start, thus:
                        // yield previous record ...
                        yield return record;
                        // ... and create a new one
                        record = CreateLogRecord(match);
                    }
                    else
                    {
                        // not a log record start,
                        // thus, a part of the current record's message
                        record.MessageRows.Add(line);
                    }
                }
                yield return record;
            }
        }

        private static LogRecordModel CreateFirstLogRecord(
            StreamReader sr)
        {
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var match = _regex.Match(line);

                if (match.Success)
                {
                    return CreateLogRecord(match);
                }
            }

            return null;
        }

        private static void ForEachLine(
            StreamReader sr, Func<string, Match, bool> onMatch, Action<string> onNoMatch)
        {
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var match = _regex.Match(line);

                if (match.Success)
                {
                    var stop = onMatch(line, match);
                    if (stop)
                    {
                        return;
                    }
                }
                else
                {
                    onNoMatch(line);
                }
            }
        }

        private static LogRecordModel CreateLogRecord(Match match)
        {
            var record = new LogRecordModel();

            record.Created = ParseDateTime(match.Groups[nameof(record.Created)].Value);
            record.Thread = int.Parse(match.Groups[nameof(record.Thread)].Value);
            record.Level = Enum.TryParse(match.Groups[nameof(record.Level)].Value, out LogLevel level) ? level : 0;
            record.AppenderName = match.Groups[nameof(record.AppenderName)].Value;
            record.MessageRows.Add(match.Groups["Message"].Value);

            return record;
        }

        private static readonly string[] _formats =
            new[] { "yyyy-MM-dd HH:mm:ss.fff", "yyyy-MM-dd HH:mm:ss,fff" };
        
        private static DateTime ParseDateTime(string dateTimeString) =>
            DateTime.TryParseExact(dateTimeString, _formats, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime dateTime) ? dateTime : DateTime.MinValue;

        private class LogRecordModel
        {
            public DateTime Created { get; set; }
            public int Thread { get; set; }
            public LogLevel Level { get; set; }
            public string AppenderName { get; set; }
            public List<string> MessageRows { get; set; } = new List<string>();

            public string JoinMessageRows() => string.Join(Environment.NewLine, MessageRows);
        }

        private enum LogLevel
        {
            FATAL,
            ERROR,
            WARN,
            INFO,
            DEBUG
        }
    }
}
