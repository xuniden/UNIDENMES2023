using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDAL.Jig;
using UnidenDTO;

namespace UnidenDAL.BoxET
{
    public class Box_ETManagerDAL
    {

        UVEntities _entities = new UVEntities();
        private static Box_ETManagerDAL instance;
        public static Box_ETManagerDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new Box_ETManagerDAL();
                return instance;
            }
        }
        public Box_ETManagerDAL() { }

    }
 }
