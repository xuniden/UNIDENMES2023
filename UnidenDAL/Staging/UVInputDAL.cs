using Microsoft.SqlServer.Server;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace UnidenDAL.Staging
{
    public class invStock
    {
        public long Stock { get; set; }
    }
    public class lstView
    {
        public string Barcode { get; set; }
        public long InputQty { get; set; }
        public long OutPutQty { get; set; }

    }
    public class InventoryIn
    {
        public string Barcode { get; set; }
        public long sumQtyInput { get; set; }
    }
    public class ViewInputDisplay
    {
        public long ID { get; set; }
        public string Barcode { get; set; }
        public string Loc { get; set; }
        public string LineName { get; set; }
        public string Lot { get; set; }
        public string Model { get; set; }
        public string PeNo { get; set; }
        public string Program { get; set; }
        public string PcbName { get; set; }        
        public int HsQty { get; set; }
        public long sumQtyInput { get; set; }
        public string KeyInPerson { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedDate { get; set; }

    }
    public class InventoryOuputReport
    {
        public string BARCODE { get; set; }
        public string LOCATION { get; set; }
        public string SMT_LINE { get; set; }
        public string LOT { get; set; }
        public string MODEL { get; set; }
        public string PE_NO { get; set; }
        public string PROGRAM { get; set; }
        public string PCB_NAME { get; set; }
        public int HS_QTY { get; set; }
        public int INV_QTY { get; set; }
        public string REMARK { get; set; }
        public string KEY_IN { get; set; }
        public DateTime DATE_TIME { get; set; }
    }
    public class InventoryOut
    {
        public string Barcode { get; set; }
        public long sumQtySCL { get; set; }
    }
    public class GroupByLot
    {
        public string Lot { get; set; }
    }
    public class ViewInput
    {
        public long ID { get; set; }
        public string Barcode { get; set; }
        public string Loc { get; set; }
        public string LineName { get; set; }
        public string Lot { get; set; }
        public string Model { get; set; }
        public string PeNo { get; set; }
        public string Program { get; set; }
        public string PcbName { get; set; }
        public int HsQty { get; set; }
        public int InputQty { get; set; }
        public string KeyInPerson { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedDate { get; set; }

    }
    public class ViewDisplayInv
    {
        public string Barcode { get; set; }
        public string Loc { get; set; }
        public string LineName { get; set; }
        public string Lot { get; set; }
        public string Model { get; set; }
        public string PeNo { get; set; }
        public string Program { get; set; }
        public string PcbName { get; set; }
        public int HsQty { get; set; }
        public long Ivn_Qty { get; set; }
        public string KeyInPerson { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedDate { get; set; }

    }
    public class UVInputDAL
    {
        UVEntities _entities = new UVEntities();
        private static UVInputDAL instance;
        public static UVInputDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new UVInputDAL();
                return instance;
            }
        }
        public UVInputDAL() { }

        //public dfdf()
        //{
        //    var groupByLastNamesQuery =
        //        from a in _entities.UV_STAGING_PCBLIST
        //        group a by a.Lot into newGroup
        //        orderby newGroup.Key
        //        select newGroup;
        //}
        //txtLocation.Text, txtLot.Text, txtModel.Text, txtPeno.Text, txtPcbname.Text, maskedTextBox2.Text

       
        public List<ViewInput> DisplayInputSearch(string location, string lot, string model, string peno, string pcbname, string dates)
        {
            var query = (from a in _entities.UV_STAGING_INPUT
                         select new ViewInput
                         {
                             Barcode = a.Barcode,
                             Loc = a.Location,
                             LineName = a.SmtLine,
                             Lot = a.Lot,
                             Model = a.Model,
                             PeNo = a.PeNo,
                             Program = a.Program,
                             PcbName = a.PcbName,
                             HsQty = a.HsQty,
                             InputQty = a.InputQty,
                             KeyInPerson = a.KeyInPerson,
                             Remark = a.Remark,
                             CreatedDate = a.CreatedDate
                         });
            var result = new List<ViewInput>();
            if (!location.Equals(""))
            {
                query = query.Where(p => p.Loc.Contains(location));
            }
            if (!lot.Equals(""))
            {
                query = query.Where(p => p.Lot.Contains(lot));
            }
            if (!model.Equals(""))
            {
                query = query.Where(p => p.Model.Contains(model));
            }
            if (!peno.Equals(""))
            {
                query = query.Where(p => p.PeNo.Contains(peno));
            }
            if (!pcbname.Equals(""))
            {
                query = query.Where(p => p.PcbName.Contains(pcbname));
            }
            if (dates.Length == 10)
            {
               // DateTime dt = DateTime.ParseExact(dates, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                DateTime d = DateTime.Parse(dates);
                query = query.Where(a => a.CreatedDate.Year == d.Year
                          && a.CreatedDate.Month == d.Month
                          && a.CreatedDate.Day == d.Day);
                         
            }

            return query.ToList();
        }
        public List<ViewDisplayInv> DisplayInventory(string Location, string Lot, string Model, string Peno, string pcbName, string date)
        {
            var result = new List<ViewDisplayInv>();
            var right = (from a in _entities.UV_STAGING_OUTPUT
                                   .GroupBy(l => l.Barcode)
                         select new InventoryOut
                         {
                             Barcode = a.Key,
                             sumQtySCL = (long)a.Sum(c => c.QtySCL)
                         }).AsEnumerable();


            var left = (from b in _entities.UV_STAGING_INPUT
                            .GroupBy(l => l.Barcode)
                        select new InventoryIn
                        {
                            Barcode = b.Key,
                            sumQtyInput = b.Sum(c => c.InputQty)

                        }).AsEnumerable();

            var q = (from a in left
                     join b in right on a.Barcode equals b.Barcode into joinLeft
                     from b2 in joinLeft.DefaultIfEmpty(new InventoryOut())
                     select new lstView
                     {
                         Barcode = a.Barcode,
                         InputQty = a.sumQtyInput,
                         OutPutQty = b2.sumQtySCL
                     }).AsEnumerable();

            var query = (from a in _entities.UV_STAGING_INPUT.ToList()
                         join b in q on a.Barcode equals b.Barcode into g
                         from gg in g.DefaultIfEmpty(new lstView())
                         where gg.InputQty - gg.OutPutQty > 0
                         select new ViewDisplayInv
                         {
                             Barcode = a.Barcode,
                             Loc = a.Location,
                             LineName = a.SmtLine,
                             Lot = a.Lot,
                             Model = a.Model,
                             PeNo = a.PeNo,
                             Program = a.Program,
                             PcbName = a.PcbName,
                             HsQty = a.HsQty,
                             Remark = a.Remark,
                             Ivn_Qty = gg.InputQty - gg.OutPutQty,
                             KeyInPerson = a.KeyInPerson,
                             CreatedDate = a.CreatedDate
                         });

            if (Location != "")
            {
                query = query.Where(p => p.Loc.Contains(Location));
            }
            if (Lot != "")
            {
                query = query.Where(p => p.Lot.Contains(Lot));
            }
            if (Model != "")
            {
                query = query.Where(p => p.Model.Contains(Model));
            }
            if (Peno != "")
            {
                query = query.Where(p => p.PeNo.Contains(Peno));
            }
            if (pcbName != "")
            {
                query = query.Where(p => p.PcbName.Contains(pcbName));
            }
            if (date.Length == 10)
            {
                DateTime d = DateTime.Parse(date);
                query = query.Where(p => p.CreatedDate.Year == d.Year && p.CreatedDate.Month == d.Month && p.CreatedDate.Day == d.Day);
            }
            return query.ToList();

        }

        public long InventoryStock()
        {
            var right = (from a in _entities.UV_STAGING_OUTPUT
                                    .GroupBy(l => l.Barcode)
                         select new InventoryOut
                         {
                             Barcode = a.Key,
                             sumQtySCL =(long) a.Sum(c => c.QtySCL)
                         }).AsEnumerable();


            var left = (from b in _entities.UV_STAGING_INPUT
                            .GroupBy(l => l.Barcode)
                        select new InventoryIn
                        {
                            Barcode = b.Key,
                            sumQtyInput = b.Sum(c => c.InputQty)
                        }).AsEnumerable();

            var q = (from a in left
                     join b in right on a.Barcode equals b.Barcode into joinLeft
                     from b2 in joinLeft.DefaultIfEmpty(new InventoryOut())
                     select new lstView
                     {
                         Barcode = a.Barcode,
                         InputQty = a.sumQtyInput,
                         OutPutQty = b2.sumQtySCL
                     }).AsEnumerable();

            var InQty = (from g in q select (long)(g.InputQty)).DefaultIfEmpty(0).Sum();
            var OutQty = (from g in q select (long)(g.OutPutQty)).DefaultIfEmpty(0).Sum();

            return InQty - OutQty;

        }
        public bool CheckExistBarcode(string barcode)
        {
            var lst = _entities.UV_STAGING_INPUT.Where(p => p.Barcode == barcode).ToList();
            if (lst.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public UV_STAGING_INPUT getInfoByBarcode(string barcode)
        {
            return _entities.UV_STAGING_INPUT.Where(p => p.Barcode == barcode).FirstOrDefault();
        }

        public List<UV_STAGING_INPUT> getAllItemByKeyinPerson(string keyinperson)
        {
            return _entities.UV_STAGING_INPUT.Where(p => p.KeyInPerson == keyinperson).ToList();
        }

        public List<UV_STAGING_INPUT> getAllItemByKeyinPersonCurrentDate(string keyinperson, DateTime dt)
        {
            return _entities.UV_STAGING_INPUT.Where(p => p.KeyInPerson == keyinperson &&
                    (p.CreatedDate.Year == dt.Year && p.CreatedDate.Month == dt.Month && p.CreatedDate.Day == dt.Day)).Take(5000)
                    .OrderByDescending(p => p.CreatedDate).ToList();
        }

        public UV_STAGING_INPUT getInputInfoByID(long ID)
        {
            return _entities.UV_STAGING_INPUT.Where(p => p.ID == ID).FirstOrDefault();
        }


        public bool Add(UV_STAGING_INPUT inputData)
        {
            try
            {
                _entities.UV_STAGING_INPUT.Add(inputData);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(UV_STAGING_INPUT inputData)
        {

            var _inputData = _entities.UV_STAGING_INPUT.Where(p => p.Barcode == inputData.Barcode).FirstOrDefault();
            if (_inputData != null)
            {
                try
                {
                    _inputData.Barcode = inputData.Barcode;
                    _inputData.Lot = inputData.Lot;
                    _inputData.SmtLine = inputData.SmtLine;
                    _inputData.Location = inputData.Location;
                    _inputData.Model = inputData.Model;
                    _inputData.PeNo = inputData.PeNo;
                    _inputData.Program = inputData.Program;
                    _inputData.PcbName = inputData.PcbName;
                    _inputData.HsQty = inputData.HsQty;
                    _inputData.InputQty = inputData.InputQty;
                    _inputData.KeyInPerson = inputData.KeyInPerson;
                    _inputData.Remark = inputData.Remark;
                    _inputData.CreatedDate = inputData.CreatedDate;
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
