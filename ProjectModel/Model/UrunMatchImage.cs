using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("UrunMatchImage")]
    public class UrunMatchImage
    {
        [Key]
        public int UrunMatchImageId { get; set; }

        public int UrunId { get; set; }

        public byte[] UrunResimImageByte { get; set; }

        public string UrunResimImagePath { get; set; }
    }
}
