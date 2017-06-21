using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Rubyx.Models
{
    public class ClatterbridgeHwrc
    {
        public int Id { get; set; }
        public int sitePrefix { get; set; }

        [Required]
        public DateTime DateEntered { get; set; }
    }
}
