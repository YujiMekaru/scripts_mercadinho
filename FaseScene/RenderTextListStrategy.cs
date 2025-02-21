using Assets.Scripts.Game.Models;
using Assets.Scripts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.FaseScene
{
    public class RenderTextListStrategy : MonoBehaviour, IRenderListStrategy
    {
        public void RenderList(GameObject listGameObject)
        {
            var list = PendingProductsHelper.GetPendingProducts();

            int count = 0;

            float y_pos = 1.8f;
            float x_pos = -1.64f;


            foreach (var item in list)
            {
                GameObject prefabNumber = item.Value.ToNumberPrefab();
                var instanceNumber = Instantiate(prefabNumber);
                instanceNumber.transform.parent = listGameObject.transform;
                instanceNumber.transform.localPosition = new Vector3(x_pos, y_pos, 1f);

                GameObject canvasPrefab = PrefabHelper.GetCanvasListPrefab();
                var instanceCanvas = Instantiate(canvasPrefab);
                Canvas canvas = instanceCanvas.GetComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                Camera mainCamera = Camera.main;
                canvas.worldCamera = mainCamera;

                Transform textTransform = instanceCanvas.transform.Find("texto1");
                var textComponent = textTransform.GetComponent<TMP_Text>();
                textComponent.text = item.Key.Name;

                textTransform.position = new Vector3(instanceNumber.transform.position.x + 3, instanceNumber.transform.position.y, 1f);

                Debug.Log("-----------");
                Debug.Log(instanceNumber.transform.position.ToString());
                Debug.Log(textTransform.position.ToString());
                Debug.Log(instanceCanvas.transform.position.ToString());
                Debug.Log("-----------");

                y_pos -= 1.4f;
                count++;
            }
        }
    }
}
