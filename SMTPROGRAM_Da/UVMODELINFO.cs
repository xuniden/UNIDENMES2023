using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTPROGRAM_Da
{
    
    public class UVMODELINFO
    {
        public UVMODELINFO(int ID, string Model, string BModel, string Lot, int LotSize, string CreatedBy, DateTime CreatedDate, DateTime UpdatedDate)
        {
            this.ID = ID;
            this.Model = Model;
            this.Bmodel = BModel;
            this.Lot = Lot; 
            this.Lotsize= LotSize;
            this.Createdby= CreatedBy;
            this.Createddate= CreatedDate;
            this.Updatedate = UpdatedDate;
        }

        public UVMODELINFO(DataRow row)
        {          
            this.ID = (long)row["ID"];
            this.Model = row["Model"].ToString();
            this.Bmodel = row["BModel"].ToString();
            this.Lot = row["Lot"].ToString();
            this.Lotsize =(int)row["LotSize"];
            this.Createdby = row["CreatedBy"].ToString();
            this.Createddate =DateTime.Parse( row["CreatedDate"].ToString());
            this.Updatedate =DateTime.Parse(row["UpdatedDate"].ToString());
        }


        private DateTime updateddate;
        public DateTime Updatedate
        {
            get { return updateddate; }
            set { updateddate = value; }
        }

        private DateTime createddate;
        public DateTime Createddate
        {
            get { return createddate; }
            set { createddate = value; }
        }

        private string createdby;
        public string Createdby
        {
            get { return createdby; }
            set { createdby = value; }
        }


        private int lotsize;
        public int Lotsize
        {
            get { return lotsize; }
            set { lotsize = value; }
        }


        private string lot;
        public string Lot
        {
            get {return lot; }
            set { lot = value;}
        }

        private string bmodel;

        public string Bmodel
        {
            get { return bmodel; }
            set { bmodel = value; }
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private long iD;

        public long ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
