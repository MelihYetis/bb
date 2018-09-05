using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("UrunMatchBeden")]
    public class UrunMatchBeden
    {
        [Key]
        public int UrunMatchBedenId { get; set; }
        public int UrunId { get; set; }
        public int BedenId { get; set; }
    }
}
