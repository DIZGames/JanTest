using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ITSystem
{
    public class ItemDataBase : ScriptableObject
    {
        [SerializeField] private List<Item> _list;

        public Item getItemByID(int ID) {
            for (int i = 0; i < _list.Count; i++)
            {
                if (ID == _list[i].ID)
                {
                    return _list[i];
                }
            }
            return null;
        }

        public Item getItemByName(string Name) {
            for (int i = 0; i < _list.Count; i++) {
                if (Name == _list[i].Name) {
                    return _list[i];
                }
            }
            return null;
        }

        public Item getItemByIndex(int index) {
            return _list[index];
        }

        public int getCount() {
            return _list.Count;
        }
    }
}
