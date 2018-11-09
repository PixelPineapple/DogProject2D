using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickables : MonoBehaviour
{
    public PickablesData pickablesData;

    public bool isDestroyOnPickUp;

    public void Invoked()
    {
        pickablesData.isPicked = true;
        if (isDestroyOnPickUp) Destroy(gameObject);
    }
}
