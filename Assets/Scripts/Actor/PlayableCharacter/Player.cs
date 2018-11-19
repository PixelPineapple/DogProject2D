/*---------------------------------------------------
 * 制作日 : 2018年09月26日
 * 制作者：シスワントレサ
 * 内容　：プレイヤの状態を管理するクラス
 * 最後の更新：2018年11月10日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (CharacterController2D))]
public class Player : MonoBehaviour {

    #region Player Condition
    public enum PlayerCondition
    {
        CONTROLLABLE = 0,
        ISTALKING = 1,
        LOOKINVENTORY = 2
    }
    private PlayerCondition pCondition;
    public PlayerCondition PCondition
    {
        get { return pCondition; }
        set { pCondition = value; }
    }
    #endregion

    #region Player Movement
    float moveSpeed = 2f;
    
    CharacterController2D controller;
    public CharacterController2D Controller
    {
        get { return controller; }
    }

    Vector3 velocity;
    Vector2 directionalInput;
    float velocitySmoothing;
    #endregion

    Animator anim;
    
    public PickablesData blueLantern; // 青い灯籠を持ってるのか？

    private void Awake()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController2D>();
        PCondition = PlayerCondition.CONTROLLABLE;
    }

    private void OnEnable()
    {
        if (blueLantern.isPicked)
        {
            PreloadComponent.events.pickingLanternEvent.Raise();
        }
    }

    // Update is called once per frame
    void Update ()
    {
        CalculateVelocity();

        controller.Move(velocity * Time.deltaTime, directionalInput);
    }

    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

    void CalculateVelocity()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            moveSpeed = 3.5f;
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            moveSpeed = 2f;
        }
        float targetVelocityX = directionalInput.x * moveSpeed;
        float targetVelocityY = directionalInput.y * moveSpeed;
        velocity.x = targetVelocityX;//Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocitySmoothing, 0.05f);
        velocity.y = targetVelocityY;//Mathf.SmoothDamp(velocity.y, targetVelocityY, ref velocitySmoothing, 0.05f);
    }

    /// <summary>
    /// どんなアニメションを使う？
    /// </summary>
    void UseLanternAnimation()
    {
        anim.SetLayerWeight(1, 1);
    }

    public void PlayCondition(int value)
    {
        pCondition = (PlayerCondition) value;
    }

}
