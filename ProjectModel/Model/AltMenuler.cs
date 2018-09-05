using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table ("AltMenuler")]
    public class AltMenuler
    {
        [Key]
        public int AltMenuId { get; set; }

        public int MenuId { get; set; }

        public int AltMenuSiraNo { get; set; }

        public string AltMenuAdi { get; set; }

        public int SayfaId { get; set; }

        public int UstKategoriId { get; set; }

        public string LinkAdres { get; set; }

        public string SeoLink { get; set; }
    }
}
