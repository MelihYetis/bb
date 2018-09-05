using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    public class ViewModelMenuler
    {
        public int MenuId { get; set; }

        public int MenuSiraNo { get; set; }

        public string MenuAdi { get; set; }

        public int SayfaId { get; set; }

        public int AltMenuId { get; set; }

        public int AltMenuSiraNo { get; set; }

        public string AltMenuAdi { get; set; }

        public int BirAltMenuId { get; set; }

        public string BirAltMenuAdi { get; set; }
    }
}
