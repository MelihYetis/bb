using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("AltSolMenuler")]
    public class AltSolMenuler
    {
        [Key]
        public int AltSolMenuId { get; set; }

        public int SolMenuId { get; set; }

        public int AltSolMenuSiraNo { get; set; }

        public string AltSolMenuAdi { get; set; }

        public int SayfaId { get; set; }

        public int UstKategoriId { get; set; }

        public string LinkAdres { get; set; }
    }
}
