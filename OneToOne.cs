using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MyHub
{
    public class OneToOne : PersistentConnection
    {
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            
            return Connection.Broadcast(connectionId+"****"+ request.QueryString["userName"]);
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            int i = data.LastIndexOf("<<<<");
            string conId = data.Substring(i+4, data.Length -  (i+4));
           // Connection.Send()
            return Connection.Send(conId, data);
        }

     
    }
}