using Assets.Scripts.CorredorScene.CorredorFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Services.CorredorFactory
{
    public class FactoryCorredorPadaria : FactoryCorredor
    {
        public override ICorredor CriarCorredor()
        {
            return new GameObject("CorredorPadaria").AddComponent<CorredorPadaria>();
        }
    }
}
