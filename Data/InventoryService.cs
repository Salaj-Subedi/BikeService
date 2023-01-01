using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace BikeService.Data;

public static class InventoryService
{
    private static void SaveAll(Guid userId, List<Inventory> items)
    {
        string appDataDirectoryPath = Utils.GetAppDirectoryPath();
        string itemsFilePath = Utils.GetItemsFilePath();

        if (!Directory.Exists(appDataDirectoryPath))
        {
            Directory.CreateDirectory(appDataDirectoryPath);
        }
        
        var json = JsonSerializer.Serialize(items);
        File.WriteAllText(itemsFilePath, json);
    }
    public static List<Inventory> GetAll(Guid userId)
    {
        string itemsFilePath = Utils.GetItemsFilePath();
        if (!File.Exists(itemsFilePath))
        {
            return new List<Inventory>();
        }
        var json = File.ReadAllText(itemsFilePath);

        return JsonSerializer.Deserialize<List<Inventory>>(json);
    }
    public static List<Inventory> Create(Guid userId, string ItemName, int Quantity, DateTime LastTaken)
    {
        

        List<Inventory> items = GetAll(userId);
        items.Add(new Inventory
        {
            ItemName=ItemName,
            Quantity=Quantity,  
            LastTaken = LastTaken,
        });
        SaveAll(userId, items);
        return items;
    }
    public static List<Inventory> Delete(Guid userId, Guid id)
    {
        List<Inventory> items = GetAll(userId);
        Inventory item = items.FirstOrDefault(x => x.Id == id);

        if (item == null)
        {
            throw new Exception("Stock not found.");
        }

        items.Remove(item);
        SaveAll(userId, items);
        return items;
    }
    public static void DeleteByUserId(Guid userId)
    {
        string itemsFilePath = Utils.GetItemsFilePath();
        if (File.Exists(itemsFilePath))
        {
            File.Delete(itemsFilePath);
        }
    }

    public static List<Inventory> Update(Guid userId, Guid id, string ItemName, int quantitytaken,bool isApproved)
    {
        List<Inventory> items = GetAll(userId);
        Inventory itemToUpdate = items.FirstOrDefault(x => x.Id == id);

        if (itemToUpdate == null)
        {
            throw new Exception("Stock not found.");
        }

        itemToUpdate.ItemName = ItemName;
        itemToUpdate.Quantity -= quantitytaken;
        itemToUpdate.IsApproved = isApproved;
        itemToUpdate.LastTaken = DateTime.Now;
        itemToUpdate.TakenBy = userId;
        itemToUpdate.ApprovedBy = userId;
        SaveAll(userId,items);
        return items;
    }
}
