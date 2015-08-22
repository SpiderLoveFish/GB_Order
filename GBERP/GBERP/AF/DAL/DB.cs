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
    public class DB
    {
        /// <summary>
        /// Execute a sql command to dataTable
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="cmdText"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static ReturnValue<DataTable> ExecuteDataTable(
            string connString,
            string cmdText,
            params SqlParameter[] paras)
        {
            var rv = new ReturnValue<DataTable>();
            var dt = new DataTable("UF_DAL_ExecuteDataTable");
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    rv.Result = false;
                    rv.Message = ex.Message;
                    return rv;
                }

                SqlTransaction ts = null;
                var cmd = new SqlCommand();
                var adt = new SqlDataAdapter();
                cmd.Connection = conn;
                cmd.CommandTimeout = 0;
                cmd.CommandText = cmdText;
                if (paras != null && paras.Length > 0)
                    cmd.Parameters.AddRange(paras.ToArray());
                ts = conn.BeginTransaction();
                cmd.Transaction = ts;
                adt.SelectCommand = cmd;
                try
                {
                    rv.Message = adt.Fill(dt).ToString();
                    ts.Commit();
                }
                catch (Exception ex)
                {
                    ts.Rollback();
                    rv.Result = false;
                    rv.Message = ex.Message;
                    return rv;
                }
                finally
                {
                    cmd.Parameters.Clear();
                }

            } //end using

            rv.Output1 = dt;
            return rv;
        }

        public static ReturnValue<DataSet> ExecuteDataSet(
            string connString,
            string cmdText,
            params SqlParameter[] paras)
        {
            var rv = new ReturnValue<DataSet>();
            var ds = new DataSet("UF_DAL_ExecuteDataSet");
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    rv.Result = false;
                    rv.Message = ex.Message;
                    return rv;
                }

                SqlTransaction ts = null;
                var cmd = new SqlCommand();
                var adt = new SqlDataAdapter();
                cmd.Connection = conn;
                //3600 seconds, means 1 hour
                cmd.CommandTimeout = 3600;
                cmd.CommandText = cmdText;
                if (paras != null && paras.Length > 0)
                    cmd.Parameters.AddRange(paras.ToArray());
                ts = conn.BeginTransaction();
                cmd.Transaction = ts;
                adt.SelectCommand = cmd;
                try
                {
                    rv.Message = adt.Fill(ds).ToString();
                    ts.Commit();
                }
                catch (Exception ex)
                {
                    ts.Rollback();
                    rv.Result = false;
                    rv.Message = ex.Message;
                    return rv;
                }
                finally
                {
                    cmd.Parameters.Clear();
                }

            } //end using
            rv.Output1 = ds;
            return rv;
        }

        /// <summary>
        /// Execute a command
        /// </summary>
        /// <param name="server"></param>
        /// <param name="cmdText"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static ReturnValue ExecuteNoneQuery(
            string connSring,
            string cmdText,
            params SqlParameter[] paras)
        {
            var rv = new ReturnValue();
            using (var conn = new SqlConnection(connSring))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    rv.Result = false;
                    rv.Message = ex.Message;
                    return rv;
                }

                SqlTransaction ts = null;
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                //3600 seconds, means 1 hour
                cmd.CommandTimeout = 3600;
                cmd.CommandText = cmdText;
                if (paras != null && paras.Length > 0)
                    cmd.Parameters.AddRange(paras.ToArray());
                ts = conn.BeginTransaction();
                cmd.Transaction = ts;

                try
                {
                    rv.Message = cmd.ExecuteNonQuery().ToString();
                    ts.Commit();
                }
                catch (Exception ex)
                {
                    ts.Rollback();
                    rv.Result = false;
                    rv.Message = ex.Message;
                    return rv;
                }
                finally
                {
                    cmd.Parameters.Clear();
                }

            } //end using

            return rv;
        }

    }
}
