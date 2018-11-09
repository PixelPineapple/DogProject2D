/*---------------------------------------------------
 * 制作日 : 2018年09月29日
 * 制作者：シスワントレサ
 * 内容　：プレイヤは他のゲームオブジェクトと対応を管理するクラス
 * 最後の更新：2018年09月29日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Player))]
public class PlayerEventListener : MonoBehaviour {

    Player player;

	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();

        player.Controller.interactableEvents += FoundInteraction;
	}

    void FoundInteraction(GameObject other)
    {
        if (player.PCondition == Player.PlayerCondition.CONTROLLABLE)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                switch (other.transform.tag)
                {
                    case "Lantern":
                        PreloadComponent.events.pickingLanternEvent.Raise();
                        break;
                    case "Pickable":
                        other.GetComponent<GameEventListener>().enabled = true;
                        // Need to find a way to register and unregister event on contact - Done.
                        // Pick the objects or do other stuffs **
                        PreloadComponent.events.foundPickableEvent.Raise();
                        break;
                    case "Human":
                        other.GetComponent<GameEventListener>().enabled = true;
                        PreloadComponent.events.humanInteraction.Raise();
                        // プレイヤ入力を止める
                        PreloadComponent.events.playerIsTalking.Raise();
                        break;
                    case "Door":
                        if (player.blueLantern.isPicked)
                        {
                            other.GetComponent<SceneTransition>().LoadLevel();
                        }
                        else
                        {
                            Debug.Log("Lantern is not yet picked");
                        }
                        break;
                }
            }
        } // !if(player.isControllable)
    }
} // !class
