using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject {

    public List<PickablesData> playerInventory = new List<PickablesData>();

    //public Dictionary<GameObject, bool> playerInventory = new Dictionary<GameObject, bool>();
}
