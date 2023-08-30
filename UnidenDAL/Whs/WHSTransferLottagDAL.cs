using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.whs
{
    public class DWHSLottagIQC
    {
        public string ID { get; set; }
        public DateTime Whs_Lottag_Iqc_Date { get; set; }
        public string Whs_Position { get; set; }
        public string WhsCreatedBy { get; set; }
        public DateTime WhsCreatedDate { get; set; }
        public DateTime WhsUpdatedDate { get; set; }
    }
    public class DIQCLottag
    {
        public string ID { get; set; }
        public string Iqc_Lottag_Status { get; set; }
        public Nullable<DateTime> Iqc_Lottag_Date { get; set; }
        public string IQCCreatedBy { get; set; }
        public Nullable<DateTime> IQCCreatedDate { get; set; }
        public Nullable<DateTime> IQCUpdatedDate { get; set; }
    }
    public class DIQCLottagResult
    {
        public string ID { get; set; }
        public string Iqc_Check_Status { get; set; }
        public Nullable<DateTime> Iqc_Check_Date { get; set; }
        public string Iqc_Check_Checker { get; set; }
        public string IQCCreatedByCheck { get; set; }
        public DateTime IQCCreatedDateCheck { get; set; }
        public DateTime IQCUpdatedDateCheck { get; set; }
    }

    public class DWhsIn
    {
        public string ID { get; set; }
        public string WhsInBy { get; set; }
        public Nullable<DateTime> WhsInDate { get; set; }
        public string WhsInCreatedBy { get; set; }
        public DateTime WhsInCreatedDate { get; set; }
        public DateTime WhsInUpdatedDate { get; set; }
    }
    public class WHSTransferLottagDAL
    {
        UVEntities _entities = new UVEntities();
        private static WHSTransferLottagDAL instance;
        public static WHSTransferLottagDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new WHSTransferLottagDAL();
                return instance;
            }
        }
        public WHSTransferLottagDAL() { }
        public WHS_TRANSFER_LOTTAG getRecordInfo(string ID)
        {
            return _entities.WHS_TRANSFER_LOTTAG.Where(p => p.ID == ID).FirstOrDefault();
        }
        public List<DWhsIn> getAllWhsIn(string search)
        {
            return (from a in _entities.WHS_TRANSFER_LOTTAG.Where(
                p => p.ID.Contains(search)
                || p.Iqc_Check_Checker.Contains(search)
                )
                    select new DWhsIn
                    {
                        ID = a.ID,
                        WhsInBy = a.Whs_In_By,
                        WhsInDate = a.Whs_In_Date,
                        WhsInCreatedBy = a.Whs_In_CreatedBy,
                        WhsInCreatedDate = (DateTime)a.Whs_In_CreatedDate,
                        WhsInUpdatedDate = (DateTime)a.Whs_In_UpdatedDate,
                    }).Take(1000).ToList();
        }
        public List<DWhsIn> getAllWhsIn()
        {
            return (from a in _entities.WHS_TRANSFER_LOTTAG.Where(p => p.Whs_In_CreatedDate != null).OrderByDescending(p => p.Whs_In_CreatedDate).Take(5000)
                    select new DWhsIn
                    {
                        ID = a.ID,
                        WhsInBy = a.Whs_In_By,
                        WhsInDate = a.Whs_In_Date,
                        WhsInCreatedBy = a.Whs_In_CreatedBy,
                        WhsInCreatedDate = (DateTime)a.Whs_In_CreatedDate,
                        WhsInUpdatedDate = (DateTime)a.Whs_In_UpdatedDate,
                    }).Take(1000).ToList();
        }
        public List<DIQCLottagResult> getAllIqcLottagResult(string search)
        {
            return (from a in _entities.WHS_TRANSFER_LOTTAG.Where(
                p => p.ID.Contains(search)
                || p.Iqc_Check_Checker.Contains(search)
                )
                    select new DIQCLottagResult
                    {
                        ID = a.ID,
                        Iqc_Check_Status = a.Iqc_Check_Status,
                        Iqc_Check_Date = a.Iqc_Check_Date,
                        Iqc_Check_Checker = a.Iqc_Check_Checker,
                        IQCCreatedByCheck = a.Iqc_Check_CreatedBy,
                        IQCCreatedDateCheck = (DateTime)a.Iqc_Check_CreatedDate,
                        IQCUpdatedDateCheck = (DateTime)a.Iqc_Check_UpdatedDate
                    }).Take(1000).ToList();
        }
        public List<DIQCLottagResult> getAllIqcLottagResult()
        {
            DateTime dt = CommonDAL.Instance.getSqlServerDatetime();
            return (from a in _entities.WHS_TRANSFER_LOTTAG.Where(p => p.Iqc_Check_CreatedDate != null).OrderByDescending(p => p.Iqc_Check_CreatedDate).Take(5000)
                    select new DIQCLottagResult
                    {
                        ID = a.ID,
                        Iqc_Check_Status = a.Iqc_Check_Status,
                        Iqc_Check_Date = a.Iqc_Check_Date,
                        Iqc_Check_Checker = a.Iqc_Check_Checker,
                        IQCCreatedByCheck = a.Iqc_Check_CreatedBy,
                        IQCCreatedDateCheck = (DateTime)a.Iqc_Check_CreatedDate,
                        IQCUpdatedDateCheck = (DateTime)a.Iqc_Check_UpdatedDate
                    }).Take(1000).ToList();
        }
        public List<DIQCLottag> getAllIqcLottag(string search)
        {
            return (from a in _entities.WHS_TRANSFER_LOTTAG.Where(
                p => p.ID.Contains(search)
                )
                    select new DIQCLottag
                    {
                        ID = a.ID,
                        Iqc_Lottag_Status = a.Iqc_Lottag_Status,
                        Iqc_Lottag_Date = a.Iqc_Lottag_Date,
                        IQCCreatedBy = a.Iqc_CreatedBy,
                        IQCCreatedDate = (DateTime)a.Iqc_CreatedDate,
                        IQCUpdatedDate = (DateTime)a.Iqc_UpdateDate
                    }).Take(1000).ToList();
        }
        public List<DIQCLottag> getAllIqcLottag()
        {
            return (from a in _entities.WHS_TRANSFER_LOTTAG.Where(p => p.Iqc_CreatedDate != null).OrderByDescending(p => p.Iqc_CreatedDate).Take(5000)
                    select new DIQCLottag
                    {
                        ID = a.ID,
                        Iqc_Lottag_Status = a.Iqc_Lottag_Status,
                        Iqc_Lottag_Date = a.Iqc_Lottag_Date,
                        IQCCreatedBy = a.Iqc_CreatedBy,
                        IQCCreatedDate = (DateTime)a.Iqc_CreatedDate,
                        IQCUpdatedDate = (DateTime)a.Iqc_UpdateDate
                    }).Take(1000).ToList();
        }
        public List<DWHSLottagIQC> getAllWhsLottagIQC(string search)
        {
            return (from a in _entities.WHS_TRANSFER_LOTTAG.Where(
                p => p.ID.Contains(search)
                || p.Whs_Position.Contains(search)
                )
                    select new DWHSLottagIQC
                    {
                        ID = a.ID,
                        Whs_Lottag_Iqc_Date = (DateTime)a.Whs_Lottag_Iqc_Date,
                        Whs_Position = a.Whs_Position,
                        WhsCreatedBy = a.Whs_CreatedBy,
                        WhsCreatedDate = (DateTime)a.Whs_CreatedDate,
                        WhsUpdatedDate = (DateTime)a.Whs_UpdateDate
                    }).Take(1000).ToList();
        }
        public List<DWHSLottagIQC> getAllWhsLottagIQC()
        {
            return (from a in _entities.WHS_TRANSFER_LOTTAG.OrderByDescending(p => p.Whs_CreatedDate).Take(5000)
                    select new DWHSLottagIQC
                    {
                        ID = a.ID,
                        Whs_Lottag_Iqc_Date = (DateTime)a.Whs_Lottag_Iqc_Date,
                        Whs_Position = a.Whs_Position,
                        WhsCreatedBy = a.Whs_CreatedBy,
                        WhsCreatedDate = (DateTime)a.Whs_CreatedDate,
                        WhsUpdatedDate = (DateTime)a.Whs_UpdateDate
                    }).ToList();
        }
        public bool checkParentID(string ID)
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
        public bool CheckExistID(string ID)
        {
            var lst = _entities.WHS_TRANSFER_LOTTAG.Where(x => x.ID == ID).ToList();
            if (lst.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Add(WHS_TRANSFER_LOTTAG inputData)
        {
            try
            {
                _entities.WHS_TRANSFER_LOTTAG.Add(inputData);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(WHS_TRANSFER_LOTTAG inputData, int step, int check)
        {

            var _inputData = _entities.WHS_TRANSFER_LOTTAG.Where(p => p.ID == inputData.ID).FirstOrDefault();
            if (_inputData != null)
            {
                try
                {
                    _inputData.ID = inputData.ID;
                    if (step == 0)
                    {
                        _inputData.Whs_Lottag_Iqc_Date = inputData.Whs_Lottag_Iqc_Date;
                        _inputData.Whs_Position = inputData.Whs_Position;
                        _inputData.Whs_CreatedBy = inputData.Whs_CreatedBy;
                        _inputData.Whs_UpdateDate = inputData.Whs_UpdateDate;
                    }
                    if (step == 1)
                    {
                        _inputData.Iqc_Lottag_Status = inputData.Iqc_Lottag_Status;
                        _inputData.Iqc_Lottag_Date = inputData.Iqc_Lottag_Date;
                        _inputData.Iqc_CreatedBy = inputData.Iqc_CreatedBy;
                        if (check == 1)
                        {
                            _inputData.Iqc_CreatedDate = inputData.Iqc_CreatedDate;
                        }
                        _inputData.Iqc_UpdateDate = inputData.Iqc_UpdateDate;
                    }
                    if (step == 2)
                    {


                        _inputData.Iqc_Check_Status = inputData.Iqc_Check_Status;
                        _inputData.Iqc_Check_Date = inputData.Iqc_Check_Date;
                        _inputData.Iqc_Check_Checker = inputData.Iqc_Check_Checker;
                        _inputData.Iqc_Check_CreatedBy = inputData.Iqc_Check_CreatedBy;
                        if (check == 2)
                        {
                            _inputData.Iqc_Check_CreatedDate = inputData.Iqc_Check_CreatedDate;
                        }
                        _inputData.Iqc_Check_UpdatedDate = inputData.Iqc_Check_UpdatedDate;
                    }
                    if (step == 3)
                    {


                        _inputData.Whs_In_By = inputData.Whs_In_By;
                        _inputData.Whs_In_Date = inputData.Whs_In_Date;
                        _inputData.Whs_In_CreatedBy = inputData.Whs_In_CreatedBy;
                        if (check == 3)
                        {
                            _inputData.Whs_In_CreatedDate = inputData.Whs_In_CreatedDate;
                        }
                        _inputData.Whs_In_UpdatedDate = inputData.Whs_In_UpdatedDate;
                    }
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
