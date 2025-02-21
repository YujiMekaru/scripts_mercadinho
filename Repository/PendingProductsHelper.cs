using Assets.Scripts.Game.Models;
using Assets.Scripts.Game.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Repository
{
    public static class PendingProductsHelper
    {
        public static Dictionary<Product, int> GetPendingProducts()
        {
            var list = ShoppingListSingleton.GetInstance().GetShoppingList();
            var inventory = InventorySingleton.GetInstance().GetInventory();

            foreach (var item in inventory)
            {
                if (list[item.Key] > 0)
                {
                    list[item.Key] -= item.Value.Count();
                }
            }

            return list;
        }

        public static bool HasPendingProducts()
        {
            var list = ShoppingListSingleton.GetInstance().GetShoppingList();
            var inventory = InventorySingleton.GetInstance().GetInventory();

           
            foreach (var item in inventory)
            {
                if (list[item.Key] > 0)
                {
                    list[item.Key] -= item.Value.Count();
                }
            }


            foreach (var item in list)
            {
                if (item.Value > 0)
                    return true;
            }
            return false;
        }
        
    }
}
