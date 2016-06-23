using Assets.EventSystem;
using Assets.ITSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts {
    public class Human : MonoBehaviour {

        protected ItemHuman itemHuman;

        private ItemClothing[] CharacterSlots = new ItemClothing[3];

        public void UpdateAttributes(Item _item) {
            ItemClothing itemClothing = (ItemClothing)_item;

            if (itemClothing.TypeClothing == TypeClothing.Head) {
                CharacterSlots[0] = itemClothing;
            }
            if (itemClothing.TypeClothing == TypeClothing.Body) {
                CharacterSlots[1] = itemClothing;
            }
            if (itemClothing.TypeClothing == TypeClothing.Mod1) {
                CharacterSlots[2] = itemClothing;
            }
            if (itemClothing.TypeClothing == TypeClothing.Mod2) {
                CharacterSlots[3] = itemClothing;
            }

            ItemHuman itemHuman = new ItemHuman();

            itemHuman.Health += itemClothing.Health;
            itemHuman.Armor += itemClothing.Armor;
            itemHuman.Energy += itemClothing.Energy;
            itemHuman.Oxygen += itemClothing.Oxygen;

            //EventManager.Instance.TriggerEvent(EventIdentifier.RefreshPlayInfo, new customEventData(itemHuman));
        }
    }
    
}
