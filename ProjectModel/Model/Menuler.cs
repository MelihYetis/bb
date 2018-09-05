using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("Menuler")]
    public class Menuler
    {
        [Key]
        public int MenuId { get; set; }

        public int MenuSiraNo { get; set; }

        public string MenuAdi { get; set; }

        public int SayfaId { get; set; }

        public int UstKategoriId { get; set; }

        public int DosyaId { get; set; }

        public string LinkAdres { get; set; }

        [MaxLength(70)]
        
        public string SeoLink { get; set; }
    }
}
