using Assets.Scripts.FaseScene;
using Assets.Scripts.Game.Enums;
using Assets.Scripts.Game.Models;
using Assets.Scripts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Services
{
    public class ShoppingListSingleton
    {
        private static ShoppingListSingleton instance;

        private Dictionary<Product, int> _shoppingListDict;

        private ShoppingListSingleton() 
        {
            _shoppingListDict = new Dictionary<Product, int>();
        }

        public static ShoppingListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new ShoppingListSingleton();
            }
            return instance;
        }

        public void SetupList(int productCount, int productMaxQty)
        {
            _shoppingListDict = ProductRepositorySingleton.GetInstance().GetRandomProducts(productCount, productMaxQty);
        }

        public Dictionary<Product, int> GetShoppingList()
        {
            return new Dictionary<Product, int>(_shoppingListDict);
        }

        public void LoadShoppingList(GameObject listComponent)
        {
            ListRendererSingleton listRenderer = ListRendererSingleton.GetInstance();
            var difficulty = GameManagerSingleton.GetInstance().Difficulty;
            switch (difficulty)
            {
                default:
                case GameDifficultyEnum.Easy:
                    listRenderer.SetRenderListStrategy(
                        (
                            new GameObject("RenderPictureListStrategy")
                                .AddComponent<RenderPictureListStrategy>())
                        );
                    break;
                case GameDifficultyEnum.Medium:
                    listRenderer.SetRenderListStrategy(
                        (
                            new GameObject("RenderTextListStrategy")
                                .AddComponent<RenderTextListStrategy>())
                        );
                    break;
            }

            listRenderer.RenderList(listComponent);
        }
    }
}
