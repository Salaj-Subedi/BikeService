using System;
using System.ComponentModel.DataAnnotations;

namespace BikeService.Data;

public class Inventory
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int ItemId { get; set; }
    [Required(ErrorMessage = "Please provide the Item name.")]
    public string ItemName { get; set; }
    [Required(ErrorMessage = "Please provide the Quantity")]
    public int Quantity { get; set; }
    public Guid ApprovedBy { get; set; }
    public Guid TakenBy { get; set; }
    public bool IsApproved { get; set; }
    public DateTime? LastTaken { get; set; }
}
   
