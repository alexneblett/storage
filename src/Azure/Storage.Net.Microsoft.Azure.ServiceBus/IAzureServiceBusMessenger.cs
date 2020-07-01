using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Storage.NetCore.Messaging;

namespace Storage.NetCore.Microsoft.Azure.ServiceBus
{
   /// <summary>
   /// Azure Service Bus specific information
   /// </summary>
   public interface IAzureServiceBusMessenger : IMessenger
   {
      /// <summary>
      /// 
      /// </summary>
      /// <param name="name"></param>
      /// <returns></returns>
      Task CreateQueueAsync(string name);
   }
}
