/*---------------------------------------------------
 * 制作日 : 2018年10月05日
 * 制作者：シスワントレサ
 * 内容　：すべてのエベントを含むシングルトンクラス
 * 最後の更新：2018年10月05日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsContainer : MonoBehaviour {

    // プレイヤがたまに使うゲームエベント
    #region Mostly Used by Player
    public GameEvent pickingLanternEvent;
    public GameEvent foundPickableEvent;
    public GameEvent humanInteraction;
    public GameEvent isPlayerControllable;
    #endregion

    #region Mostly Used by Enemy
    public GameEvent hitEvent;
    #endregion

    #region Mostly Used To Update GUI
    public GameEvent updateInventory;
    #endregion
}
