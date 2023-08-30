using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDAL.Staging;
using UnidenDTO;

namespace UnidenDAL.whs
{
    public class PrintNoIqc
    {
        public string ID { get; set; }
        public string SK_INVOICE { get; set; }
        public DateTime? RECEIVED_DATE { get; set; }
        public string SUPPLIER_INVOICE { get; set; }
        public string SUPPLIER { get; set; }
        public string SUPPLIER_CODE { get; set; }
        public string SUPPLIER_GROUP { get; set; }
        public string PARTS_CODE { get; set; }
        public string PARTS_DESC { get; set; }
        public string PARTS_SPEC { get; set; }
        public string PURCHASE_ORDER { get; set; }
        public long QTY { get; set; }
        public string VLOCATION { get; set; }
        public string IQC_STATUS { get; set; }
        public long ONHAND { get; set; }
        public DateTime? USE_DATE { get; set; }
        public string LOT_NO { get; set; }
        public string REMARK { get; set; }
        public string NGUOIPHUTRACH { get; set; }
    }

        public class WHSReceivingInputDAL
    {
        UVEntities _entities = new UVEntities();
        private static WHSReceivingInputDAL instance;
        public static WHSReceivingInputDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new WHSReceivingInputDAL();
                return instance;
            }
        }
        public WHSReceivingInputDAL() { }
        public List<WHS_RECEIVING_INPUT> getAllInput(string search)
        {
            return _entities.WHS_RECEIVING_INPUT.Where(
                p => p.ID.Contains(search)
                || p.SK_INVOICE.Contains(search)
                || p.SUPPLIER_INVOICE.Contains(search)
                || p.SUPPLIER.Contains(search)
                || p.SUPPLIER_CODE.Contains(search)
                || p.SUPPLIER_GROUP.Contains(search)
                || p.PARTS_CODE.Contains(search)
                || p.PARTS_DESC.Contains(search)
                || p.PARTS_SPEC.Contains(search)
                || p.PURCHASE_ORDER.Contains(search)
                || p.VLOCATION.Contains(search)
                || p.LOT_NO.Contains(search)
                || p.REMARK.Contains(search)
                ).Take(1000).ToList();
        }
        public List<WHS_RECEIVING_INPUT> getAllInput()
        {
            return _entities.WHS_RECEIVING_INPUT.OrderByDescending(p => p.CreatedDate).Take(5000).ToList();
        }
        public bool CheckExistID(string ID)
        {
            var lst = _entities.WHS_RECEIVING_INPUT.Where(x => x.ID == ID).ToList();
            if (lst.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Add(WHS_RECEIVING_INPUT inputData)
        {
            try
            {
                _entities.WHS_RECEIVING_INPUT.Add(inputData);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(WHS_RECEIVING_INPUT inputData)
        {

            var _inputData = _entities.WHS_RECEIVING_INPUT.Where(p => p.ID == inputData.ID).FirstOrDefault();
            if (_inputData != null)
            {
                try
                {
                    _inputData.ID = inputData.ID;
                    _inputData.SK_INVOICE = inputData.SK_INVOICE;
                    _inputData.RECEIVED_DATE = inputData.RECEIVED_DATE;
                    _inputData.SUPPLIER_INVOICE = inputData.SUPPLIER_INVOICE;
                    _inputData.SUPPLIER = inputData.SUPPLIER;
                    _inputData.SUPPLIER_CODE = inputData.SUPPLIER_CODE;
                    _inputData.SUPPLIER_GROUP = inputData.SUPPLIER_GROUP;
                    _inputData.PARTS_CODE = inputData.PARTS_CODE;
                    _inputData.PARTS_DESC = inputData.PARTS_DESC;
                    _inputData.PARTS_SPEC = inputData.PARTS_SPEC;
                    _inputData.PURCHASE_ORDER = inputData.PURCHASE_ORDER;
                    _inputData.VLOCATION = inputData.VLOCATION;
                    _inputData.IQC_STATUS = inputData.IQC_STATUS;
                    _inputData.ONHAND = inputData.ONHAND;
                    _inputData.USE_DATE = inputData.USE_DATE;
                    _inputData.LOT_NO = inputData.LOT_NO;
                    _inputData.REMARK = inputData.REMARK;
                    //  _inputData.CreatedDate = inputData.CreatedDate;
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
