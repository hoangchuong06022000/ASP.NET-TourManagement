using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class Tool
    {
        public string next_ma1(List<int> ma)
        {
            int[] hashmap = new int[ma.Count + 107];
            foreach (int a in ma)
            {
                if (a <= ma.Count)
                {
                    hashmap[a] = 1;
                }
            }
            int res = 1;
            while (hashmap[res] == 1)
            {
                res++;
            }
            string nextma = res.ToString();
            while (nextma.Length < 3)
            {
                nextma = "0" + nextma;
            }
            return nextma;
        }
        public string next_ma2(List<int> ma)
        {
            int[] hashmap = new int[ma.Count + 107];
            foreach (int a in ma)
            {
                if (a <= ma.Count)
                {
                    hashmap[a] = 1;
                }
            }
            int res = 1;
            while (hashmap[res] == 1)
            {
                res++;
            }
            string nextma = res.ToString();
            while (nextma.Length < 2)
            {
                nextma = "0" + nextma;
            }
            return nextma;
        }
        public string next_maTour(List<string> ma)
        {
            List<int> int_ma = new List<int>();
            foreach (string i in ma)
            {
                int_ma.Add(int.Parse(i.Substring(1)));
            }
            return "T" + next_ma1(int_ma);
        }
        public string next_maDiaDiem(List<string> ma)
        {
            List<int> int_ma = new List<int>();
            foreach (string i in ma)
            {
                int_ma.Add(int.Parse(i.Substring(1)));
            }
            return "D" + next_ma1(int_ma);
        }
        public string next_maNV(List<string> ma)
        {
            List<int> int_ma = new List<int>();
            foreach (string i in ma)
            {
                int_ma.Add(int.Parse(i.Substring(2)));
            }
            return "NV" + next_ma2(int_ma);
        }
        public string next_maLH(List<string> ma)
        {
            List<int> int_ma = new List<int>();
            foreach (string i in ma)
            {
                int_ma.Add(int.Parse(i.Substring(2)));
            }
            return "LH" + next_ma2(int_ma);
        }
        public string next_maGiaTour(List<string> ma)
        {
            List<int> int_ma = new List<int>();
            foreach (string i in ma)
            {
                int_ma.Add(int.Parse(i.Substring(2)));
            }
            return "GT" + next_ma2(int_ma);
        }
        public string next_maDoan(List<string> ma)
        {
            List<int> int_ma = new List<int>();
            foreach (string i in ma)
            {
                int_ma.Add(int.Parse(i.Substring(2)));
            }
            return "DO" + next_ma2(int_ma);
        }
        public string next_maKH(List<string> ma)
        {
            List<int> int_ma = new List<int>();
            foreach (string i in ma)
            {
                int_ma.Add(int.Parse(i.Substring(2)));
            }
            return "KH" + next_ma2(int_ma);
        }
        public string next_maChiPhi(List<string> ma)
        {
            List<int> int_ma = new List<int>();
            foreach (string i in ma)
            {
                int_ma.Add(int.Parse(i.Substring(2)));
            }
            return "CP" + next_ma2(int_ma);
        }
    }
}
