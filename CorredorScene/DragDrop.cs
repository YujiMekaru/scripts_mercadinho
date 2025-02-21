using Assets.Scripts.Game.Services;
using Assets.Scripts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.SecaoScene
{
    public class DragDrop : MonoBehaviour
    {
        private bool dragging = false;
        private Vector3 offset;
        private Vector3 startPosition;
        private bool insideBasket = false; // Indica se o objeto está dentro da cesta
        private Transform insideBasketPosition; // Armazena a posição final se estiver na cesta
        private GameObject prateleira;
        private GameObject clone;

        private bool placedOnBasket;

        void Start()
        {
            startPosition = transform.position;
            prateleira = GameObject.FindGameObjectWithTag("Prateleira");
            placedOnBasket = false;
        }

        void Update()
        {
            if (dragging)
            {
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            }
        }

        private void OnMouseDown()
        {
            if (clone == null)
            {
                clone = Instantiate(gameObject, startPosition, Quaternion.identity);
                clone.name = clone.name.Replace("(Clone)", "").Trim();
                clone.transform.SetParent(prateleira.transform, true);
            }

            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragging = true;
        }

        private void OnMouseUp()
        {
            dragging = false;
            if (!placedOnBasket)
            {
                if (insideBasket && insideBasketPosition != null)
                {
                    var product = ProductRepositorySingleton.GetInstance().GetProductByName(name);
                    var result = InventorySingleton.GetInstance().TryAdd(this.transform.position, product);

                    var oldDialog = GameObject.FindGameObjectWithTag("Dialog");
                    
                    if (oldDialog != null)
                        Destroy(oldDialog);

                    var messageDialog = Instantiate(PrefabHelper.GetDialogPrefab(result));
                    messageDialog.name = "dialog";
                    Destroy(messageDialog, 3);

                    if (result == Game.Enums.TryAddResponseEnum.WrongProduct || result == Game.Enums.TryAddResponseEnum.EnoughProduct)
                    {
                        transform.position = startPosition; // Volta para a posição inicial se não estiver na cesta
                        Destroy(clone);
                        GameManagerSingleton.GetInstance().AddWrongInteraction();
                        return;
                    }

                    placedOnBasket = true;
                    startPosition = transform.position;
                    GameManagerSingleton.GetInstance().AddCorrectInteraction();
                }
                else
                {
                    transform.position = startPosition; // Volta para a posição inicial se não estiver na cesta
                    Destroy(clone);
                }
            }
            else
            {
                if (insideBasket)
                    startPosition = transform.position;
                else
                    transform.position = startPosition;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Basket"))
            { // Verifica se tocou na cesta
                insideBasket = true;
                insideBasketPosition = other.transform;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Basket"))
            { // Se sair da cesta, reseta o estado
                insideBasket = false;
                insideBasketPosition = null;
            }
        }
    }
}
