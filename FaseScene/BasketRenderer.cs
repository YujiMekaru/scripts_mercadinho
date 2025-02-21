using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.FaseScene
{
    public class BasketRenderer : MonoBehaviour
    {
        public void RenderBasket()
        {
            var basket = GameObject.FindGameObjectWithTag("Basket");

            var inventory = InventorySingleton.GetInstance().GetInventory();

            foreach (var keyValue in inventory)
            {
                foreach (var position in keyValue.Value)
                {
                    var newInstance = Instantiate(keyValue.Key.Prefab);
                    newInstance.transform.position = position;
                }
            }

        }
    }
}
