using Storage.NetCore.Blobs;
using Storage.NetCore.Blobs.Files;
using Storage.NetCore.Messaging;
using Storage.NetCore.Messaging.Files;

namespace Storage.NetCore.ConnectionString
{
   class BuiltInConnectionFactory : IConnectionFactory
   {
      public IBlobStorage CreateBlobStorage(StorageConnectionString connectionString)
      {
         if(connectionString.Prefix == "disk")
         {
            connectionString.GetRequired("path", true, out string path);

            return new DiskDirectoryBlobStorage(path);
         }

         if(connectionString.Prefix == "inmemory")
         {
            return new InMemoryBlobStorage();
         }

         if(connectionString.Prefix == "zip")
         {
            connectionString.GetRequired("path", true, out string path);

            return new ZipFileBlobStorage(path);
         }

         return null;
      }

      public IMessenger CreateMessenger(StorageConnectionString connectionString)
      {
         if(connectionString.Prefix == "inmemory")
         {
            connectionString.GetRequired("name", true, out string name);

            return InMemoryMessenger.CreateOrGet(name);
         }

         if(connectionString.Prefix == "disk")
         {
            connectionString.GetRequired("path", true, out string path);

            return new LocalDiskMessenger(path);
         }

         return null;
      }
   }
}
