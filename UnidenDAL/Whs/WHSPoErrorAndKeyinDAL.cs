using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDAL.whs;
using UnidenDTO;

namespace UnidenDAL.Whs
{
    public class WHSPoErrorAndKeyinDAL
    {
        UVEntities _entities = new UVEntities();
        private static WHSPoErrorAndKeyinDAL instance;
        public static WHSPoErrorAndKeyinDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new WHSPoErrorAndKeyinDAL();
                return instance;
            }
        }
        public WHSPoErrorAndKeyinDAL() { }
        public List<WHS_PO_ERROR_KEYIN> getAllPOError()
        {
            return _entities.WHS_PO_ERROR_KEYIN.ToList();
        }
        public List<WHS_PO_ERROR_KEYIN> getAllPOErrorBySearch(string search)
        {
            return _entities.WHS_PO_ERROR_KEYIN.Where(
                p=>p.PARTSCODE.Contains(search)
                || p.SUPPLIER_CODE.Contains(search)
                || p.PO_NO.Contains(search)
                || p.SUPPLIER_NAME.Contains(search)
                || p.ID.Contains(search)).ToList();
        }
        public bool CheckExistID(string ID)
        {
            var lst = _entities.WHS_PO_ERROR_KEYIN.Where(x => x.ID == ID).ToList();
            if (lst.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Add(WHS_PO_ERROR_KEYIN inputData)
        {
            try
            {
                _entities.WHS_PO_ERROR_KEYIN.Add(inputData);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(WHS_PO_ERROR_KEYIN inputData)
        {

            var _inputData = _entities.WHS_PO_ERROR_KEYIN.Where(p => p.ID == inputData.ID).FirstOrDefault();
            if (_inputData != null)
            {
                try
                {
                    _inputData.ID = inputData.ID;
                    _inputData.DELIVERY_DATE = inputData.DELIVERY_DATE;
                    _inputData.SUPPLIER_CODE = inputData.SUPPLIER_CODE;
                    _inputData.SUPPLIER_NAME = inputData.SUPPLIER_NAME;
                    _inputData.PARTSCODE = inputData.PARTSCODE;
                    _inputData.SANKYU_INVOIE = inputData.SANKYU_INVOIE;
                    _inputData.INVOICE_NO = inputData.INVOICE_NO;
                    _inputData.PO_NO = inputData.PO_NO;
                    _inputData.INVOICE_QTY = inputData.INVOICE_QTY;
                    _inputData.KEYIN_QTY = inputData.KEYIN_QTY;
                    _inputData.NO_KEYIN_QTY = inputData.NO_KEYIN_QTY;
                    _inputData.RESOLVED = inputData.RESOLVED;
                    _inputData.STATUS = inputData.STATUS;
                    _inputData.FINISHED_DATE = inputData.FINISHED_DATE;
                    _inputData.UpdatedDate = inputData.UpdatedDate;
                    _inputData.CreatedBy = inputData.CreatedBy;
                    _entities.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
    }
}
