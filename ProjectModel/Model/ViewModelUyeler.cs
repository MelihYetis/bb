using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    public class ViewModelUyeler
    {
        public int UyeId { get; set; }

        
        public string UyeAdi { get; set; }
        
        public string UyeSoyadi { get; set; }


        public string UyeTelNo { get; set; }

        public int UyeSehirId { get; set; }

        public int UyeIlceId { get; set; }

        public string UyeAdres { get; set; }

        
        public string UyeEmail { get; set; }
        

        public string UyePassword { get; set; }
        
        public string ReUyePassword { get; set; }

        public int IlId { get; set; }

        public string IlAdi { get; set; }

        public int IlceId { get; set; }

        public string IlceAdi { get; set; }

        public bool UyeOnay { get; set; }
    }
}
