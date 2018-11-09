/*---------------------------------------------------
 * 制作日 : 2018年09月26日
 * 制作者：シスワントレサ
 * 内容　：全体のゲームを管理するクラス
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    [SerializeField]
    private int sceneIndex;
    [SerializeField]
    private Animator panelFadeAnimator;
    [SerializeField]
    private GameObject NowLoadingPanel;

    public void LoadLevel()
    {
        //Enter();
        StartCoroutine(LoadFakeProgress());
    }

    IEnumerator LoadFakeProgress()
    {
        panelFadeAnimator.SetTrigger("End");

        yield return new WaitForSeconds(1f);

        NowLoadingPanel.SetActive(true);

        float fakeProgress = 0;

        while (fakeProgress < 2)
        {
            yield return new WaitForSeconds(0.7f);
            fakeProgress++;
        }
        
        Enter();
    }

    public void Enter()
    {
        SceneManager.LoadScene("TheWorld");
    }
}
