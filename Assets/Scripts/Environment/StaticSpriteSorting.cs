﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class StaticSpriteSorting : MonoBehaviour {
    void Update()
    {
        gameObject.GetComponent<Renderer>().sortingOrder = (int)(transform.position.y * -10);
    }
}