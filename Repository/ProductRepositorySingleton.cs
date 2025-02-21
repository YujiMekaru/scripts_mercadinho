using Assets.Scripts.Game.Enums;
using Assets.Scripts.Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Repository
{
    public class ProductRepositorySingleton
    {
        private static ProductRepositorySingleton instance;

        private List<Product> products;

        private ProductRepositorySingleton() 
        {
            products = new List<Product>();
            PopulateRepository();
        }

        public static ProductRepositorySingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new ProductRepositorySingleton();
            }
            return instance;
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public List<Product> GetBakeryProducts()
        { 
            return products.Where(p => p.Type == ProductTypeEnum.Bakery).ToList();
        }

        public List<Product> GetBeverageProducts()
        {
            return products.Where(p => p.Type == ProductTypeEnum.Beverage).ToList();
        }

        public List<Product> GetFruitVegetablesProducts()
        {
            return products.Where(p => p.Type == ProductTypeEnum.FruitVegetable).ToList();
        }

        public Product GetProductByName(string name)
        {
            name = name.Replace("(Clone)", "");
            return products.Where(p => p.Name == name).FirstOrDefault();
        }

        public Dictionary<Product, int> GetRandomProducts(int productCount, int productMaxQty)
        {
            if (productCount > products.Count)
                throw new ArgumentException("productCount parameter must be lower than Products on Repository.");

            if (productCount == 0)
                throw new ArgumentException("productCount parameter must be higher than 0");

            if (productMaxQty == 0)
                throw new ArgumentException("productMaxQty parameter must be higher than 0");

            var result = new Dictionary<Product, int>();

            int i = 0;
            do
            {
                System.Random r = new System.Random();

                int index = r.Next(0, (products.Count - 1));
                int qty = r.Next(1, productMaxQty);

                Product product = products[index];
                if (!result.ContainsKey(product))
                {
                    result.Add(product, qty);
                    i++;
                }
            }
            while (i < productCount);

            return result;
        }

        private void PopulateRepository()
        {
            this.products.Add(new Product
            {
                Name = "Maçã",
                Type = ProductTypeEnum.FruitVegetable,
                Prefab = Resources.Load<GameObject>("Prefabs/fruta-maca"),
                AudioFileName = "maca"
            });
            this.products.Add(new Product
            {
                Name = "Abacaxi",
                Type = ProductTypeEnum.FruitVegetable,
                Prefab = Resources.Load<GameObject>("Prefabs/fruta-abacaxi"),
                AudioFileName = "abacaxi"
            });
            this.products.Add(new Product
            {
                Name = "Banana",
                Type = ProductTypeEnum.FruitVegetable,
                Prefab = Resources.Load<GameObject>("Prefabs/fruta-banana"),
                AudioFileName = "banana"
            });
            this.products.Add(new Product
            {
                Name = "Cenoura",
                Type = ProductTypeEnum.FruitVegetable,
                Prefab = Resources.Load<GameObject>("Prefabs/fruta-cenoura"),
                AudioFileName = "cenoura"
            });
            this.products.Add(new Product
            {
                Name = "Melancia",
                Type = ProductTypeEnum.FruitVegetable,
                Prefab = Resources.Load<GameObject>("Prefabs/fruta-melancia"),
                AudioFileName = "melancia"
            });
            this.products.Add(new Product
            {
                Name = "Uva",
                Type = ProductTypeEnum.FruitVegetable,
                Prefab = Resources.Load<GameObject>("Prefabs/fruta-uva"),
                AudioFileName = "uva"
            });


            this.products.Add(new Product
            {
                Name = "Baguete",
                Type = ProductTypeEnum.Bakery,
                Prefab = Resources.Load<GameObject>("Prefabs/padaria-baguete"),
                AudioFileName = "baguete"
            });

            this.products.Add(new Product
            {
                Name = "Bolo",
                Type = ProductTypeEnum.Bakery,
                Prefab = Resources.Load<GameObject>("Prefabs/padaria-bolo"),
                AudioFileName = "bolo"
            });

            this.products.Add(new Product
            {
                Name = "Rosquinha",
                Type = ProductTypeEnum.Bakery,
                Prefab = Resources.Load<GameObject>("Prefabs/padaria-donut"),
                AudioFileName = "rosquinha"
            });

            this.products.Add(new Product
            {
                Name = "Pão de Forma",
                Type = ProductTypeEnum.Bakery,
                Prefab = Resources.Load<GameObject>("Prefabs/padaria-paoforma"),
                AudioFileName = "paoDeForma"
            });

            this.products.Add(new Product
            {
                Name = "Pão de Queijo",
                Type = ProductTypeEnum.Bakery,
                Prefab = Resources.Load<GameObject>("Prefabs/padaria-paoqueijo"),
                AudioFileName = "paoDeQueijo"
            });

            this.products.Add(new Product
            {
                Name = "Torta",
                Type = ProductTypeEnum.Bakery,
                Prefab = Resources.Load<GameObject>("Prefabs/padaria-torta"),
                AudioFileName = "torta"
            });


            this.products.Add(new Product
            {
                Name = "Agua",
                Type = ProductTypeEnum.Beverage,
                Prefab = Resources.Load<GameObject>("Prefabs/bebida-agua"),
                AudioFileName = "agua"
            });
            this.products.Add(new Product
            {
                Name = "Suco",
                Type = ProductTypeEnum.Beverage,
                Prefab = Resources.Load<GameObject>("Prefabs/bebida-suco"),
                AudioFileName = "suco"
            });
            this.products.Add(new Product
            {
                Name = "Leite",
                Type = ProductTypeEnum.Beverage,
                Prefab = Resources.Load<GameObject>("Prefabs/bebida-leite"),
                AudioFileName = "leite"
            });
            this.products.Add(new Product
            {
                Name = "Refrigerante",
                Type = ProductTypeEnum.Beverage,
                Prefab = Resources.Load<GameObject>("Prefabs/bebida-refrigerante"),
                AudioFileName = "refrigerante"
            });
        }
    }
}
