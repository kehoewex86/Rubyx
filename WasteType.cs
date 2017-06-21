using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Rubyx.Models
{
    public class WasteType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]  //overriding convention
        public string Name { get; set; }
        
        
        public virtual EwcCode EwcCode { get; set; } //navigation property
        
        [Display(Name = "EWC Code")]
        public virtual int EwcCodeId { get; set; } //entity framework treats this as a foreign Key to match the above membership type to customer

    }
}
