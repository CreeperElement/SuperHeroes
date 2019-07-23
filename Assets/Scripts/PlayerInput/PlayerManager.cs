using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlayerInput
{
    class PlayerManager
    {
        private static PlayerManager manager;

        public int NumPlayers { get; set; }
        public int MaxNumPlayers { get {
                return GameObject.FindGameObjectsWithTag("Player").Count();
        } }

        private PlayerManager()
        {
            NumPlayers = 0;
        }

        public static PlayerManager GetInstance()
        {
            if (manager == null)
                manager = new PlayerManager();
            return manager;
        }
    }
}
