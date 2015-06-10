using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace d3poll
{
    public class CommonClient
    {
        
        public CommonClient ()
	{
        _url = url;
        _hubConnection = new HubConnection(url);
        _logHubProxy = _hubConnection.CreateHubProxy("LogHub");
	}
}

    
    }
     