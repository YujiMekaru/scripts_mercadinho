using Assets.Scripts.Game.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Repository
{
    public static class PrefabHelper
    {
        public static GameObject ToNumberPrefab(this int number)
        {
            string path = "Prefabs/icon-correct";
            switch (number)
            {
                case 1: path = "Prefabs/number1"; break;
                case 2: path = "Prefabs/number2"; break;
                case 3: path = "Prefabs/number3"; break;
                case 4: path = "Prefabs/number4"; break;
            }
            return Resources.Load<GameObject>(path);
        }

        public static string ToAudioFileName(this int number)
        {
            string result = "um";
            switch (number)
            {
                case 1: result = "um"; break;
                case 2: result = "dois"; break;
                case 3: result = "três"; break;
                case 4: result = "quatro"; break;
            }

            return result;
        }

        public static GameObject GetDialogPrefab(TryAddResponseEnum responseEnum)
        {
            string path = "Prefabs/icon-correct";
            switch (responseEnum)
            {
                case TryAddResponseEnum.Success:
                    path = "Prefabs/balao-sucesso";
                    break;
                case TryAddResponseEnum.WrongProduct:
                    path = "Prefabs/balao-nao-lista";
                    break;
                case TryAddResponseEnum.EnoughProduct:
                    path = "Prefabs/balao-full";
                    break;
            }
            return Resources.Load<GameObject>(path);
        }

        public static GameObject GetCanvasListPrefab()
        {
            return Resources.Load<GameObject>("Prefabs/canvas-lista");
        }
    }
}
