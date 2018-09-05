using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("SayfaNewItemIletisim")]
    public class SayfaNewItemIletisim
    {
        [Key]
        public int SayfaNewItemIletisimId { get; set; }

        public int SayfalarNewItemId { get; set; }

        public string SayfaNewItemIletisimTel { get; set; }

        public string SayfaNewItemIletisimFax { get; set; }

        public string SayfaNewItemIletisimEmail { get; set; }

        public string SayfaNewItemIletisimAdres { get; set; }

        public string SayfaNewItemIletisimMaps { get; set; }

    }
}
