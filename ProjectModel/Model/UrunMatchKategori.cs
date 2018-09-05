using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("UrunMatchKategori")]
    public class UrunMatchKategori
    {
        [Key]
        public int UrunMatchKategoriId { get; set; }

        public int UrunId { get; set; }

        public int UstKategoriId { get; set; }

        public int AltKategoriId { get; set; }

        public int BirAltKategoriId { get; set; }
    }
}
