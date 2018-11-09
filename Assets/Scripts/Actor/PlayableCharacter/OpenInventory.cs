/*---------------------------------------------------
 * 制作日 : 2018年09月26日
 * 制作者：シスワントレサ
 * 内容　：インベントリパネルを開く
 * 最後の更新：2018年09月29日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Player))]
public class OpenInventory : MonoBehaviour {

    [SerializeField]
    private GameObject inventoryPanel;
    private bool isOpen;
    [SerializeField]
    private KeyCode buttonToOpen;
    public GameEvent updateInventory;
    [SerializeField]
    private UpdateImage updateImage;
    [SerializeField]
    private ButtonAPressed buttonAPressed;

    private void Start()
    {
        isOpen = false;
    }

    // Update is called once per frame
    void Update () {
        if (inventoryPanel != null && Input.GetKeyDown(buttonToOpen))
        {
            if (gameObject.GetComponent<Player>().PCondition == Player.PlayerCondition.CONTROLLABLE && !isOpen) // インベントリが開いていない
            {
                // インベントリを開く
                isOpen = true;
                // プレイヤの動きを止める
                PreloadComponent.events.playerisOpeningInventory.Raise();
            }
            else if (gameObject.GetComponent<Player>().PCondition == Player.PlayerCondition.LOOKINVENTORY && isOpen) // インベントリが開いている
            {
                // インベントリを閉める
                isOpen = false;
                // キャラの動きを持続する
                PreloadComponent.events.playerIsControllable.Raise();
            }
            updateImage.ChangeImage(isOpen); // 鞄の画像を更新する
            buttonAPressed.CurrentlyOpened(isOpen); // A-ボタンの画像を更新する
            inventoryPanel.SetActive(isOpen);
            updateInventory.Raise();
        }
	}
}
