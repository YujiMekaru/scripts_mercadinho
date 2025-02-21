using Assets.Scripts.Repository;
using Assets.Scripts.SecaoScene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Game.Services.CorredorFactory
{
    public class CorredorBebida : MonoBehaviour, ICorredor
    {
        public void PrintarTitulo(TMP_Text componenteTitulo)
        {
            componenteTitulo.text = "Bebidas";
        }

        public void RenderizarProdutos(GameObject componentePrateleira)
        {
            var products = ProductRepositorySingleton.GetInstance().GetBeverageProducts();
            int productsPerRow = products.Count() / 2;

            float y_position = 1.16f;

            for (int qtdPrateleira = 0; qtdPrateleira < 2; qtdPrateleira++)
            {
                float x_position = -1.75f;

                for (int i = 0; i < productsPerRow; i++)
                {
                    var prefabInstance = Instantiate(products[0].Prefab);
                    prefabInstance.name = products[0].Name;
                    prefabInstance.AddComponent<DragDrop>();
                    prefabInstance.transform.parent = componentePrateleira.transform;
                    prefabInstance.transform.localPosition = new Vector3(x_position + (2 * i), y_position + (-2.4f * qtdPrateleira));
                    products.RemoveAt(0);
                }
            }
        }
    }
}
