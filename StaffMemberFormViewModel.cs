using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rubyx.Models;

namespace Rubyx.ViewModels
{
    public class StaffMemberFormViewModel
    {
        public StaffMember StaffMember { get; set; }
        public IEnumerable<Site> Site { get; set; }
    }
}
