using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickables : MonoBehaviour
{
    public PickablesData pickablesData;

    public void Invoked()
    {
        pickablesData.isPicked = true;
        Destroy(gameObject);
    }
}
