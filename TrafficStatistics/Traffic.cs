﻿using System;
using System.Threading;

namespace TrafficStatistics
{
    public class Traffic
    {
        public long inbound = 0;
        public long outbound = 0;

        public Traffic() { }

        public Traffic(Traffic t)
        {
            inbound = t.inbound;
            outbound = t.outbound;
        }

        public Traffic(Traffic t1, Traffic t2)
        {
            inbound = t1.inbound - t2.inbound;
            outbound = t1.outbound - t2.outbound;
        }

        public void onInbound(long n)
        {
            Interlocked.Add(ref inbound, n);
        }

        public void onOutbound(long n)
        {
            Interlocked.Add(ref outbound, n);
        }

        public void reset()
        {
            Interlocked.Exchange(ref inbound, 0);
            Interlocked.Exchange(ref outbound, 0);
        }
    }

    public class TrafficLog
    {
        public Traffic raw;
        public Traffic rawSpeed;

        public TrafficLog()
        {
            raw = new Traffic();
            rawSpeed = new Traffic();
        }

        public TrafficLog(Traffic raw, Traffic rawspeed)
        {
            this.raw = raw;
            this.rawSpeed = rawspeed;
        }
    }

}
