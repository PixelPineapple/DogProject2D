﻿/*---------------------------------------------------
 * 制作日 : 2018年11月09日
 * 制作者：シスワントレサ
 * 内容　：獲得システム管理するクラス
 * 最後の更新：2018年11月09日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AcquiredPanelSystem : MonoBehaviour {

    private PickablesData data;

    [Header("UI Components")]
    [SerializeField]
    private GameObject pickablesInfo;
    [SerializeField]
    private TMP_Text itemName;
    [SerializeField]
    private Image pixelSpriteImage;

    [Header("Visible Timer")]
    public float initialTimer;

    private void OnEnabled()
    {
        itemName = GetComponent<TMP_Text>();
    }

    // Pickablesクラスが呼ばれているメソッド、獲得アイテムのデータがもらえる
    public void GetPickablesInfo(PickablesData pickedData)
    {
        data = pickedData;
    }
    
    // データをプレイヤに見せる
    public void AcquiredItem()
    {
        if (data == null) return;

        if (!pickablesInfo.activeInHierarchy)
        {
            pickablesInfo.SetActive(true);
        }

        // テキストを入力
        itemName.text = data.kanjiName;
        // スプライト画像を入力
        pixelSpriteImage.sprite = data.pixelArts;

        StartCoroutine(VisibleTime(initialTimer));
    }

    // 消えるまでに何秒掛かるのか？
    IEnumerator VisibleTime(float initialTimer)
    {
        yield return new WaitForSeconds(initialTimer);

        pickablesInfo.SetActive(false);
    }
}
