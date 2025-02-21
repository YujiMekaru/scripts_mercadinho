using Assets.Scripts.Game.Enums;
using Assets.Scripts.Game.Models;
using Assets.Scripts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventorySingleton : Subject
{
    private static InventorySingleton instance;

    private Dictionary<Product, List<Vector3>> inventory;

    private InventorySingleton() 
    { 
        inventory = new Dictionary<Product, List<Vector3>>();

    }

    public static InventorySingleton GetInstance()
    {
        if (instance == null)
        {
            instance = new InventorySingleton();
        }
        return instance;
    }

    public void AddProduct(Vector3 position, Product product)
    {
        if (!inventory.ContainsKey(product))
            inventory.Add(product, new List<Vector3>());
        
        inventory[product].Add(position);

        NotifyObservers();
    }

    public TryAddResponseEnum TryAdd(Vector3 position, Product product)
    {
        var pendingProducts = PendingProductsHelper.GetPendingProducts();

        if (pendingProducts.ContainsKey(product))
        {
            if (pendingProducts[product] > 0)
            {
                AddProduct(position, product);
                return TryAddResponseEnum.Success;
            }
            else
            {
                Debug.Log("EXIBIR MENSAGEM DE ERRO QUE JÁ PEGOU TODOS PRODUTOS");
                return TryAddResponseEnum.EnoughProduct;
            }
        }
        else
            Debug.Log("EXIBIR MENSAGEM DE ERRO QUE ESSE PRODUTO NAO PRECISA");
        return TryAddResponseEnum.WrongProduct;
    }

    public void ResetInventory()
    {
        inventory.Clear();
    }

    public Dictionary<Product, List<Vector3>> GetInventory()
    {
        return new Dictionary<Product, List<Vector3>>(inventory);
    }
}
