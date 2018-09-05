using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table ("Dosyalar")]
    public class Dosyalar
    {
        [Key]
        public int DosyaId { get; set; }

        public byte[] DosyaByte { get; set; }

        public string DosyaAdi { get; set; }

        public string DosyaPath { get; set; }
    }
}
