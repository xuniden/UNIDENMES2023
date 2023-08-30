using ExcelDataReader.Log;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.Assy.Setup;
using UnidenDTO;

namespace UnidenDAL.Assy
{
    public class LINEPROCESSNONHISTORY_DAL
    {
        UVEntities _entities = new UVEntities();
        private static LINEPROCESSNONHISTORY_DAL instance;
        public static LINEPROCESSNONHISTORY_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new LINEPROCESSNONHISTORY_DAL();
                return instance;
            }
        }
        public LINEPROCESSNONHISTORY_DAL() { }

        //public bool checkDataAsTable(string table, string column, string condition)
        //{
        //    bool result = false;
        //    var dt = new System.Data.DataTable();
        //    using (var command = _entities.Database.Connection.CreateCommand())
        //    {
        //        command.CommandText = "sp_uv_CheckDataAsTable";
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.Add(new SqlParameter("@table", table));
        //        command.Parameters.Add(new SqlParameter("@column", column));
        //        command.Parameters.Add(new SqlParameter("@condition", condition));
        //        if (command.Connection.State != ConnectionState.Open)
        //        {
        //            command.Connection.Open();
        //        }
        //        using (var reader = command.ExecuteReader())
        //        {
        //            dt.Load(reader);
        //        }
        //    }
        //    if (dt.Rows.Count > 0) { result = true; }
        //    return result;
        //}
        //    public string Add(UV_LINEPROCESS_NON_HISTORY processNonHistory)
        //    {
        //        string message = "";
        //        try
        //        {
        //            _entities.UV_LINEPROCESS_NON_HISTORY.Add(processNonHistory);
        //            _entities.SaveChanges();
        //            message = "";
        //        }
        //        catch (Exception ex)
        //        {
        //            message="Đã có lỗi xảy ra khi thêm dữ liệu: " + ex.Message;
        //        }
        //        return message;
        //    }
        //    //sp_uv_getListNonProcessLineAndLot
        //    public System.Data.DataTable getListNonProcessLineAndLot(string lineName, string Lot, string User)
        //    {
        //        var dt = new System.Data.DataTable();
        //        using (var command = _entities.Database.Connection.CreateCommand())
        //        {
        //            command.CommandText = "sp_uv_getListNonProcessLineAndLot";
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.Add(new SqlParameter("@LineName", lineName));
        //            command.Parameters.Add(new SqlParameter("@Lot", Lot));
        //            command.Parameters.Add(new SqlParameter("@User", User));
        //            if (command.Connection.State != ConnectionState.Open)
        //            {
        //                command.Connection.Open();
        //            }
        //            using (var reader = command.ExecuteReader())
        //            {
        //                dt.Load(reader);
        //            }
        //        }
        //        return dt;
        //    }
        //    public System.Data.DataTable getListNonProcessByUser(string user)
        //    {
        //        var dt = new System.Data.DataTable();
        //        using (var command = _entities.Database.Connection.CreateCommand())
        //        {
        //            command.CommandText = "sp_uv_getListNonProcessByUser";
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.Add(new SqlParameter("@user",user));                
        //            if (command.Connection.State != ConnectionState.Open)
        //            {
        //                command.Connection.Open();
        //            }
        //            using (var reader = command.ExecuteReader())
        //            {
        //                dt.Load(reader);
        //            }
        //        }
        //        return dt;
        //    }
    }
}
