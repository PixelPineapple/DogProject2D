/*---------------------------------------------------
 * 制作日 : 2018年10月29日
 * 制作者：シスワントレサ
 * 内容　：プレイヤの頭の上にあるX-ボタンを表示
 * 最後の更新：2018年10月29日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CircleCollider2D))]
public class ShowXButton : MonoBehaviour {

    private CircleCollider2D circleCollider;

    [SerializeField]
    private GameObject xButton;

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = 1.19f;
        circleCollider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            xButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            xButton.SetActive(false);
        }
    }
}
