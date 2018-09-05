using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("SlideShow")]
    public class SlideShow
    {
        [Key]
        public int SlideShowId { get; set; }

        public int SayfalarNewItemId { get; set; }
        public string SlideShowResimPath { get; set; }
    }
}
