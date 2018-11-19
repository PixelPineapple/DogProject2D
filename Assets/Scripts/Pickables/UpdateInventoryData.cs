/*---------------------------------------------------
 * 制作日 : 2018年11月09日
 * 制作者：シスワントレサ
 * 内容　：インベントリUIを開く時、インベントリの中のものを更新する
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateInventoryData : MonoBehaviour {

    public PickablesData pickableData;

    public void UpdateInventory()
    {
        if (pickableData.isPicked)
        {
            gameObject.GetComponent<Image>().enabled = true;
            gameObject.GetComponent<Selectable>().interactable = true;
        }
    }
}
