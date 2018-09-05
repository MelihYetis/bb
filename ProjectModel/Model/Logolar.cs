using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table ("Logolar")]
    public class Logolar
    {
        [Key]
        public int LogoId { get; set; }

        public byte[] LogoImageByte { get; set; }

        public string LogoImagePath { get; set; }
    }
}
