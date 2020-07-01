using System;
using Storage.NetCore.Blobs;
using Storage.NetCore.ConnectionString;
using Storage.NetCore.Messaging;

namespace Storage.NetCore.Microsoft.Azure.KeyVault
{
   class ExternalModule : IExternalModule, IConnectionFactory
   {
      public IConnectionFactory ConnectionFactory => this;

      public IBlobStorage CreateBlobStorage(StorageConnectionString connectionString)
      {
         if(connectionString.Prefix == KnownPrefix.AzureKeyVault)
         {
            connectionString.GetRequired(KnownParameter.VaultUri, true, out string uri);

            if(connectionString.Parameters.ContainsKey(KnownParameter.MsiEnabled))
            {
               return StorageFactory.Blobs.AzureKeyVaultWithMsi(new Uri(uri));
            }
            else
            {
               connectionString.GetRequired(KnownParameter.TenantId, true, out string tenantId);
               connectionString.GetRequired(KnownParameter.ClientId, true, out string clientId);
               connectionString.GetRequired(KnownParameter.ClientSecret, true, out string clientSecret);

               return StorageFactory.Blobs.AzureKeyVault(new Uri(uri), tenantId, clientId, clientSecret);
            }
         }

         return null;
      }

      public IMessenger CreateMessenger(StorageConnectionString connectionString) => null;
   }
}
