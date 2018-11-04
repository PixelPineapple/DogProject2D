using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateInventoryData : MonoBehaviour {

    public PickablesData pickableData;

    public void UpdateInventory()
    {
        if (pickableData.isPicked)
        {
            gameObject.GetComponent<Image>().enabled = true;
        }
    }
}
