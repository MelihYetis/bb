using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("SolMenuler")]
    public class SolMenu
    {
        [Key]
        public int SolMenuId { get; set; }

        public int SolMenuSiraNo { get; set; }

        public string SolMenuAdi { get; set; }

        public int SayfaId { get; set; }

        public int UstKategoriId { get; set; }

        public int DosyaId { get; set; }

        public string LinkAdres { get; set; }

        [MaxLength(70)]
        [Index(IsUnique = true)]
        public string SeoLink { get; set; }

        public int SolMenuGrupId { get; set; }
    }
}
