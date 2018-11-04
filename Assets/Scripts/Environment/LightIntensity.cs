using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour {

    [SerializeField]
    private float lampIntensity = 0;

    public void Invoked()
    {
        gameObject.GetComponent<Light>().intensity = lampIntensity;
    }
}
