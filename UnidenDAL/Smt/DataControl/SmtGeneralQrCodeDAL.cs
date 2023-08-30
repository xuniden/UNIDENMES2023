using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Smt.DataControl
{
    public class SmtGeneralQrCodeDAL
    {

        UVEntities _entities = new UVEntities();
        private static SmtGeneralQrCodeDAL instance;
        public static SmtGeneralQrCodeDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SmtGeneralQrCodeDAL();
                return instance;
            }
        }
        public SmtGeneralQrCodeDAL() { }

		#region Kiểm tra sự tồn tại của QR với Model
		public tbl_EstechSerialGeneral checkExistQRCode(string QRCode, string Model)
		{
			return _entities.tbl_EstechSerialGeneral.Where(x => x.Serial_Number == QRCode&&x.Model==Model ).FirstOrDefault();
		}
		#endregion
		public tbl_EstechSerialGeneral checkExistQRCode(string QRCode)
        {
            return _entities.tbl_EstechSerialGeneral.Where(x=>x.Serial_Number == QRCode).FirstOrDefault();
        }

        public bool CheckListSerialExist(List<tbl_EstechSerialGeneral> lstSerial)
        {
            var lst = lstSerial.Select(x => x.Serial_Number).ToList();

            bool hasMatch = _entities.tbl_EstechSerialGeneral.Select(x => x.Serial_Number)
                          .Intersect(lst)
                          .Any();
            return hasMatch;

            //var items = (from x in _entities.tbl_EstechSerialGeneral
            //             join y in lstSerial.Select(k => k.Serial_Number).ToList() on x.Serial_Number equals y
            //             select x)
            //.ToList();


        }
        public bool AddRange(List<tbl_EstechSerialGeneral> lstQrCode)
        {
            try
            {
                _entities.tbl_EstechSerialGeneral.AddRange(lstQrCode);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
