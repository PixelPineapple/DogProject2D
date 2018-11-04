/*---------------------------------------------------
 * 制作日 : 2018年09月29日
 * 制作者：シスワントレサ
 * 内容　：敵の現在の行動
 * 最後の更新：2018年10月02日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public enum EnemyCurrentBehaviour
    {
        Idle,
        Chasing,
        Patroling,
        Charging,
        Dashing
    }
    
    [SerializeField]
    EnemyCurrentBehaviour ecb;
    public EnemyCurrentBehaviour Ecb
    {
        get
        {
            return ecb;
        }

        set
        {
            ecb = value;
        }
    }

    private CharacterController2D cc2d;

    [SerializeField]
    private GameObject player;
    public float distanceToPlayer;

    Animator anim;

    #region Charging For Attack
    public float chargeTime;
    private float chargingTime;
    public float lockingDashTarget;
    [SerializeField]
    private float dashSpeed;
    private Vector3 dashTarget = Vector3.zero;
    #endregion

    private void Start()
    {
        cc2d = GetComponent<CharacterController2D>();
        anim = GetComponent<Animator>();
        Ecb = EnemyCurrentBehaviour.Idle;
        chargingTime = chargeTime;
    }

    private void Update()
    {
        CurrentBehaviour();
    }

    /// <summary>
    /// EnemyCurrentBehaviour次第、敵を動かせる
    /// </summary>
    private void CurrentBehaviour()
    {
        switch(ecb)
        {
            case EnemyCurrentBehaviour.Chasing:
                Vector2 distance = player.transform.position - transform.position;
                cc2d.Move(distance * Time.deltaTime);
                if (distance.magnitude <= distanceToPlayer)
                {
                    ecb = EnemyCurrentBehaviour.Charging;
                }
                anim.SetBool("Chase", true);
                break;
            case EnemyCurrentBehaviour.Idle:

                break;
            case EnemyCurrentBehaviour.Patroling:

                break;
            case EnemyCurrentBehaviour.Charging:
                chargingTime -= Time.deltaTime;
                if (chargingTime >= lockingDashTarget)
                {
                    dashTarget = player.transform.position;
                }
                if (chargingTime <= 0)
                {
                    ecb = EnemyCurrentBehaviour.Dashing;
                    chargingTime = chargeTime;
                }
                break;
            case EnemyCurrentBehaviour.Dashing:
                Vector2 dashT = Vector2.MoveTowards(transform.position, dashTarget, 10);
                transform.position = dashT;
                //cc2d.Move(dashT * Time.deltaTime);
                ecb = EnemyCurrentBehaviour.Chasing;
                break;
        }
    } // !CurrentBehaviour

    public void BeginChasing()
    {
        Ecb = EnemyCurrentBehaviour.Chasing;
    }
}
