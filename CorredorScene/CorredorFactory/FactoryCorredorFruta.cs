using Assets.Scripts.Game.Services.CorredorFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CorredorScene.CorredorFactory
{
    public class FactoryCorredorFruta : FactoryCorredor
    {
        public override ICorredor CriarCorredor()
        {
            return new GameObject("CorredorFruta").AddComponent<CorredorFruta>();
        }
    }
}
