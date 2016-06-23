using Assets.ITSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public abstract class Weapon : MonoBehaviour
    {
        public ItemWeapon itemWeapon { get; set; }

        public Transform FirePoint;
    }
}
