using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Light))]
public class SwitchONLantern : MonoBehaviour {
    
    private new Light light;

    private void Awake()
    {
        light = GetComponent<Light>();
    }

    public void SwitchOn()
    {
        if (light == null)
        {
            light = GetComponent<Light>();
        }

        if (!light.isActiveAndEnabled)
        {
            light.enabled = true;
        }
    }
}
