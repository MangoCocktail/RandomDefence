using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 실제 유닛의 다양한 조종 동작을 정의
/// </summary>
public class AgentBehavior : MonoBehaviour
{
    // 조종 동작에 다른 가중치를 줄 수 있다.
    public float weight = 1.0f;

    // 상대를 추격할 경우 대상에 대한 정보가 필요
    public GameObject target;
    // Agent에 대한 참조가 필요하므로 조종 동작을 Agent에 적용할 수 있다.
    protected Agent agent;
    // 상대가 아닌 특정 지점으로 이동하려는 경우 목표물 대신 Vector3 대상을 사용
    public Vector3 dest;

    public float maxSpeed = 50.0f;
    public float masAccel = 50.0f;
    public float maxRotation = 5.0f;
    public float maxAngularAccel = 5.0f;

    public virtual void Start()
    {
        agent = gameObject.GetComponent<Agent>();
    }

    public virtual void Update()
    {
        agent.SetSteering(GetSteering(), weight);
    }

    /// <summary>
    /// 회전 값을 고정하기 위한 함수
    /// <summary>
    public float MapToRange(float rotation)
    {
        rotation %= 360.0f;
        if(Mathf.Abs(rotation) > 180.0f)
        {
            if(rotation < 0.0f)
            {
                rotation += 360.0f;
            }
            else
            {
                rotation -= 360.0f;
            }
        }

        return rotation;
    }

    /// <summary>
    /// 다른 클래스에서 사용 시 원하는 대로 재정의할 수있다.
    /// 그러면 조종 동작을 원하는 모든 유형의 움직임을 정의할 수 있다.
    /// </summary>
    public virtual Steering GetSteering()
    {
        return new Steering();
    }
}
