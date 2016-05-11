using UnityEngine;
using System.Collections;

public interface InventoryInterface {

    void add(Item item);
    void delete(Item item);
    void addById(int itemID);
}
