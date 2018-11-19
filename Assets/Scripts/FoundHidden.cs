﻿/*---------------------------------------------------
 * 制作日 : 2018年11月09日
 * 制作者：シスワントレサ
 * 内容　：隠しオブジェクトを見つけるとき
 * 最後の更新：2018年11月09日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundHidden : MonoBehaviour {

    [SerializeField]
    private AudioClip foundHiddenAudioClip; // Found something audioclip

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PreloadComponent.soundManager.PlayOnceEFX(foundHiddenAudioClip);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
