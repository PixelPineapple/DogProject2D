using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CharacterController2D))]
public class CircleDetector : MonoBehaviour {

    [SerializeField]
    private float radius;
    public float Radius
    {
        get { return radius; }
    }

    public LayerMask layerMask;

    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameEvent hitEvent;

    CharacterController2D cc2D;

    private void Start()
    {
        cc2D = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        Radar();
    }

    public void Radar()
    {
        float directionX = cc2D.collisionInfos.faceDir;
        
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, Vector2.right * directionX, 0, layerMask);

        if(hit)
        {
            // 「プレイヤが見つかる」エベントを呼ぶ。
            hitEvent.Raise();
            hitEvent.UnregisterEvent(gameObject.GetComponent<GameEventListener>());
        }
        
    }
}
