using Assets.Scripts.Game.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Models
{
    public class Product
    {
        public string Name { get; set; }
        public ProductTypeEnum Type { get; set; }
        public GameObject Prefab { get; set; }
        public string AudioFileName { get; set; }
    }
}
