using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NavMeshAgent를 사용하기위해 포함
using UnityEngine.AI;


// NavMeshAgent component를 플레이어에 추가
// Navigation Window에서 지형역할을 할 asset을 Navigation Static으로 설정한 후
// Navigation area에서 Not Walkable을 해주면 플레이어는 지형역할을 하는 asset의 구역에 들어가지 않는다.
public class PlayerController : MonoBehaviour
{
    Camera cam;
    // raycast가 오직 groundLayer에서만 작동하도록하기위한 LayerMask
    public LayerMask groundLayer;

    // 탐색메시 에이전트 
    // 유닛이 클릭을 통한 이동을 하기위한 변수
    public NavMeshAgent playerAgent;

    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            // 플레이어를 마우스클릭한 위치로 이동하게한다.(목적지 설정)
            playerAgent.SetDestination(GetPointUnderCursor());
        }
    }

    private Vector3 GetPointUnderCursor()
    {
        Vector2 screenPosition = Input.mousePosition;
        // 화면상의 마우스위치를 월드의 위치로 변환
        Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(screenPosition);

        RaycastHit hitPosition;

        // 월드의 마우스위치를 시작으로 cam의 앞방향으로 100거리만큼 ray를 쏴서 얻은 정보를 hitPostion에 저장
        // 단, groundLayer의 정보만 가져온다.
        Physics.Raycast(mouseWorldPosition, cam.transform.forward, out hitPosition, 100, groundLayer);

        // 클릭한 위치를 반환해야한다.
        return hitPosition.point;
    }
}
