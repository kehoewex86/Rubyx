using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Rubyx.Models;
using System.Threading.Tasks;

namespace Rubyx.Dtos
{
    public class BidstonHwrcDto
    {
        public int Id { get; set; }

        public int McnId { get; set; }

        //Display the full MCN Number
        public string McnNumber
        {
            get { return "508/" + McnId; }
        }

        public DateTime DateEntered { get; set; } = DateTime.Now;


        //Waste Types
        
        [Required]
        public int WasteTypeId { get; set; } //entity framework treats this as a foreign Key to match the above membership type to customer

        public WasteTypeDto WasteType { get; set; }


        //Destinations

        [Required]
        public int DestinationId { get; set; } //entity framework treats this as a foreign Key to match the above membership type to customer

        public DestinationDto Destination { get; set; }

        //Registration

        public string Registration { get; set; }



        //Staff Members

        [Required]
        public int StaffMemberId { get; set; } //entity framework treats this as a foreign Key to match the above membership type to customer

        public StaffMemberDto StaffMember { get; set; }


        public string DriverName { get; set; }

        public string Comments { get; set; }


        public int? Quantity { get; set; }



        public double? Tonnage { get; set; }


    }
}
