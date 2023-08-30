using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Smt.DataControl
{
	public class SMT_AOI_ERROR_RECORD_DAL
	{
		UVEntities _entities = new UVEntities();
		private static SMT_AOI_ERROR_RECORD_DAL instance;
		public static SMT_AOI_ERROR_RECORD_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new SMT_AOI_ERROR_RECORD_DAL();
				return instance;
			}
		}

		public SMT_AOI_ERROR_RECORD_DAL() { }

		public string Add(SMT_AOI_ERROR_RECORD smtAoiErrorRecord)
		{
			string message = "";
			try
			{
				_entities.SMT_AOI_ERROR_RECORD.Add(smtAoiErrorRecord);
				_entities.SaveChanges();
				 message = "";
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}
		#region lấy tổng số PCB OK and PCB NG
		public string GetTotalCounts(string program1, string program2)
		{
			var program1Param = new SqlParameter("@program1", SqlDbType.NVarChar, 200)
			{
				Value = program1
			};

			var program2Param = new SqlParameter("@program2", SqlDbType.NVarChar, 200)
			{
				Value = program2
			};

			var totalOKParam = new SqlParameter("@TotalOK", SqlDbType.Float)
			{
				Direction = ParameterDirection.Output
			};

			var totalNGParam = new SqlParameter("@TotalNG", SqlDbType.Float)
			{
				Direction = ParameterDirection.Output
			};

			_entities.Database.ExecuteSqlCommand(
				"EXEC [dbo].[sp_smt_chartForAOI] @program1, @program2, @TotalOK OUTPUT, @TotalNG OUTPUT",
				program1Param,
				program2Param,
				totalOKParam,
				totalNGParam
			);

			float totalOK = Convert.ToSingle(totalOKParam.Value);
			float totalNG = Convert.ToSingle(totalNGParam.Value);

			return totalOK + ";" + totalNG;
		}
		#endregion	

	}
}
