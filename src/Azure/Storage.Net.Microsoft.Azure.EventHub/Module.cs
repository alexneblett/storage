using Storage.NetCore.Blobs;
using Storage.NetCore.ConnectionString;
using Storage.NetCore.Messaging;

namespace Storage.NetCore.Microsoft.Azure.EventHub
{
   class Module : IExternalModule, IConnectionFactory
   {
      public IConnectionFactory ConnectionFactory => this;

      public IBlobStorage CreateBlobStorage(StorageConnectionString connectionString) => null;

      public IMessenger CreateMessenger(StorageConnectionString connectionString)
      {
         if(connectionString.Prefix == KnownPrefix.AzureEventHub)
         {
            if(connectionString.IsNative)
            {
               return new AzureEventHubMessenger(connectionString.Native, null);
            }
         }

         return null;
      }
   }
}
