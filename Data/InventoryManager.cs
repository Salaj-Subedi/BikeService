using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeService.Data
{
    public class InventoryManager
    {
        private List<StockItem> stock;
        private List<User> users;
        private TimeSlot timeSlot;

        public InventoryManager(List<StockItem> stock, List<User> users, TimeSlot timeSlot)
        {
            this.stock = stock;
            this.users = users;
            this.timeSlot = timeSlot;
        }

        public bool IsStaff(User user)
        {
            // Check if the user is a staff member
            return user.IsStaff;
        }

        public bool IsWithinTimeSlot()
        {
            // Check if the current time is within the time slot
            return timeSlot.IsWithinTimeSlot(DateTime.Now);
        }

        public bool AddItemToStock(StockItem item)
        {
            // Check if the current time is within a valid time slot
            if (!IsWithinTimeSlot())
            {
                return false;
            }

            // Add the item to the stock
            stock.Add(item);
            return true;
        }

        public bool RemoveItemFromStock(StockItem item)
        {
            // Check if the current time is within a valid time slot
            if (!IsWithinTimeSlot())
            {
                return false;
            }

            // Remove the item from the stock
            return stock.Remove(item);
        }

        public bool IsAdmin(User user)
        {
            // Check if the user is an admin
            return user.IsAdmin;
        }

        public bool ApproveRequest(StockItem item, User user)
        {
            // Check if the current user is the admin
            if (!IsAdmin(user))
            {
                return false;
            }

            // Approve the request and update the item's ApprovedBy property
            item.ApprovedBy = user.Name;
            return true;
        }

        public bool DenyRequest(StockItem item, User user)
        {
            // Check if the current user is the admin
            if (!IsAdmin(user))
            {
                return false;
            }

            // Deny the request and update the item's ApprovedBy property
            item.ApprovedBy = null;
            return true;
        }
    }
}
