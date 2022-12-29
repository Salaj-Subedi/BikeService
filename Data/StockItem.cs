using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeService.Data
{
    public class StockItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        
        public string ApprovedBy { get; set; }
        public string TakenBy { get; set; }

        public StockItem(string name, int quantity, string approvedBy, string takenBy)
        {
            Name = name;
            Quantity = quantity;
            
            ApprovedBy = approvedBy;
            TakenBy = takenBy;
        }
    }
}
