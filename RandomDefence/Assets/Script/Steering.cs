using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering
{
    // 단일 프레임에서 회전하는 정도와 다른 지점으로 이동하는 거리
    // 0 ~ 360각도
    public float angular;
    // 순간 속도
    public Vector3 linear;

    public Steering()
    {
        angular = 0.0f;
        linear = new Vector3();
    }
}
