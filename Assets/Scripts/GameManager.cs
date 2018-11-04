/*---------------------------------------------------
 * 制作日 : 2018年09月26日
 * 制作者：シスワントレサ
 * 内容　：全体のゲームを管理するクラス
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    #region Singleton
    [HideInInspector]
    public static GameManager _instance;
    [SerializeField]
    private GameObject playerPrefab;

    private void MakeSingleton()
    {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            DontDestroyOnLoad(gameObject);
            }
    }
    #endregion

    [HideInInspector]
    public PlayerPrefs playerPref;

    // Use this for initialization
    void Awake() {
        MakeSingleton();
        playerPref.Reset();
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneChanged;
    }

    public struct PlayerPrefs
    {
        public bool isHoldingLantern;

        public void Reset()
        {
            isHoldingLantern = false;
        }
    }

    public void OnSceneChanged (Scene name, LoadSceneMode mode)
    {
        Instantiate(playerPrefab);
    }
} // class


