/*---------------------------------------------------
 * 制作日 : 2018年10月06日
 * 制作者：シスワントレサ
 * 内容　：どこのシーンからでもPreloadシーンを最初に呼び出されるように。
 * 最後の更新：2018年10月06日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPreloadScene {

#if UNITY_EDITOR
    public static int otherScene = -2;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void InitLoadingScene()
    {
        Debug.Log("InitLoadingScene()");
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 0) return; // ここは_Preloadシーン

        Debug.Log("Loading _preload scene");
        otherScene = sceneIndex;
        // _Preloadシーンはシーンビルドの中に必ず一番上と確認しなさい
        SceneManager.LoadScene(0);
    }
#endif
}

