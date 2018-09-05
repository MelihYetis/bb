using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("BirAltKategoriler")]
    public class BirAltKategoriler
    {
        [Key]
        public int BirAltKategoriId { get; set; }

        public string BirAltKategoriAdi { get; set; }

        public int UstKategoriId { get; set; }

        public int AltKategoriId { get; set; }
        public string SeoLink { get; set; }

        public int SayfaId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int SiraNo { get; set; }
    }
}
