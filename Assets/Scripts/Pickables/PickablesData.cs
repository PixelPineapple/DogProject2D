/*---------------------------------------------------
 * 制作日 : 2018年09月27日
 * 制作者：シスワントレサ
 * 内容　：プレイヤが得られたアイテムの情報
 * 最後の更新：2018年09月30日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PickablesData : ScriptableObject {

    #region description
    public new string name;
    public string description;
    public Sprite artwork;
    #endregion

        #region isPickedUp
    public bool isPicked;
    #endregion
}
