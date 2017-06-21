using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Rubyx.Models;
using System.Threading.Tasks;

namespace Rubyx.Models
{
    public class BidstonHwrc
    {   
        public int Id { get; set; }

        public int McnId { get; set; }

        //Display the full MCN Number
        [Display(Name = "MCN No.")]
        public string McnNumber
        {
            get { return "508/" + McnId; }
        }

        [Display(Name = "Date")]
        public DateTime DateEntered { get; set; } = DateTime.Now;

        
        //Waste Types

        public WasteType WasteType { get; set; } //navigation property

        [Required]
        [Display(Name = "Waste Type")]
        public int WasteTypeId { get; set; } //entity framework treats this as a foreign Key to match the above membership type to customer

        //Destinations

        public Destination Destination { get; set; } //navigation property

        [Required]
        [Display(Name = "Destination")]
        public int DestinationId { get; set; } //entity framework treats this as a foreign Key to match the above membership type to customer

        

        //Registration
        [Display(Name = "Vehicle Registration")]
        public string Registration { get; set; }

        

        //Staff Members

        public StaffMember StaffMember { get; set; } //navigation property

        [Required]
        [Display(Name = "User")]
        public int StaffMemberId { get; set; } //entity framework treats this as a foreign Key to match the above membership type to customer

        [Display(Name = "Driver Name")]
        public string DriverName { get; set; }

        public string Comments { get; set; }

        [Display(Prompt = "If Applicable")]
        public int? Quantity { get; set; }



        public double? Tonnage { get; set; }



    }
}
