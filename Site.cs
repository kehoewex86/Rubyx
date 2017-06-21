using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Rubyx.Models
{
    public class Site
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SitePrefix { get; set; }
    }
}
