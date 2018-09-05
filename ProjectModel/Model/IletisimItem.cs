using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("IletisimItem")]
    public class IletisimItem
    {
        [Key]
        public int IletsimItemId { get; set; }

        public int SayfaId { get; set; }

        public string IletisimTel { get; set; }

        public string IletisimFax { get; set; }

        public string IletisimEmail { get; set; }

        public string IletisimAdres { get; set; }

        public string IletisimKısaBilgi { get; set; }

        public string IletisimKisaAciklama { get; set; }

        public string IletisimGoogleMaps { get; set; }

        public string ProfilAdi { get; set; }
    }
}
