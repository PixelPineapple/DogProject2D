using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBoundaries : MonoBehaviour {

    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;

    // Update is called once per frame
	void Update () {
        Player._instance.transform.position = new Vector3(
            Mathf.Clamp(Player._instance.transform.position.x, minX, maxX),
            Mathf.Clamp(Player._instance.transform.position.y, minY, maxY),
            0);
	}
}
