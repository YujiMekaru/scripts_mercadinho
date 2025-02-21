using Assets.Scripts.Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.FaseScene
{
    public interface IRenderListStrategy
    {
        public void RenderList(GameObject listGameObject);
    }
}
