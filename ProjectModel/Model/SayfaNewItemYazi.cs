using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("SayfaNewYazi")]
    public class SayfaNewItemYazi
    {
        [Key]
        public int SayfaNewItemYaziId { get; set; }

        public int YaziKategoriId { get; set; }

        public string SayfaNewItemYaziAciklama { get; set; }

        public int SayfalarNewItemId { get; set; }
    }
}
