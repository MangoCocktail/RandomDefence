using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 집단을 무리지어서 움직이는것처럼 보이게하는 코드
public class BoidCohesion : AgentBehavior
{
    // 집단의 유닛간의 거리
    public float neigborDist = 15.0f;
    public List<GameObject> targets;

    // 집단이 모일 중심을 찾은 후 모이게한다.
    public override Steering GetSteering()
    {
        Steering steer = new Steering();
        int count = 0;

        foreach(GameObject other in targets)
        {
            if(other != null)
            {
                float d = (transform.position - other.transform.position).magnitude;
                if((d > 0) && (d < neigborDist))
                {
                    steer.linear += other.transform.position;
                    count++;
                }
            }
        }
        
        // 전체 위치의 평균을 알아내서 그 지점으로 모이게한다.
        if(count > 0)
        {
            steer.linear /= count;
            steer.linear = steer.linear - transform.position;
        }

        return steer;
    }
}
