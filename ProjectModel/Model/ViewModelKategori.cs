using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjectModel.Model
{
    public class ViewModelKategori
    {
        public int UstKategoriId { get; set; }

        public string UstKategoriAdi { get; set; }

        public int AltKategoriId { get; set; }

        public string AltKategoriAdi { get; set; }

        public int BirAltKategoriId { get; set; }

        public string BirAltKategoriAdi { get; set; }

        [NotMapped]
        public List<SelectListItem> KategoriList { get; set; }

        public int UrunMatchKategoriId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
