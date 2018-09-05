using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    public class ViewModelSayfalar
    {
        public int SayfalarMetinId { get; set; }

        public int SayfaId { get; set; }

        public string SayfalarMetinAciklama { get; set; }
        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public string AnahtarKelimeler { get; set; }
    }
}
