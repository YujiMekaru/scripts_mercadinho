﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game.Services.CorredorFactory
{
    public abstract class FactoryCorredor
    {
        public abstract ICorredor CriarCorredor();
    }
}
