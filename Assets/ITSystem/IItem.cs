using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ITSystem
{
    public interface IItem
    {
        int ID { get; }
        string Name { get; }
        TypeItem Type { get; }
        int Stack { get; set; }
        int MaxStack { get; }
        GameObject Prefab { get; set; }
        Sprite Icon { get; set; }
    }
}
