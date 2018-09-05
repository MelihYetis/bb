using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("UrunTab")]
    public class UrunTab
    {
        [Key]
        public int UrunTabId { get; set; }

        public int UrunId { get; set; }

        public string UrunTabBaslik { get; set; }

        public int UrunTabTip { get; set; }
    }
}
