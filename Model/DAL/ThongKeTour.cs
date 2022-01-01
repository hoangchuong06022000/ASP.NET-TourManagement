using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class ThongKeTour
    {
        public List<ModelThongKeTour> ThongKeTourDL()
        {
            DAL_ThongKe TK = new DAL_ThongKe();
            return TK.ThongKeTour();
        }
    }
    public class ModelThongKeTour
    {
        public string MATOUR { get; set; }
        public double TONGTHU { get; set; }
        public int SODOAN { get; set; }

        public string GIATIEN
        {
            get { return DinhDanhTien((double)TONGTHU); }
        }

        public string DinhDanhTien(double Tien)
        {
            return string.Format("{0:#,##0}", Tien);
        }
    }
}
