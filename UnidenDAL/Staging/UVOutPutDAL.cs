using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Staging
{
    public class ViewOuput
    {
        //public long ID { get; set; }
        public string Barcode { get; set; }
        public int QtySMT { get; set; }
        public int QtySCL { get; set; }
        public string ToLine { get; set; }
        public string Model { get; set; }
        public string Program { get; set; }
        public string ChangeTargetLot { get; set; }
        public string PENO { get; set; }
        public string PcbName { get; set; }
        public string Remark { get; set; }
        public string KeyInPerson { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class UVOutPutDAL
    {
        UVEntities _entities = new UVEntities();
        private static UVOutPutDAL instance;
        public static UVOutPutDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new UVOutPutDAL();
                return instance;
            }
        }
        public UVOutPutDAL() { }

        public List<ViewOuput> DisplayOutPutSearch(string toline, string changelot, string dates)
        {
            var query = (from a in _entities.UV_STAGING_OUTPUT
                         join b in _entities.UV_STAGING_INPUT
                         on a.Barcode equals b.Barcode
                         select new ViewOuput
                         {
                             Barcode = a.Barcode,
                             QtySMT = (int)a.QtySMT,
                             QtySCL = (int)a.QtySCL,
                             ToLine = a.ToLine,
                             Model=b.Model,
                             Program=b.Program,
                             ChangeTargetLot = a.ChangeTargetLot,
                             PENO=b.PeNo,
                             PcbName=b.PcbName,
                             KeyInPerson = a.KeyInPerson,
                             Remark = a.Remark,
                             CreatedDate = (DateTime)a.CreatedDate
                         });
            var result = new List<ViewOuput>();
            if (!toline.Equals(""))
            {
                query = query.Where(a => a.ToLine.Contains(toline));
            }
            if (!changelot.Equals(""))
            {
                query = query.Where(a => a.ChangeTargetLot.Contains(changelot));
            }
            if (dates.Trim().Length ==10)
            {
                //DateTime dt = DateTime.ParseExact(dates, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                DateTime dt = DateTime.Parse(dates);

                query = query.Where
                          (a => a.CreatedDate.Year == dt.Year
                          && a.CreatedDate.Month == dt.Month
                          && a.CreatedDate.Day == dt.Day);
            }

            return query.ToList();
        }
        public long QtyInventory(string barcode)
        {
            long output = 0;
            long input = 0;
            output =(long) _entities.UV_STAGING_OUTPUT.Where(p => p.Barcode == barcode)
                .Select(p => p.QtySCL)
                .DefaultIfEmpty(0)
                .Sum();
            input = _entities.UV_STAGING_INPUT.Where(p => p.Barcode == barcode)
                .Select(p => p.InputQty)
                .DefaultIfEmpty(0)
                .Sum();
            return input - output;
        }
        public List<ViewOuput> getAllOutPutByBarcode(string barcode)
        {
            return (from a in _entities.UV_STAGING_OUTPUT.Where(p => p.Barcode == barcode)
                    join b in _entities.UV_STAGING_INPUT
                    on a.Barcode equals b.Barcode
                    select new ViewOuput
                    {
                        Barcode = a.Barcode,
                        QtySMT = (int)a.QtySMT,
                        QtySCL = (int)a.QtySCL,
                        ToLine = a.ToLine,
                        Model = b.Model,
                        Program = b.Program,
                        ChangeTargetLot = a.ChangeTargetLot,
                        PENO = b.PeNo,
                        PcbName = b.PcbName,
                        Remark = a.Remark,
                        KeyInPerson = a.KeyInPerson,
                        CreatedDate = (DateTime)a.CreatedDate
                    }).ToList();
        }
        public long totalOutByBarcode(string barcode)
        {
            return (long) _entities.UV_STAGING_OUTPUT.Where(p => p.Barcode == barcode)
                .Select(p => p.QtySCL)
                .DefaultIfEmpty(0)
                .Sum();

        }
        public List<ViewOuput> getAllItemByKeyinPersonCurrentDate(string keyinperson, DateTime dt)
        {
            return (from a in _entities.UV_STAGING_OUTPUT.Where(p => p.KeyInPerson == keyinperson
                    && (p.CreatedDate.Year == dt.Year && p.CreatedDate.Month == dt.Month && p.CreatedDate.Day == dt.Day))
                    join b in _entities.UV_STAGING_INPUT
                    on a.Barcode equals b.Barcode
                    select new ViewOuput
                    {                        
                        Barcode = a.Barcode,
                        QtySMT = a.QtySMT,
                        QtySCL = a.QtySCL,
                        ToLine = a.ToLine,
                        Model = b.Model,
                        Program=b.Program,
                        ChangeTargetLot = a.ChangeTargetLot,
                        PENO = b.PeNo,
                        PcbName = b.PcbName,
                        Remark = a.Remark,
                        KeyInPerson = a.KeyInPerson,
                        CreatedDate = a.CreatedDate
                    }).Take(500).ToList();

        }
        public bool Add(UV_STAGING_OUTPUT ouputData)
        {
            try
            {
                _entities.UV_STAGING_OUTPUT.Add(ouputData);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(UV_STAGING_OUTPUT ouputData)
        {

            var _ouputData = _entities.UV_STAGING_OUTPUT.Where(p => p.ID == ouputData.ID).FirstOrDefault();
            if (_ouputData != null)
            {
                try
                {
                    _ouputData.ID = ouputData.ID;
                    _ouputData.Barcode = ouputData.Barcode;
                    _ouputData.QtySMT = ouputData.QtySMT;
                    _ouputData.QtySCL = ouputData.QtySCL;
                    _ouputData.ToLine = ouputData.ToLine;
                    _ouputData.ChangeTargetLot = ouputData.ChangeTargetLot;
                    _ouputData.Remark = ouputData.Remark;
                    _ouputData.KeyInPerson = ouputData.KeyInPerson;
                    _ouputData.Remark = ouputData.Remark;
                    _ouputData.CreatedDate = ouputData.CreatedDate;
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
