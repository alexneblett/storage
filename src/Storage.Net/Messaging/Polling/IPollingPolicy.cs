using System;

namespace Storage.NetCore.Messaging.Polling
{
   interface IPollingPolicy
   {
      void Reset();

      TimeSpan GetNextDelay();
   }
}
