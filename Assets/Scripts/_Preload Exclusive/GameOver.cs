/*---------------------------------------------------
 * 制作日 : 2018年10月07日
 * 制作者：シスワントレサ
 * 内容　：ゲームオーバーを管理するクラス
 * 最後の更新：2018年10月07日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public void Gameover(bool playerGuess)
    {
        if (playerGuess)
        {
            // if the player guess right
            PlayerWin();
        }
        else
        {
            // if the player guess wrong
            PlayerLose();
        }

        StartCoroutine(ReloadFromStart());
    }

    void PlayerWin()
    {
        Debug.Log("PlayerWin");
    }

    void PlayerLose()
    {
        Debug.Log("PlayerLose");
    }

    IEnumerator ReloadFromStart()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("press C to restart");
        bool keyPressed = false;
        while(!keyPressed)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                keyPressed = true;
            }
            yield return null;
        }
        // 取ったアイテムをリセット
        gameObject.GetComponent<ResetPickablesData>().ResetAllPickablesData();
        SceneManager.LoadScene(1);
    }
}
