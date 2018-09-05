using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;



namespace ProjectModel.Model
{
    public class Test
    {
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string DetayD{ get; set; }

        public int TestId { get; set; }

        public string TestAdi { get; set; }

        [MaxLength(70)]
        [Index(IsUnique = true)]
        public string SeoLink { get; set; }
    }


}
