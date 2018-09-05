using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("PopUp")]
    public class Popup
    {
        [Key]
        public int PopupId { get; set; }

        public bool AktifPasif { get; set; }
        public string PopupResimPath { get; set; }

        public string PopupLink { get; set; }
    }
}
