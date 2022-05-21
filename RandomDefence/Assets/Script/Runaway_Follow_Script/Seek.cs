using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AgentBehavior을 상속받음
public class Seek : AgentBehavior
{

    /// <summary>
    /// 타겟을 향한 움직임
    /// 타겟위치와 내 위치를 빼서 정규화한 후, 목표를 향해 이동시킨다.
    /// </summary>
    /// <returns></returns>
    public override Steering GetSteering()
    {
        Steering steer = new Steering();
        steer.linear = target.transform.position - transform.position;
        steer.linear.Normalize();
        steer.linear = steer.linear * agent.maxAccel;
        return steer;
    }
}
