using SuperSocket.Facility.Protocol;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TCP_WG
{
    public class BinarySession : AppSession<BinarySession, BinaryRequestInfo>
    {
    }

    public class BinaryServer : AppServer<BinarySession, BinaryRequestInfo>
    {
        public BinaryServer(IReceiveFilterFactory<BinaryRequestInfo> protocol) : base(protocol)
        {
        }
    }

    public class BinaryReceiveFilter : IReceiveFilter<BinaryRequestInfo>
    {
        public int LeftBufferSize { get; set; }

        public IReceiveFilter<BinaryRequestInfo> NextReceiveFilter { get; set; }

        public FilterState State { get; set; }

        public BinaryRequestInfo Filter(byte[] readBuffer, int offset, int length, bool toBeCopied, out int rest)
        {
            byte[] value = new byte[length];
            Array.Copy(readBuffer, offset, value, 0, length);
            BinaryRequestInfo binaryRequestInfo = new BinaryRequestInfo("key", value);
            rest = length - value.Length;
            return binaryRequestInfo;
        }

        public void Reset()
        {
        }
    }

    public class BinaryReceiveFilterFactory : IReceiveFilterFactory<BinaryRequestInfo>
    {
        public IReceiveFilter<BinaryRequestInfo> CreateFilter(IAppServer appServer, IAppSession appSession, IPEndPoint remoteEndPoint)
        {
            BinaryReceiveFilter binaryReceiveFilter = new BinaryReceiveFilter();
            return binaryReceiveFilter;
        }
    }
}
