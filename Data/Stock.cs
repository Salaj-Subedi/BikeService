using System;
using System.ComponentModel.DataAnnotations;

namespace BikeService.Data
{
    public class Stock
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Please provide the Item name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide the Quantity")]
        public int Quantity { get; set; }
        public string ApprovedBy { get; set; }
        public string TakenBy { get; set; }
        public DateTime LastTaken { get; set; }

    }

}
