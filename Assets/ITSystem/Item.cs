using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ITSystem
{
    public class Item : ScriptableObject
    {
        [SerializeField]
        private int _ID;
        [SerializeField]
        private string _Name;
        [SerializeField]
        private TypeItem _Type;
        [SerializeField]
        private Sprite _Icon;
        [SerializeField]
        private int _MaxStack;
        [SerializeField]
        private GameObject _Prefab;
        [SerializeField]
        private int _Stack;

        public int ID
        {
            get { return _ID; }
        }

        public string Name
        {
            get { return _Name; }
        }

        public TypeItem Type
        {
            get { return _Type; }
        }

        public Sprite Icon
        {
            get { return _Icon; }
            set { _Icon = value; }
        }

        public int MaxStack
        {
            get { return _MaxStack; }
        }

        public GameObject Prefab
        {
            get { return _Prefab; }
            set { _Prefab = value; }
        }

        public int Stack
        {
            get { return _Stack; }
            set {
                if (value >= 0) {
                    _Stack = value;
                }
                   
            }
        }

        public Item getCopy()
        {
            return Instantiate(this) as Item;
        }

    }
}
