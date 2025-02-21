using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Services.CorredorFactory
{
    public class FactoryCorredorBebida : FactoryCorredor
    {
        public override ICorredor CriarCorredor()
        {
            return new GameObject("CorredorBebida").AddComponent<CorredorBebida>();
        }
    }
}
