using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);	
	}
}
