﻿/*---------------------------------------------------
 * 制作日 : 2018年09月29日
 * 制作者：シスワントレサ
 * 内容　：エベントを聞きたいクラスはGameEventListenerを追加
 * 最後の更新：2018年09月29日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour {

    public GameEvent gameEvent;
    public UnityEvent events;

    private void OnEnable()
    {
        gameEvent.RegisterEvent(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterEvent(this);
    }

    /// <summary>
    /// 応答を呼び出す。
    /// </summary>
    public void OnEventRaised()
    {
        events.Invoke();
    }

} // !class
