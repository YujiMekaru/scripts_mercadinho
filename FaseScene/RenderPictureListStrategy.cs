using Assets.Scripts.Game.Models;
using Assets.Scripts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.FaseScene
{
    public class RenderPictureListStrategy : MonoBehaviour, IRenderListStrategy
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

                GameObject prefabImage = item.Key.Prefab;
                var instanceImage = Instantiate(prefabImage);
                instanceImage.transform.parent = listGameObject.transform;
                instanceImage.transform.localPosition = new Vector3(x_pos + 1.2f, y_pos, 1f);

                y_pos -= 1.4f;
                count++;
            }
        }
    }
}
