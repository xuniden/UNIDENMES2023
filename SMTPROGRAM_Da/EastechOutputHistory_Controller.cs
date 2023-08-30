using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class EastechOutputHistory_Controller:SqlDataProvider
    {

        #region Insert Data
        public void EastechOutputHistory_AllInsertUpdateCount(string QrCode, string programpartlist, string LineName , string Model, string Remark, string Remark1, string Remark2 , string Remark3, string Remark4 , string Remark5)
        {
            using (var cmd = new SqlCommand("sp_EastechOutputHistory_AllInsertUpdateCount", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@QRCode", QrCode));
                cmd.Parameters.Add(new SqlParameter("@programpartlist", programpartlist));
                cmd.Parameters.Add(new SqlParameter("@LineName",LineName));
                cmd.Parameters.Add(new SqlParameter("@Model", Model));
                cmd.Parameters.Add(new SqlParameter("@Remark", Remark));
                cmd.Parameters.Add(new SqlParameter("@Remark1", Remark1));
                cmd.Parameters.Add(new SqlParameter("@Remark2", Remark2));
                cmd.Parameters.Add(new SqlParameter("@Remark3", Remark3));
                cmd.Parameters.Add(new SqlParameter("@Remark4", Remark4));
                cmd.Parameters.Add(new SqlParameter("@Remark5", Remark5));                
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region Insert Data
        public void EastechOutputHistory_Insert(EastechOutputHistory_Info data)
        {
            using (var cmd = new SqlCommand("sp_EastechOutputHistory_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@QRCode", data.QRCode));
                cmd.Parameters.Add(new SqlParameter("@programkey", data.programkey));
                cmd.Parameters.Add(new SqlParameter("@Feeder", data.Feeder));
                cmd.Parameters.Add(new SqlParameter("@LineName", data.LineName));
                cmd.Parameters.Add(new SqlParameter("@Partcode", data.Partcode));
                cmd.Parameters.Add(new SqlParameter("@NDesc", data.NDesc));
                cmd.Parameters.Add(new SqlParameter("@DateCode", data.DateCode));
                cmd.Parameters.Add(new SqlParameter("@usage", data.usage));           
                cmd.Parameters.Add(new SqlParameter("@DateT", data.DateT));
                cmd.Parameters.Add(new SqlParameter("@Model", data.Model));
                cmd.Parameters.Add(new SqlParameter("@Remark", data.Remark));
                cmd.Parameters.Add(new SqlParameter("@Remark1", data.Remark1));
                cmd.Parameters.Add(new SqlParameter("@Remark2", data.Remark2));
                cmd.Parameters.Add(new SqlParameter("@Remark3", data.Remark3));
                cmd.Parameters.Add(new SqlParameter("@Remark4", data.Remark4));
                cmd.Parameters.Add(new SqlParameter("@Remark5", data.Remark5));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region Kiểm tra xem QR Code đã được bắn lên hệ thống chưa???
        public DataTable EastechOutputHistory_Smt_CheckQRCode(string QRCode)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_smt_CheckQRCode", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@QRCode", QRCode));                
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        //sp_EastechHistory_smt_CheckQRCodeRemark

        #region Kiểm tra xem QR Code đã được bắn lên hệ thống chưa???
        public DataTable EastechHistory_smt_CheckQRCodeRemark(string QRCode, string Remark3)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_smt_CheckQRCodeRemark", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@QRCode", QRCode));
                cmd.Parameters.Add(new SqlParameter("@Remark3", Remark3));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Lấy số lượng bắn được của từng người hiển thị lên màn hình
        public int EastechHOutistory_Count(string programkey, string Remark)
        {
            using (var cmd = new SqlCommand("sp_EastechOutputHistory_Count", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programkey", programkey));
                cmd.Parameters.Add(new SqlParameter("@Remark", Remark));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count;
            }
        }
        #endregion

        #region Lấy số lượng bắn được của từng người hiển thị lên màn hình
        public DataTable EastechHOutistory_Count2(string pgkey1, string pgkey2, string Remark)
        {
            using (var cmd = new SqlCommand("sp_EastechOutputHistory_Count2", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programkey1", pgkey1));
                cmd.Parameters.Add(new SqlParameter("@programkey2", pgkey2));
                cmd.Parameters.Add(new SqlParameter("@Remark", Remark));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public long EastechHOutistory_CountQRCodeByUser(string pgkey1, string pgkey2, string Remark)
        {
            using (var cmd = new SqlCommand("sp_EastechOutputHistory_Count2", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programkey1", pgkey1));
                cmd.Parameters.Add(new SqlParameter("@programkey2", pgkey2));
                cmd.Parameters.Add(new SqlParameter("@Remark", Remark));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count;
            }
        }
        #endregion

        //sp_EastechOutputHistory_ListQrByUser

        #region Hiển thị số lượng bản ghi bắn được của từng người 
        public DataTable EastechOutputHistory_ListQrByUser(string programkey, string QRCode,string Remark)
        {
            using (var cmd = new SqlCommand("sp_EastechOutputHistory_ListQrByUser", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programkey", programkey));
                cmd.Parameters.Add(new SqlParameter("@QRCode", QRCode));
                cmd.Parameters.Add(new SqlParameter("@Remark", Remark));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
        #region Hiển thị số lượng bản ghi bắn được của từng người 
        public DataTable EastechOutputHistory_ListQrByUser2(string pgkey1, string pgkey2, string QRCode, string Remark,DateTime DateT)
        {
            using (var cmd = new SqlCommand("sp_EastechOutputHistory_ListQrByUser2", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programkey1", pgkey1));
                cmd.Parameters.Add(new SqlParameter("@programkey2", pgkey2));
                cmd.Parameters.Add(new SqlParameter("@QRCode", QRCode));
                cmd.Parameters.Add(new SqlParameter("@Remark", Remark));
                cmd.Parameters.Add(new SqlParameter("@DateT", DateT));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
        #region SỐ LƯỢNG LINH KIỆN CỦA TỪNG QR CODE
        public long  EastechOutputHistory_CountMaterialOfQRcode(string pgkey1, string pgkey2, string QRCode, string Remark, DateTime DateT)
        {
            using (var cmd = new SqlCommand("sp_EastechOutputHistory_ListQrByUserNew", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programkey1", pgkey1));
                cmd.Parameters.Add(new SqlParameter("@programkey2", pgkey2));
                cmd.Parameters.Add(new SqlParameter("@QRCode", QRCode));
                cmd.Parameters.Add(new SqlParameter("@Remark", Remark));
                cmd.Parameters.Add(new SqlParameter("@DateT", DateT));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                if (dt!=null)
                {
                    return long.Parse(dt.Rows[0][0].ToString());
                }
                else
                {
                    return 0;
                }    
            }
        }
        #endregion

        #region Hiển thị số lượng bản ghi bắn được của từng người 
        public DataTable EastechOutputHistory_ListQrByUser1(string programkey, string Remark)
        {
            using (var cmd = new SqlCommand("sp_EastechOutputHistory_ListQrByUser1", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programkey", programkey));                
                cmd.Parameters.Add(new SqlParameter("@Remark", Remark));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        //sp_EastechOutputHistory_CheckMatPcb

        #region Kiểm tra mặt của PCB nếu PCB có 2 mặt cần mount thì phải bắn mặt 1 trước nếu mặt 1 chưa được bắn thì ko cho bắn mặt 2

        public DataTable EastechOutputHistory_CheckMatPcb(string programkey)
        {
            using (var cmd = new SqlCommand("sp_EastechOutputHistory_CheckMatPcb", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programkey", programkey));                
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        //sp_EastechOutputHistory_Check2Face

        #region Kiểm tra xem QR Code này có được bắn quá 1 lần đối với mặt 2 của PCB không?
        public DataTable EastechOutputHistory_Check2Face(string qrcode)
        {
            using (var cmd = new SqlCommand("sp_EastechOutputHistory_Check2Face", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@QRCode", qrcode));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
        #region Kiểm tra xem QR Code này có được bắn quá 1 lần đối với mặt 2 của PCB không mới?
        public DataTable EastechOutputHistory_Check2FaceNew(string qrcode, string Remark4)
        {
            using (var cmd = new SqlCommand("sp_EastechOutputHistory_Check2FaceNew", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@QRCode", qrcode));
                cmd.Parameters.Add(new SqlParameter("@Remark4", Remark4));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        //sp_EastechHistory_smt_CheckQRCodeFeeder

        #region Kiểm tra xem QR vs Feeder  này có được bắn chưa
        public DataTable EastechHistory_smt_CheckQRCodeFeeder(string Program,string qrcode, string feeder)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_smt_CheckQRCodeFeeder", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Program", Program));
                cmd.Parameters.Add(new SqlParameter("@QRCode", qrcode));
                cmd.Parameters.Add(new SqlParameter("@Feeder", feeder));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Lấy dữ liệu giống nhau từ BOM và từ chương trinh kiểm tra nhập liệu theo tên chương trình
        public DataTable EastechHistory_getSelectedData(string Program, string Remark1)
        {
            using (var cmd = new SqlCommand("sp_EastechOutputHistory_SelectCheckByProkey", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", Program));
                cmd.Parameters.Add(new SqlParameter("@Remark1", Remark1));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
        #region Insert dữ liệu vào bảng output sp_EastechOutputHistory_InsertSelectData
        public void sp_EastechOutputHistory_InsertSelectData(EastechOutputHistory_Info data)
        {
            using (var cmd = new SqlCommand("sp_EastechOutputHistory_InsertSelectData", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@QRCode", data.QRCode));
                cmd.Parameters.Add(new SqlParameter("@programkey", data.programkey));
                cmd.Parameters.Add(new SqlParameter("@Feeder", data.Feeder));
                cmd.Parameters.Add(new SqlParameter("@LineName", data.LineName));
                cmd.Parameters.Add(new SqlParameter("@Partcode", data.Partcode));
                cmd.Parameters.Add(new SqlParameter("@NDesc", data.NDesc));
                cmd.Parameters.Add(new SqlParameter("@DateCode", data.DateCode));
                cmd.Parameters.Add(new SqlParameter("@usage", data.usage));                
                cmd.Parameters.Add(new SqlParameter("@Model", data.Model));
                cmd.Parameters.Add(new SqlParameter("@Remark", data.Remark));
                cmd.Parameters.Add(new SqlParameter("@Remark1", data.Remark1));
                cmd.Parameters.Add(new SqlParameter("@Remark2", data.Remark2));
                cmd.Parameters.Add(new SqlParameter("@Remark3", data.Remark3));
                cmd.Parameters.Add(new SqlParameter("@Remark4", data.Remark4));
                cmd.Parameters.Add(new SqlParameter("@Remark5", data.Remark5));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region Ghi thông tin lỗi khi xảy ra ở công đoạn bắn QR code
        public long EastechErrorLog(string staffid, string dept, string linename, string errordetail, DateTime createddate,string QrCode)
        {
            int identityKey = 0;
            using (var cmd = new SqlCommand("sp_ScanQRCodeApproveError", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@StaffID", staffid));
                cmd.Parameters.Add(new SqlParameter("@Dept", dept));
                cmd.Parameters.Add(new SqlParameter("@LineName", linename));              
                cmd.Parameters.Add(new SqlParameter("@ErrorDetail", errordetail));
                cmd.Parameters.Add(new SqlParameter("@CreatedDate", createddate));
                cmd.Parameters.Add(new SqlParameter("@QRCode", QrCode));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        identityKey = reader.GetInt32(reader.GetOrdinal("identity_key"));
                    }
                }               
                return identityKey;
            }
        }
        #endregion
        #region Approve error từ leader vào cosdl
        public void EastechErrorLog_Update(long id, string approve, string remark, DateTime approvedate)
        {            
            using (var cmd = new SqlCommand("sp_ScanQRCodeApproveError_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.Parameters.Add(new SqlParameter("@Aprroved", approve));
                cmd.Parameters.Add(new SqlParameter("@Remark", remark));
                cmd.Parameters.Add(new SqlParameter("@ApprovedDate", approvedate));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region Kiểm tra xem đã update thông tin thành công chưa
        public DataTable EastechErrorLog_CheckUpdate(long  Id)
        {
            using (var cmd = new SqlCommand("sp_ScanQRCodeCheckUpdateLogID", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
        #region Xác nhận iD của leader
        public DataTable LeaderEastechErrorLogCheckID(string staffId)
        {
            using (var cmd = new SqlCommand("sp_ScanQRCodeApproveErrorCheckLeaderID", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@StaffID", staffId));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        public void AddApproveStaff( string staffid, string staffname)
        {
            using (var cmd = new SqlCommand("sp_EASTECH_ERROR_APPROVE", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@StaffID", staffid));
                cmd.Parameters.Add(new SqlParameter("@StaffName", staffname));
               
                cmd.ExecuteNonQuery();
            }
        }
    }
}
