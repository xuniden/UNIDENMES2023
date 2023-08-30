using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDAL.Assy;
using UnidenDTO;

namespace UnidenDAL
{
    public class RandomDAL
    {
        private static Random random = new Random();
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        UVEntities _entities = new UVEntities();
        private static RandomDAL instance;
        public static RandomDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new RandomDAL();
                return instance;
            }
        }
        public RandomDAL() { }

        public string GenerateRandomString()
        {
            var yearMonth = CommonDAL.Instance.getSqlServerDatetime().ToString("yyyyMM");
            var str = yearMonth + new string(Enumerable.Repeat(chars, 5)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            if (CheckForDuplicates(str))
            {
                return GenerateRandomString();
            }

            return str;
        }

        private bool CheckForDuplicates(string str)
        {
            // Here you can implement a check to see if the string has already been used.
            // For the sake of simplicity, this example will always return false, meaning that the string is unique.
            return false;
        }
    }
}
