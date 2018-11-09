/*---------------------------------------------------
 * 制作日 : 2018年09月26日
 * 制作者：シスワントレサ
 * 内容　：プレイヤがが登録られたインプット
 * 最後の更新：2018年09月29日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

    Player player;
    Animator anim;

    #region Walking Sound Effects
    public AudioClip walk_SE;
    private bool walkingSEPlaying;
    #endregion

    // Use this for initialization
    void Start () {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        
        // pickableEventsに登録
        //gameObject.GetComponent<CharacterController2D>().interactableEvents += FoundPickables;
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 directionalInput = Vector2.zero;
        // プレイヤの移動操作
        if (player.PCondition == Player.PlayerCondition.CONTROLLABLE) // 現在プレイヤは動かせられるか？
        {
            directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        IsWalking(directionalInput.magnitude, directionalInput.x);
        player.SetDirectionalInput(directionalInput);        
	}

    /// <summary>
    /// プレイヤが歩くのか？
    /// </summary>
    /// <param name="speed">速度</param>
    void IsWalking(float speed, float face)
    {
        if (speed == 0) {
            anim.SetBool("isWalking", false);
            // サウンドエフェクトを終了
            walkingSEPlaying = false;
            PreloadComponent.soundManager.efxSource.loop = false;
            PreloadComponent.soundManager.efxSource.Stop();
            return;
        }

        // 歩くのサウンドエフェクトを設定
        WalkingSound(speed);

        anim.SetBool("isWalking", true);
    }

    void WalkingSound(float speed)
    {
        if (speed != 0 && !walkingSEPlaying)
        {
            PreloadComponent.soundManager.efxSource.loop = true;
            PreloadComponent.soundManager.RandomizeSFX(walk_SE);
            PreloadComponent.soundManager.efxSource.volume = 0.05f;
            walkingSEPlaying = true;
        }
    }
} // class
