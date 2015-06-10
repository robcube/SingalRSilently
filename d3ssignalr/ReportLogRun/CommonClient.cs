using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportLogRun
{
    public class CommonClient
    {
        string _url;
        IHubProxy _logHubProxy;
        HubConnection _hubConnection;

        public CommonClient(string url)
        {
            _url = url;
            _hubConnection = new HubConnection(url);
            _logHubProxy = _hubConnection.CreateHubProxy("LogHub");
        }

        public async Task AddLog(ReportLog reportLog)
        {
            await _hubConnection.Start().ContinueWith(task =>
            {
                if (task.IsFaulted)
                    Console.WriteLine("Hub not found at " + _url);
            });
            if (_hubConnection.State != ConnectionState.Disconnected)
                await _logHubProxy.Invoke<ReportLog>("SendLog", reportLog);
        }
    }
}
