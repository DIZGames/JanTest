using Assets.ITSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.EventSystem
{
    public class customEventData
    {
        public int ID;
        public GameObject Sender;
        public Item Item;

        public customEventData()
        {

        }

        public customEventData(Item _Item)
        {
            Item = _Item;
        }

        public customEventData(GameObject _Sender)
        {
            Sender = _Sender;
        }
    }
}
