using System;
using System.Threading.Tasks;

namespace Storage.NetCore
{
   /// <summary>
   /// Transaction manager for storages supporting transactional operations, to be moved to the core later
   /// </summary>
   interface ITransactionManager : IDisposable
   {
      /// <summary>
      /// Commits the transaction
      /// </summary>
      /// <returns></returns>
      Task CommitAsync();
   }
}
