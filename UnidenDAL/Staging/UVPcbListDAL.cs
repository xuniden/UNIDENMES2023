using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Staging
{
    public class LotGroup
    {
        public string Lot { get; set; }
    }
    public class pcbNameView
    {
        public string pcbName { get; set; }
    }
    public class PeNoView
    {
        public string Model { get; set; }
        public string PeNo { get; set; }
        public int HsQty { get; set; }
    }
    public class UVPcbListDAL
    {
        UVEntities _entities = new UVEntities();
        private static UVPcbListDAL instance;
        public static UVPcbListDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new UVPcbListDAL();
                return instance;
            }
        }
        public UVPcbListDAL() { }

        public List<PeNoView> PeNo { get; set; }
        public List<LotGroup> getLotGroupBy()
        {
            return (from a in _entities.UV_STAGING_PCBLIST
                    group a.Lot by a.Lot into NewGroup
                    orderby NewGroup.Key
                    select new LotGroup
                    {
                        Lot = NewGroup.Key
                    }).ToList();
        }
        public List<UV_STAGING_PCBLIST> getAllPcbList()
        {
            return _entities.UV_STAGING_PCBLIST.Take(1000).ToList();
        }
        public UV_STAGING_PCBLIST getDataByLot(string lot)
        {
            return _entities.UV_STAGING_PCBLIST.Where(p => p.Lot == lot).FirstOrDefault();

        }

        public void RemoveDuplicateRow()
        {
            _entities.sp_STAGING_RemoveDuplicateRow();
        }
        public List<PeNoView> getAllPeNoByLot(string Lot)
        {
            return (from a in _entities.Staging_PcbList_GetAllByLot(Lot)
                    select new PeNoView
                    {
                        Model = a.Model,
                        PeNo = a.PENO,
                        HsQty = int.Parse(a.HsQty.ToString())
                    }).ToList();
        }
        public List<pcbNameView> getAllPcbNameByLot(string Lot, string peno)
        {
            return (from a in _entities.UV_STAGING_PCBLIST.Where(p => p.Desciption.StartsWith("PCB:")
                    && p.Lot == Lot
                    && (p.Parts.Substring(1, 2) + p.Parts.Substring(4, 6)) == peno
                    )
                    group a.Desciption.Substring(4, a.Desciption.Length - 4) by a.Desciption.Substring(4, a.Desciption.Length - 4) into newGroup
                    orderby newGroup.Key
                    select new pcbNameView
                    {
                        pcbName = newGroup.Key
                    }).ToList();



        }

        public List<UV_STAGING_PCBLIST> getAllPcbList(string search)
        {
            return _entities.UV_STAGING_PCBLIST.Where(p => p.Lot.Contains(search) || p.Model.Contains(search)
                    || p.BModel.Contains(search)
                    || p.Assy.Contains(search)
                    || p.Parts.Contains(search)
                    || p.Desciption.Contains(search)
                    || p.Spec.Contains(search)
                    ).ToList();
        }
        public bool RemoveProdLine(long Id)
        {
            var pcbList = new UV_STAGING_PCBLIST();
            pcbList = _entities.UV_STAGING_PCBLIST.Where(p => p.ID == Id).FirstOrDefault();
            if (pcbList != null)
            {
                _entities.UV_STAGING_PCBLIST.Remove(pcbList);
                _entities.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool Add(UV_STAGING_PCBLIST pcbList)
        {
            try
            {
                _entities.UV_STAGING_PCBLIST.Add(pcbList);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool checkExistImport(UV_STAGING_PCBLIST pcbList)
        {
            var query = _entities.UV_STAGING_PCBLIST.Where
                (p => p.Lot.ToUpper() == pcbList.Lot.ToUpper()
                && p.Model.ToUpper() == pcbList.Model.ToUpper()
                && p.BModel.ToUpper() == pcbList.BModel.ToUpper()
                && p.Assy.ToUpper() == pcbList.Assy.ToUpper()
                && p.Parts.ToUpper() == pcbList.Parts.ToUpper()
                && p.Desciption.ToUpper() == pcbList.Desciption.ToUpper()
                && p.Spec.ToUpper() == pcbList.Spec.ToUpper()
                ).ToList();
            if (query.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        public bool Update(UV_STAGING_PCBLIST pcbList)
        {

            var _pcbList = _entities.UV_STAGING_PCBLIST.Where(p => p.ID == pcbList.ID).FirstOrDefault();
            if (_pcbList != null)
            {
                try
                {
                    _pcbList.Lot = pcbList.Lot;
                    _pcbList.Model = pcbList.Model;
                    _pcbList.BModel = pcbList.BModel;
                    _pcbList.Assy = pcbList.Assy;
                    _pcbList.Parts = pcbList.Parts;
                    _pcbList.Desciption = pcbList.Desciption;
                    _pcbList.Spec = pcbList.Spec;
                    _pcbList.CreatedDate = pcbList.CreatedDate;
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
