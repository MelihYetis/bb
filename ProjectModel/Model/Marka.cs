using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("v_marka")]
    public class Marka
    {
        [Key]
        public int SATIRID { get; set; }
        public string ACIKLAMA { get; set; }
    }
}
