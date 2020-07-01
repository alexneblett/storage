using Storage.NetCore.Blobs;
using Storage.NetCore.ConnectionString;
using Storage.NetCore.Messaging;

namespace Storage.NetCore.Microsoft.Azure.Queues
{
   class Module : IExternalModule, IConnectionFactory
   {
      public IConnectionFactory ConnectionFactory => this;

      public IBlobStorage CreateBlobStorage(StorageConnectionString connectionString) => null;

      public IMessenger CreateMessenger(StorageConnectionString connectionString)
      {
         if(connectionString.Prefix == KnownPrefix.AzureQueueStorage)
         {
            connectionString.GetRequired(KnownParameter.AccountName, true, out string accountName);
            connectionString.GetRequired(KnownParameter.KeyOrPassword, true, out string key);

            return new AzureStorageQueueMessenger(accountName, key);
         }

         return null;
      }

   }
}
