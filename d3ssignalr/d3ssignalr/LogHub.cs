using d3ssignalr.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace d3ssignalr
{
    public class LogHub : Hub
    {
        public void SendLog(ReportLog log)
        {
            Clients.All.addLog(log);
        }
    }
}