using GBERP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBERP.AF.DAL
{
    public class ServiceWrapper
    {
        private static SqlExecuteService.SqlExecuteClient _serviceClient;
        public static SqlExecuteService.SqlExecuteClient ServiceClient
        {
            get
            {
                if (_serviceClient == null)
                    _serviceClient = new SqlExecuteService.SqlExecuteClient();
                return _serviceClient;
            }
        }

        public static ReturnValue<DataTable> GetData(FactoryEnum factory, string key, Dictionary<string, string> parameters = null)
        {
            var rv = new ReturnValue<DataTable>();
            if (parameters == null)
                parameters = new Dictionary<string, string>();
            SqlExecuteService.StatementResult sr;
            try
            {
                sr = ServiceClient.GetStatement(factory.ToString(),
                key,
                AF.Environment.AccessToken);
                if (!sr.Result)
                {
                    rv.Result = false;
                    rv.Message = sr.Message;
                    return rv;
                }
            }
            catch (Exception ex)
            {
                rv.Result = false;
                rv.Message = ex.Message;
                return rv;
            }

            List<SqlParameter> sp = new List<SqlParameter>();
            if (parameters.Count > 0)
            {
                foreach (var kv in parameters)
                    sp.Add(new SqlParameter(kv.Key, kv.Value));
            }
            return DB.ExecuteDataTable(sr.ConnectionString, sr.Statements, sp.ToArray());
        }

        public enum FactoryEnum
        {
            GBMM
        }
    }
}
