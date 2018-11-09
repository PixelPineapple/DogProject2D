/*---------------------------------------------------
 * 制作日 : 2018年10月05日
 * 制作者：シスワントレサ
 * 内容　：どこからでも呼べるスタティッククラス
 * 最後の更新：2018年10月05日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class PreloadComponent
{
    public static EventsContainer events;
    public static GameOver gameOver;
    public static ResetPickablesData resetPD;
    public static SoundManager soundManager;
    
    static PreloadComponent()
    {
        GameObject g = SafeFind("_App");
        events = (EventsContainer)SafeComponent(g, "EventsContainer");
        gameOver = (GameOver)SafeComponent(g, "GameOver");
        resetPD = (ResetPickablesData)SafeComponent(g, "ResetPickablesData");

        //  サウンドマネージャーを初期化
        GameObject sound = SafeFind("SoundManager");
        soundManager = (SoundManager)SafeComponent(sound, "SoundManager");
    }

    private static GameObject SafeFind(string s)
    {
        GameObject g = GameObject.Find(s);
        if (g == null) Woe("Component " + s + " not on _Preload.");
        return g;
    }

    private static Component SafeComponent (GameObject g, string s)
    {
        Component c = g.GetComponent(s);
        if (c == null) Woe("Component " + s + " not on _Preload.");
        return c;
    }

    private static void Woe(string error)
    {
        Debug.Log(">>> Cannot proceed... " + error);
        Debug.Log(">>> It is very likely you just forgot to launch");
        Debug.Log(">>> from scene zero, the _Preload scene.");
    }
}
