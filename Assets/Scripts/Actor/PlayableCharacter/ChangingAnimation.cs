﻿/*---------------------------------------------------
 * 制作日 : 2018年09月26日
 * 制作者：シスワントレサ
 * 内容　：灯籠を拾う
 * 最後の更新：2018年09月29日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingAnimation : MonoBehaviour
{
    public void Invoked()
    {
        gameObject.GetComponent<Animator>().SetLayerWeight(1, 1);
    }
} // !class
