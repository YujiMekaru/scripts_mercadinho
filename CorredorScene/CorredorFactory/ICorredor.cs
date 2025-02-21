using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Game.Services.CorredorFactory
{
    public interface ICorredor
    {
        public void PrintarTitulo(TMP_Text componenteTitulo);
        public void RenderizarProdutos(GameObject componentePrateleira);
    }
}
