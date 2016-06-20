using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ITSystem
{
    public class ItemAmmo : Item
    {
        [SerializeField]
        private int _ClipSize;
        [SerializeField]
        private int _Damage;

        public int ClipSize
        {
            get { return _ClipSize; }
            set { _ClipSize = value; }
        }

        public int Damage
        {
            get { return _Damage; }
            set { _Damage = value; }
        }
    }
}
