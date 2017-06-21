using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Rubyx.Models
{
    public class StaffMember
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        public Site Site { get; set; } //navigation property

        [Display(Name = "Staff Member")]
        public int SiteId { get; set; }
    }
}
