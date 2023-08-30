using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Assy
{
    public class QRCODELINKVSLINECODE_DAL
    {
        UVEntities _entities = new UVEntities();
        private static QRCODELINKVSLINECODE_DAL instance;
        public static QRCODELINKVSLINECODE_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new QRCODELINKVSLINECODE_DAL();
                return instance;
            }
        }
        public QRCODELINKVSLINECODE_DAL() { }

        public UV_QRCODELINKVSLINECODE CheckPrintBarcodevsQRCode(string Qrcode)
        {
            return _entities.UV_QRCODELINKVSLINECODE.Where(
                p => p.QRCode01 == Qrcode
                || p.QRCode02 == Qrcode
                || p.QRCode03==Qrcode
                || p.QRCode04==Qrcode
                || p.QRCode05==Qrcode
                || p.QRCode==Qrcode).FirstOrDefault();
        }
        public string Add(UV_QRCODELINKVSLINECODE lineProcessHistory)
        {
            string message = "";
            try
            {
                _entities.UV_QRCODELINKVSLINECODE.Add(lineProcessHistory);
                _entities.SaveChanges();
                message = "";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
        public UV_QRCODELINKVSLINECODE checkDoublicateBarcode(string barcode)
        {
            return _entities.UV_QRCODELINKVSLINECODE.Where(p=>p.QRCode01 == barcode).FirstOrDefault();
        }
    }
}
