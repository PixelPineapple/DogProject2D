using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPickablesData : MonoBehaviour {

    [SerializeField]
    Inventory inventory;

    // Use this for initialization
    private void OnApplicationQuit()
    {
        ResetAllPickablesData();
    }

    public void ResetAllPickablesData()
    {
        foreach (var x in inventory.playerInventory)
        {
            x.isPicked = false;
        }
    }
}
