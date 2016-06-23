using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ITSystem {
    public class ItemTool : Item{

        [SerializeField]
        private int _BulletSpeed;
        [SerializeField]
        private int _FireRate;
        [SerializeField]
        private ItemAmmo _Ammo;
        [SerializeField]
        private int _Loaded;
        [SerializeField]
        private int _Stock;

        public ItemAmmo Ammo {
            get { return _Ammo; }
            set { _Ammo = value; }
        }

        public int BulletSpeed {
            get { return _BulletSpeed; }
            set { _BulletSpeed = value; }
        }

        public int FireRate {
            get { return _FireRate; }
            set { _FireRate = value; }
        }

        public int Loaded {
            get { return _Loaded; }
            set { _Loaded = value; }
        }

        public int Stock {
            get { return _Stock; }
            set {
                if (value >= 0) {
                    _Stock = value;
                }
            }
        }
    }
}
