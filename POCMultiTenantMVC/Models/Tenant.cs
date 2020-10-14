using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POCMultiTenantMVC.Models
{    
    public class Tenant
    {
        public string Value { get; set; }

        public string Description { get; set; }

        public string BackGroundColor { get; set; }

        public string Host { get; set; }
    }
}
