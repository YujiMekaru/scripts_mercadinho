using Assets.Scripts.Game.Interfaces;
using Assets.Scripts.Game.Models;
using Assets.Scripts.Game.Services;
using Assets.Scripts.Game.Services.CorredorFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.FaseScene
{
    public class ListRendererSingleton : ICustomObserver
    {
        private static ListRendererSingleton _instance;

        private IRenderListStrategy _renderListStrategy;

        private ListRendererSingleton()
        { 
        }

        public static ListRendererSingleton GetInstance()
        {
            if (_instance == null)
            {
                Debug.Log("RODOU UM START");
                _instance = new ListRendererSingleton();
                InventorySingleton.GetInstance().AddObserver(_instance);
            }
            return _instance;
        }

        public void SetRenderListStrategy(IRenderListStrategy renderListStrategy)
        {
            this._renderListStrategy = renderListStrategy;
        }

        public void RenderList(GameObject listGameObject)
        {
            listGameObject.GetComponent<ClearListHandler>().ClearList();
            _renderListStrategy.RenderList(listGameObject);
        }

        public void OnNotify()
        {
            var list = GameObject.FindGameObjectWithTag("Lista");
            list.GetComponent<ClearListHandler>().ClearList();
            RenderList(list);
        }
    }
}
