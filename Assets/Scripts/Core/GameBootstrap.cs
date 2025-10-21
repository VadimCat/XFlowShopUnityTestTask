using System;
using UnityEngine;

namespace Core
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private Bootstrap[] bootstraps = Array.Empty<Bootstrap>();

        private void Awake()
        {
            foreach (var init in bootstraps)
            {
                init.Initialize();
            }
        }
    }
}