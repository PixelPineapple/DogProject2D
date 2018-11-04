/*---------------------------------------------------
 * 制作日 : 2018年09月26日
 * 制作者：シスワントレサ
 * 内容　：スプライトのポジションを並び替える
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorting : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Renderer>().sortingOrder = (int)(transform.position.y * -10);
	}
}
