using Assets.Scripts.CorredorScene.CorredorFactory;
using Assets.Scripts.FaseScene;
using Assets.Scripts.Game.Enums;
using Assets.Scripts.Game.Services;
using Assets.Scripts.Game.Services.CorredorFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.CorredorScene
{
    public class OnLoadCorredorSceneHandler : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private GameObject _listGameObject;
        [SerializeField] private GameObject _estanteGameObject;

        private void Start()
        {
            ShoppingListSingleton.GetInstance().LoadShoppingList(_listGameObject);

            var corredorAtual = GameManagerSingleton.GetInstance().CorredorAtual;

            FactoryCorredor corredorFactory = null;

            switch (corredorAtual)
            {
                case CorredorAtualEnum.Padaria:
                    NarrationSystemSingleton.GetInstance().ForcePlayAudio("corredorScenePadaria");
                    corredorFactory = new FactoryCorredorPadaria();
                    break;
                case CorredorAtualEnum.Bebidas:
                    NarrationSystemSingleton.GetInstance().ForcePlayAudio("corredorSceneBebidas");
                    corredorFactory = new FactoryCorredorBebida();
                    break;
                case CorredorAtualEnum.Frutas:
                    NarrationSystemSingleton.GetInstance().ForcePlayAudio("corredorSceneFrutas");
                    corredorFactory = new FactoryCorredorFruta();
                    break;
            }

            var corredor = corredorFactory.CriarCorredor();

            corredor.PrintarTitulo(_title);
            corredor.RenderizarProdutos(_estanteGameObject);

            this.GetComponent<BasketRenderer>().RenderBasket();

        }
    }
}
