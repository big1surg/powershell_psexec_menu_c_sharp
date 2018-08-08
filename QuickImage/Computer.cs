using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

//this will be a computer with host file and printer file
namespace QuickImage {
    class Computer{
        public string Name { get; set; }
        public int Id { get; set; }
        public string Addr { get; set; }
        public string PrinterDefault { get; set; }

        public Computer(){
            Name = "computerName";
        }

        //check to see if this printer exists
        public Boolean CheckIfExist(){
            bool ableToPing = false;
            Ping pinger = new Ping();
            try{
                PingReply reply = pinger.Send(Name);
                ableToPing = reply.Status == IPStatus.Success;
                Addr = getInteralIP();
            }catch (PingException){
            }
            return ableToPing;
        }

        public string getInteralIP()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(Name);
            IPAddress[] addr = hostEntry.AddressList;
            var ip = addr.Where(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                .FirstOrDefault();
            return ip.ToString();
        }
    }
}
