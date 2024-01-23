using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

namespace POSsible.DAL
{
    public class UtilsDAO
    {
        public UtilsDAO()
        {
            DbProviderHelper.GetConnection();
        }


        #region dbTransaction

        public static DbTransaction BeginTransaction()
        {
            return DbProviderHelper.BeginTransaction();
        }
        public static void CommitTransaction(DbTransaction dbTransaction)
        {
            DbProviderHelper.CommitTransaction(dbTransaction);
        }
        public static void RollbackTransaction(DbTransaction dbTransaction)
        {
            DbProviderHelper.RollbackTransaction(dbTransaction);
        }

        #endregion dbTransaction
        
    }
}
