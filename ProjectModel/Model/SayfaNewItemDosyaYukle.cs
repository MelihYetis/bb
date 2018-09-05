using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("SayfaNewItemDosyaYukle")]
    public class SayfaNewItemDosyaYukle
    {
        [Key]
        public int SayfaNewItemDosyaYukleId { get; set; }

        public int SayfalarNewItemId { get; set; }
        
    }
}
