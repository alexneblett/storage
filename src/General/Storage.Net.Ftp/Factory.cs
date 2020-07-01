﻿using System;
using System.Net;
using FluentFTP;
using Storage.NetCore.Blobs;
using Storage.NetCore.ConnectionString;
using Storage.NetCore.Ftp;

namespace Storage.NetCore
{
   public static class Factory
   {
      /// <summary>
      /// Register Azure module.
      /// </summary>
      public static IModulesFactory UseFtpStorage(this IModulesFactory factory)
      {
         return factory.Use(new Module());
      }

      private class Module : IExternalModule
      {
         public IConnectionFactory ConnectionFactory => new ConnectionFactory();
      }

      /// <summary>
      /// Constructs an instance of FTP client from host name and credentials
      /// </summary>
      public static IBlobStorage Ftp(this IBlobStorageFactory factory,
         string hostNameOrAddress, NetworkCredential credentials,
         FtpDataConnectionType dataConnectionType = FtpDataConnectionType.AutoActive)
      {
         return new FluentFtpBlobStorage(hostNameOrAddress, credentials, dataConnectionType);
      }

      /// <summary>
      /// Constructs an instance of FTP client by accepting a custom instance of FluentFTP client
      /// </summary>
      public static IBlobStorage FtpFromFluentFtpClient(this IBlobStorageFactory factory,
         FtpClient ftpClient)
      {
         return new FluentFtpBlobStorage(ftpClient, false);
      }
   }
}
