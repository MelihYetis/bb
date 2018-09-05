using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("SayfalarNewItem")]
    public class SayfalarNewItem
    {
        [Key]
        public int SayfalarNewItemId { get; set; }

        public int SayfaNewId { get; set; }

        public int SayfaNewItemTip { get; set; }

        public virtual SayfalarNew SayfalarNew {get;set;}

        public string SayfaNewItemBaslik { get; set; }

        public int SayfaItemSiraNo { get; set; }

        public int SayfaItemSatirKolonSayisi { get; set; }

        public string SayfaNewItemArkaPlanRenk { get; set; }
    }
}
