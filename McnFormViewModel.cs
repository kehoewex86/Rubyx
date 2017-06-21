using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Rubyx.Models;

namespace Rubyx.ViewModels
{
    public class McnFormViewModel
    {
        public BidstonHwrc BidstonHwrc { get; set; }

        [Display(Name = "Waste Type")]
        public IEnumerable<WasteType> WasteType { get; set; }
        public IEnumerable<Destination> Destination { get; set; }

        [Display(Name = "User")]
        public IEnumerable<StaffMember> StaffMember { get; set; }

    }
}
