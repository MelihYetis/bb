using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("Beden")]
    public class Beden
    {
        [Key]
        public int BedenId { get; set; }

        public string BedenAciklama { get; set; }
    }
}
