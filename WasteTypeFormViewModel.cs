using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rubyx.Models;

namespace Rubyx.ViewModels
{
    public class WasteTypeFormViewModel
    {
        public WasteType WasteType { get; set; }
        public IEnumerable<EwcCode> EwcCode { get; set; }
    }
}
