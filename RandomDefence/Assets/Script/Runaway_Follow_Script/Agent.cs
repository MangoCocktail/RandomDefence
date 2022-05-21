using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 업데이트할 때마다 즉각적인 속도를 적용한다.
/// </summary>
public class Agent : MonoBehaviour
{
    // 최대속도
    public float maxSpeed = 10.0f;
    // 실제 유닛의 최대속도
    // 그룹내에서 동일한 속도로 움직이기 위해 다른 유닛의 최대 속도를 사용할 때 쓰는 용도
    public float trueMaxSpeed;
    // 최대 가속도
    public float maxAccel = 30.0f;

    // 유닛의 방향
    public float orientation;
    // 얼마나 회전할지를 나타내는 수치
    public float rotation;

    // 프레임당 이동하는 속도, steering
    public Vector3 velocity;
    protected Steering steer;

    // 최대 회전각도와 최대 각가속도
    public float maxRotation = 45.0f;
    public float maxAngularAccel = 45.0f;

    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
        steer = new Steering();
        trueMaxSpeed = maxSpeed;
    }

    public void SetSteering(Steering steer, float weight)
    {
        // 무게에 따른 가중치
        this.steer.linear += (weight * steer.linear);
        this.steer.angular += (weight * steer.angular);

    }

    // 이전 프레임 steering 기준으로 위치를 변환
    // 가상함수를 사용하여 동일한 프레임워크 내에서 서로 다른 조종 동작을 구현할 수 있다.
    public virtual void Update()
    {
        // 시간대비 일정한 속도로 움직인다.(시간당 이동)
        Vector3 displacement = velocity * Time.deltaTime;
        displacement.y = 0;

        orientation += rotation * Time.deltaTime;
        
        // 방위를 0 ~ 360으로 제한을 둔다.
        if (orientation < 0.0f)
        {
            orientation += 360.0f;
        }
        else if(orientation > 360.0f)
        {
            orientation -= 360.0f;
        }
        // 월드좌표를 기준으로 속도에 맞춰서 움직인다.
        transform.Translate(displacement, Space.World);
        transform.rotation = new Quaternion();
        transform.Rotate(Vector3.up, orientation);
    }

    /// <summary>
    /// 속도와 각가속도를 제한한다.
    /// </summary>
    public virtual void  LateUpdate()
    {
        velocity += steer.linear * Time.deltaTime;
        rotation += steer.angular * Time.deltaTime;

        if(velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity = velocity * maxSpeed;
        }

        if (steer.linear.magnitude == 0.0f)
        {
            velocity = Vector3.zero;
        }
        steer = new Steering();

    }
    /// <summary>
    /// 최대 속도를 외부적으로 재설정
    /// 유닛이 그룹내에 있을 때 속도를 맞춰준다.
    /// </summary>
    public void speedReset()
    {
        maxSpeed = trueMaxSpeed;
    }
}
