using ServerCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server   
{
    class ClientSession : PacketSession // 실제로 각 상황에서 사용될 기능 구현     // Client에 앉혀둘 대리인
    {                                         
        public int Sessionid { get; set; }

        public override void OnConnected(EndPoint endPoint)
        {
            Console.WriteLine($"Client Session ({this.Sessionid}) OnConnected : {endPoint}");

        }
        
        public override void OnReceivePacket(ArraySegment<byte> buffer)
        {
            PacketManager.Instance.OnRecvPacket(this, buffer);
            //Console.WriteLine("ClentSession received Packet");
            // 싱글톤으로 구현해둔 PacketManager에 연결
        }

        public override void OnDisConnected(EndPoint endPoint)
        {
            SessionManager.instance.Remove(this);
            Console.WriteLine($"OnDisConnected ({this.Sessionid}) : {endPoint}");
        }

        public override void OnSend(int numOfbytes)
        {
            //  Console.WriteLine($"Transferred args byte : {numOfbytes}");
        }
    }
}
