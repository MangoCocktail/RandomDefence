using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Flee를 상속
public class BoidSeparation : Flee
{
    // 각 유닛사이의 거리
    public float desiredSeparation = 15.0f;
    // 동료의 위치를 알려줄 리스트
    public List<GameObject> targets;

    public override Steering GetSteering()
    {
        Steering steer = new Steering();
        int count = 0;

        foreach(GameObject other in targets)
        {
            if (other != null)
            {
                // 다른 동료와의 거리를 통해 멀어질지 다가갈지를 정한다.
                float d = (transform.position - other.transform.position).magnitude;

                // 모일수록 일정거리를 유지하기위해 반발력을 준다.
                if((d > 0) && ( d < desiredSeparation))
                {
                    Vector3 diff = transform.position - other.transform.position;
                    diff.Normalize();
                    diff /= d;
                    steer.linear += diff;
                    count++;
                }
            }
        }

        // 반발력이 너무심해서 집단이 안퍼지게 한다.
        if(count > 0)
        {
            // steer.linear /= (float)count;
        }

        return steer;
    }
}
