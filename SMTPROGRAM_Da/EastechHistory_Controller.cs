using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class EastechHistory_Controller :SqlDataProvider
    {
        #region Insert Data
        public void EastechHistory_BKInsert(EastechHistory_Info data)
        {
            using (var cmd = new SqlCommand("sp_BKEastechHistory_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", data.programpartlist));
                cmd.Parameters.Add(new SqlParameter("@pkey", data.pkey));
                cmd.Parameters.Add(new SqlParameter("@psubkey", data.psubkey));
                cmd.Parameters.Add(new SqlParameter("@fdrno", data.fdrno));
                cmd.Parameters.Add(new SqlParameter("@partscode", data.partscode));
                cmd.Parameters.Add(new SqlParameter("@ndesc", data.ndesc));
                cmd.Parameters.Add(new SqlParameter("@usage", data.usage));
                cmd.Parameters.Add(new SqlParameter("@checkedby", data.checkedby));
                cmd.Parameters.Add(new SqlParameter("@checkedtime", data.checkedtime));               
                cmd.Parameters.Add(new SqlParameter("@reqqty", data.reqqty));
                cmd.Parameters.Add(new SqlParameter("@datecode", data.datecode));
                cmd.Parameters.Add(new SqlParameter("@Solanthaylinhkien", data.Solanthaylinhkien));
                cmd.Parameters.Add(new SqlParameter("@SoPCBCothedung", data.SoPCBCothedung));
                cmd.Parameters.Add(new SqlParameter("@remark1", data.remark1));
                cmd.Parameters.Add(new SqlParameter("@remark2", data.remark2));
                cmd.Parameters.Add(new SqlParameter("@remark3", data.remark3));
                cmd.Parameters.Add(new SqlParameter("@counts", data.counts));

				//cmd.Parameters.Add(new SqlParameter("@IDMetarial", data.IDMetarial));
				//cmd.Parameters.Add(new SqlParameter("@Field01", data.Field01));
				//cmd.Parameters.Add(new SqlParameter("@Field02", data.Field02));

				cmd.ExecuteNonQuery();
            }
        }
        //sp_EastechHistory_UpdateCombine
        public void EastechHistory_UpdateCombine(long Id, int reqqty, int SoPCBCothedung)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_UpdateCombine", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                cmd.Parameters.Add(new SqlParameter("@reqqty", reqqty));
                cmd.Parameters.Add(new SqlParameter("@SoPCBCothedung", SoPCBCothedung));                           
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region Insert Data
        public void EastechHistory_Insert(EastechHistory_Info data)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", data.programpartlist));
                cmd.Parameters.Add(new SqlParameter("@pkey", data.pkey));
                cmd.Parameters.Add(new SqlParameter("@psubkey", data.psubkey));
                cmd.Parameters.Add(new SqlParameter("@fdrno", data.fdrno));
                cmd.Parameters.Add(new SqlParameter("@partscode", data.partscode));
                cmd.Parameters.Add(new SqlParameter("@ndesc", data.ndesc));
                cmd.Parameters.Add(new SqlParameter("@usage", data.usage));
                cmd.Parameters.Add(new SqlParameter("@checkedby", data.checkedby));
                cmd.Parameters.Add(new SqlParameter("@checkedtime", data.checkedtime));
                //cmd.Parameters.Add(new SqlParameter("@rp", data.rp));
                //cmd.Parameters.Add(new SqlParameter("@rep1", data.rep1));
                //cmd.Parameters.Add(new SqlParameter("@rep2", data.rep2));
                //cmd.Parameters.Add(new SqlParameter("@rep3", data.rep3));
                //cmd.Parameters.Add(new SqlParameter("@rep4", data.rep4));
                //cmd.Parameters.Add(new SqlParameter("@rep5", data.rep5));
                cmd.Parameters.Add(new SqlParameter("@reqqty", data.reqqty));
                cmd.Parameters.Add(new SqlParameter("@datecode", data.datecode));
                cmd.Parameters.Add(new SqlParameter("@Solanthaylinhkien", data.Solanthaylinhkien));
                cmd.Parameters.Add(new SqlParameter("@SoPCBCothedung", data.SoPCBCothedung));
                cmd.Parameters.Add(new SqlParameter("@remark1", data.remark1));
                cmd.Parameters.Add(new SqlParameter("@remark2", data.remark2));
                cmd.Parameters.Add(new SqlParameter("@remark3", data.remark3));
                cmd.Parameters.Add(new SqlParameter("@counts", data.counts));


				//cmd.Parameters.Add(new SqlParameter("@IDMetarial", data.IDMetarial));
				//cmd.Parameters.Add(new SqlParameter("@Field01", data.Field01));
				//cmd.Parameters.Add(new SqlParameter("@Field02", data.Field02));
				cmd.ExecuteNonQuery();
            }
        }
        #endregion
        //sp_EastechHistory_UpdateAfter_CutLot_ChangeLine
        public void EastechHistory_UpdateAfter_CutLot_ChangeLine(EastechHistory_Info data)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_UpdateAfter_CutLot_ChangeLine", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", data.programpartlist));
                //cmd.Parameters.Add(new SqlParameter("@pkey", data.pkey));
                //cmd.Parameters.Add(new SqlParameter("@psubkey", data.psubkey));
                cmd.Parameters.Add(new SqlParameter("@fdrno", data.fdrno));
                cmd.Parameters.Add(new SqlParameter("@partscode", data.partscode));
                cmd.Parameters.Add(new SqlParameter("@ndesc", data.ndesc));
                //cmd.Parameters.Add(new SqlParameter("@usage", data.usage));
                cmd.Parameters.Add(new SqlParameter("@checkedby", data.checkedby));
                cmd.Parameters.Add(new SqlParameter("@checkedtime", data.checkedtime));
                //cmd.Parameters.Add(new SqlParameter("@rp", data.rp));
                //cmd.Parameters.Add(new SqlParameter("@rep1", data.rep1));
                //cmd.Parameters.Add(new SqlParameter("@rep2", data.rep2));
                //cmd.Parameters.Add(new SqlParameter("@rep3", data.rep3));
                //cmd.Parameters.Add(new SqlParameter("@rep4", data.rep4));
                //cmd.Parameters.Add(new SqlParameter("@rep5", data.rep5));
                cmd.Parameters.Add(new SqlParameter("@reqqty", data.reqqty));
                cmd.Parameters.Add(new SqlParameter("@datecode", data.datecode));
                cmd.Parameters.Add(new SqlParameter("@Solanthaylinhkien", data.Solanthaylinhkien));
                cmd.Parameters.Add(new SqlParameter("@SoPCBCothedung", data.SoPCBCothedung));
                cmd.Parameters.Add(new SqlParameter("@remark1", data.remark1));

                //cmd.Parameters.Add(new SqlParameter("@remark2", data.remark2));
                //cmd.Parameters.Add(new SqlParameter("@remark3", data.remark3));
                //cmd.Parameters.Add(new SqlParameter("@counts", data.counts));
                cmd.ExecuteNonQuery();
            }
        }
        //sp_EastechHistory_CheckFeeder
        public DataTable EastechHistory_CheckFeeder(string programpartlist,string fdrno)
        {           
                using (var cmd = new SqlCommand("sp_EastechHistory_CheckFeeder", GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@programpartlist", programpartlist));
                    cmd.Parameters.Add(new SqlParameter("@fdrno", fdrno));                   
                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            
        }
        //sp_EastechHistory_CombineProgramNonQRCode
        public DataTable EastechHistory_CombineProgramNonQRCode(string New_programpartlist, string Old_programpartlist, string Old_Line)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_CombineProgramNonQRCode", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@New_programpartlist", New_programpartlist));
                cmd.Parameters.Add(new SqlParameter("@Old_programpartlist", Old_programpartlist));
                cmd.Parameters.Add(new SqlParameter("@Old_Line", Old_Line));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

        }

        //sp_EastechHistory_getinfo
        public DataTable EastechHistory_getinfo(string programpartlist, string remark1)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_getinfo", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", programpartlist));
                cmd.Parameters.Add(new SqlParameter("@remark1", remark1));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

        }

        //sp_EastechHistory_UpdateQtyCount
        public void EastechHistory_UpdateQtyCount(string psubkey, int qty, int Solanthaylinhkien,int sopcb, int counts )
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_UpdateQtyCount", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@psubkey", psubkey));
                cmd.Parameters.Add(new SqlParameter("@reqqty", qty));
                cmd.Parameters.Add(new SqlParameter("@Solanthaylinhkien", Solanthaylinhkien));
                cmd.Parameters.Add(new SqlParameter("@SoPCBCothedung", sopcb));
                cmd.Parameters.Add(new SqlParameter("@counts", counts));
                
                cmd.ExecuteNonQuery();
            }
        }

        //sp_EastechHistory_UpdateCountBySubkeyVsSolanthanhlinkien
        //public void EastechHistory_UpdateCounts( string psubkey, int Solanthaylinhkien, int counts)
        //{
        //    using (var cmd = new SqlCommand("sp_EastechHistory_UpdateCountBySubkeyVsSolanthanhlinkien", GetConnection()))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(new SqlParameter("@psubkey", psubkey));                              
        //        cmd.Parameters.Add(new SqlParameter("@Solanthaylinhkien", Solanthaylinhkien));
        //        cmd.Parameters.Add(new SqlParameter("@counts", counts));
        //        cmd.ExecuteNonQuery();
        //    }
        //}
        public void EastechHistory_UpdateCounts(long Id,  int counts)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_UpdateCountBySubkeyVsSolanthanhlinkien", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", Id));                
                cmd.Parameters.Add(new SqlParameter("@counts", counts));
                cmd.ExecuteNonQuery();
            }
        }

        #region Kiểm tra 1 linh kiện xem đã được thay bao nhiêu lần, lấy lần gần nhất của linh kiện
        public DataTable EastechHistory_GetNumberPartcodeChange(string psubkey)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_CheckSubKeyNumber", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@psubkey", psubkey));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Lấy dữ liệu BOM của chương trình theo Key Program và line
        public DataTable EastechHistory_CheckProgKeyLineName(string program, string Linename)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_CheckProgKeyLineName", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", program));
                cmd.Parameters.Add(new SqlParameter("@remark1", Linename));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Lấy dữ liệu BOM của chương trình theo Key Program và line New
        public int EastechHistory_CheckProgKeyLineName_UV(string program, string Linename)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_CheckProgKeyLineName_UV_01", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", program));
                cmd.Parameters.Add(new SqlParameter("@remark1", Linename));
                cmd.Parameters.Add("@value", SqlDbType.Int);
                cmd.Parameters["@value"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.Parameters["@value"].Value);
                //var da = new SqlDataAdapter(cmd);
                //var dt = new DataTable();
                //da.Fill(dt);
                //return dt;
            }
        }
        #endregion
        //sp_EastechHistory_CheckProgKeyLineName_UV_20220517
        #region Lấy dữ liệu BOM của chương trình theo Key Program và line New
        public int EastechHistory_CheckProgKeyLineName_UV_20220517(string program, string Linename)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_CheckProgKeyLineName_UV_20220517", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", program));
                cmd.Parameters.Add(new SqlParameter("@remark1", Linename));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return int.Parse(dt.Rows[0][0].ToString());
            }
        }
        #endregion
        //sp_EastechHistory_CombineProgramQRCode
        #region Lấy toàn bộ dữ liệu check IPQC có bắn QR code còn thoe feeder của chương trình mới
        public DataTable EastechHistory_CombineProgramQRCode(string Newprogram, string Oldprogram,string OldLine)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_CombineProgramQRCode", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@New_programpartlist", Newprogram));
                cmd.Parameters.Add(new SqlParameter("@Old_programpartlist", Oldprogram));
                cmd.Parameters.Add(new SqlParameter("@Old_Line", OldLine));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
        //sp_EastechHistory_CheckProgKeyLineName_Checker

        #region Lấy dữ liệu BOM của chương trình theo Key Program và line Cho Check Xem
        public DataTable EastechHistory_CheckProgKeyLineName_Checker(string program, string Linename)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_CheckProgKeyLineName_Checker", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", program));
                cmd.Parameters.Add(new SqlParameter("@remark1", Linename));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
        //[sp_EastechHistory_CheckProgKeyLineName_Checker_Mistake]
        #region Lấy dữ liệu Còn thiếu khi công nhân bắn trên line
        public DataTable EastechHistory_CheckProgKeyLineName_Checker_Mistake(string program, string Linename)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_CheckProgKeyLineName_Checker_Mistake", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", program));
                cmd.Parameters.Add(new SqlParameter("@remark1", Linename));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
        #region Lấy dữ liệu cut lot khi kiểm tra lại linh kiện với số lượng =0
        public DataTable EastechHistory_CheckCutLotQtyFeeder(string program, string NewLinename)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_CheckCutLotQtyFeeder", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programkey", program));
                cmd.Parameters.Add(new SqlParameter("@NewLine", NewLinename));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
        #region Xóa dữ liệu với reqqty=0 với những lot cut
        public void EastechHistory_DelCutLotQtyFeeder(long Id)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_DelCutLotQtyFeeder", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        //[sp_EastechHistory_CheckProgKeyLineName_Checker_StillHave]
        #region Lấy dữ liệu Còn còn trên line
        public DataTable EastechHistory_CheckProgKeyLineName_Checker_StillHave(string program, string Linename)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_CheckProgKeyLineName_Checker_StillHave", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", program));
                cmd.Parameters.Add(new SqlParameter("@remark1", Linename));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        ////sp_EastechHistory_CheckProgKeyLineName_Checker_Tong
        //#region Lấy dữ liệu Còn còn trên line
        //public DataTable EastechHistory_CheckProgKeyLineName_Checker_(string program, string Linename)
        //{
        //    using (var cmd = new SqlCommand("sp_EastechHistory_CheckProgKeyLineName_Checker_StillHave", GetConnection()))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(new SqlParameter("@programpartlist", program));
        //        cmd.Parameters.Add(new SqlParameter("@remark1", Linename));
        //        var da = new SqlDataAdapter(cmd);
        //        var dt = new DataTable();
        //        da.Fill(dt);
        //        return dt;
        //    }
        //}
        //#endregion

        #region Kiểm tra xem program này đã được lưu vào csdl chưa
        public DataTable EastechHistory_CheckProgKey(string program)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_CheckProgKey", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", program));                
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Kiểm tra xem partcode này có đúng không?
        //sp_EastechHistory_CheckPartscode
        public DataTable EastechHistory_CheckPartscode(string programpartlist, string fdrno, string partscode)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_CheckPartscode", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", programpartlist));
                cmd.Parameters.Add(new SqlParameter("@fdrno", fdrno));
                cmd.Parameters.Add(new SqlParameter("@partscode", partscode));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Kiểm tra xem có đúng line name theo program feeder partcode line name không
        //sp_EastechHistory_CheckLinename
        public DataTable EastechHistory_CheckLinename(string programpartlist, string fdrno, string partscode, string remark1)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_CheckLinename", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", programpartlist));
                cmd.Parameters.Add(new SqlParameter("@fdrno", fdrno));
                cmd.Parameters.Add(new SqlParameter("@partscode", partscode));
                cmd.Parameters.Add(new SqlParameter("@remark1", remark1));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Lấy số lần thay linh kiện
        //sp_EastechHistory_GetQty
        public DataTable EastechHistory_GetQty(string programpartlist, string fdrno, string partscode, string remark1, int Solanthaylinhkien)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_GetQty", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", programpartlist));
                cmd.Parameters.Add(new SqlParameter("@fdrno", fdrno));
                cmd.Parameters.Add(new SqlParameter("@partscode", partscode));
                cmd.Parameters.Add(new SqlParameter("@remark1", remark1));
                cmd.Parameters.Add(new SqlParameter("@Solanthaylinhkien", Solanthaylinhkien));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Hiển thị thông tin sau khi combine hoặc chuyển line
        public DataTable EastechHistory_CheckCombineLine(string program, string Linename)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_CheckCombineLine", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", program));
                cmd.Parameters.Add(new SqlParameter("@remark1", Linename));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region thực hiện việc chuyển line combine và update dữ liệu
        public void EastechHistory_InsertUpdateQtyCount(string NewProgram, string NewLineName, string OldProgram, string OldLineName, string VCheckedBy, string VDept)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_InsertUpdateQtyCount", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@NewProgram", NewProgram));
                cmd.Parameters.Add(new SqlParameter("@NewLineName", NewLineName));
                cmd.Parameters.Add(new SqlParameter("@OldProgram", OldProgram));
                cmd.Parameters.Add(new SqlParameter("@OldLineName", OldLineName));
                cmd.Parameters.Add(new SqlParameter("@VCheckedBy", VCheckedBy));
                cmd.Parameters.Add(new SqlParameter("@VDept", VDept));

                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region thực hiện việc chuyển line combine và update dữ liệu
        public void EastechHistory_InsertUpdateQtyCount_UV(string NewProgram, string NewLineName, string OldProgram, string OldLineName, string VCheckedBy, string VDept)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_InsertUpdateQtyCount_UV", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@NewProgram", NewProgram));
                cmd.Parameters.Add(new SqlParameter("@NewLineName", NewLineName));
                cmd.Parameters.Add(new SqlParameter("@OldProgram", OldProgram));
                cmd.Parameters.Add(new SqlParameter("@OldLineName", OldLineName));
                cmd.Parameters.Add(new SqlParameter("@VCheckedBy", VCheckedBy));
                cmd.Parameters.Add(new SqlParameter("@VDept", VDept));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region Thực hiện việc cắt Lot
        public void EastechHistory_UpdateQtyCount_New(string program, string NewLine, string OldLine)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_UpdateQtyCount_New", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ProgramKey", program));
                cmd.Parameters.Add(new SqlParameter("@remark1", NewLine));
                cmd.Parameters.Add(new SqlParameter("@oldLine", OldLine));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region Thực hiện việc cắt Lot
        public void EastechHistory_UpdateQtyCount_New_UV(string program, string NewLine, string OldLine)
        {
            using (var cmd = new SqlCommand("sp_EastechHistory_UpdateQtyCount_New_UV", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ProgramKey", program));
                cmd.Parameters.Add(new SqlParameter("@remark1", NewLine));
                cmd.Parameters.Add(new SqlParameter("@oldLine", OldLine));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region Update count by ID sp_EastechOutputHistory_UpdatetSelectData
        public void sp_EastechOutputHistory_UpdatetSelectData(long Id)
        {
            using (var cmd = new SqlCommand("sp_EastechOutputHistory_UpdatetSelectData", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", Id));                
                cmd.ExecuteNonQuery();
            }
        }
        #endregion


    }
}
