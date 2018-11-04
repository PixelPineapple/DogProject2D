/*---------------------------------------------------
 * 制作日 : 2018年09月26日
 * 制作者：シスワントレサ
 * 内容　：メインキャラクターを動かせる
 * ----------------------------------------------- */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D), typeof(Animator))]
public class GR_Walk : MonoBehaviour {

    public float speed;

    Rigidbody2D rb2D;
    Animator anim;
    Vector2 moveVelocity;
    bool isFacingRight;
    

	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isFacingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 userInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        moveVelocity = userInput.normalized * speed;

        // キャラクターの向かい
        FlipSprite(moveVelocity.x);
        // キャラクタのアニメーション
        anim.SetFloat("velocity", moveVelocity.magnitude);
	}

    private void FixedUpdate()
    {
        Vector2 position = rb2D.position + moveVelocity * Time.fixedDeltaTime;

        // キャラクタの移動範囲
        //position.x = Mathf.Clamp(position.x, -5, 5);
        //position.y = Mathf.Clamp(position.y, -2, 2);

        rb2D.MovePosition(position);
    }

    private void FlipSprite(float x)
    {
        if (x == 0) return;

        if (x < 0 && isFacingRight)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            isFacingRight = false;
        }
        else if (x > 0 && !isFacingRight)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            isFacingRight = true;
        }
    }
}
