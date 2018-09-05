using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("UrunResimTab")]
    public class UrunResimTab
    {
        [Key]
        public int UrunResimTabId { get; set; }

        public int UrunTabId { get; set; }

        public string UrunResimTabPath { get; set; }

        public string UrunResimTabAciklama { get; set; }

        [NotMapped]
        public string UrunTabBaslik { get; set; }
    }
}
