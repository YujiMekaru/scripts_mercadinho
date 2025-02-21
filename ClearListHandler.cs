using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class ClearListHandler : MonoBehaviour
    {
        public void ClearList()
        {
            foreach (Transform child in this.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
