/*---------------------------------------------------
 * 制作日 : 2018年09月29日
 * 制作者：シスワントレサ
 * 内容　：プレイヤは他のゲームオブジェクトと対応を管理するクラス
 * 最後の更新：2018年10月4日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HumanTemplate : ScriptableObject
{

    public new string name;
    public Sprite portrait;

    #region What the player are looking
    public bool isCorrect;
    #endregion

    #region Dialogue
    [TextArea(3, 10)]
    public string[] sentences;
    #endregion
}
