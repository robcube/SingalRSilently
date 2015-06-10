using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportLogRun
{
    class Program
    {
        public static System.Random _random = new System.Random();
        public static IList<string> _statuses = new List<string>();
        public static CommonClient _commonClient; 
  
        static void Main(string[] args)
        {
            _commonClient = new CommonClient("http://localhost:64686/");
            //_commonClient = new CommonClient("http://localhost:55999/");
            _statuses = new List<string> { "Bulldozed", "Carry a Towel", "Time is an illusion", "Fourty-Two", "Ask a glass of water", "Don't Panic" };

            // clear it out before each run
            using (var db = new ReportLogModel())
            {
                var logs = db.ReportLogs;
                db.ReportLogs.RemoveRange(logs);
                db.SaveChanges();
            }

            while (true)
            {
                int nextRandom = _random.Next(1, 10000);
                System.Threading.Thread.Sleep(nextRandom);

                WriteToLog();
               
                System.Console.WriteLine(nextRandom);
            }
        }

        private static void WriteToLog()
        {
            var reportLog = new ReportLog
            {
                Stamp = DateTime.Now,
                Status = GetRandomStatus()
            };

            using (var db = new ReportLogModel())
            {
                db.ReportLogs.Add(reportLog);
                db.SaveChanges();
            }
            System.Console.WriteLine("{0} {1}", reportLog.Status, reportLog.Stamp);

            // add code to broadcast to SignalR clients
            _commonClient.AddLog(reportLog).Wait();
        }

        private static string GetRandomStatus()
        {
            int nextRandom = _random.Next(1, _statuses.Count());
            return _statuses[nextRandom];
        }
    }
}
