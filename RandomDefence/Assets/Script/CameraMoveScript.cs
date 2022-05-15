using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{

    // 카메라 속도, 줌 속도, 회전 속도
    float speed = 0.06f;
    float zoomSpeed = 10.0f;
    float rotateSpeed = 0.1f;

    // 카메라 높이조절
    float maxHeight = 40f;
    float minHeight = 4f;

    // 카메라 회전을 위한 변수
    Vector2 p1;
    Vector2 p2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // shift키 입력시 줌 속도 증가
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 0.06f;
            zoomSpeed = 20.0f;
        }
        else
        {
            speed = 0.03f;
            zoomSpeed = 10.0f;
        }

        // 현재 높이에 맞게 줌 속도를 조절한다. -> transform.position.y
        // 수평이동변수
        float hsp = transform.position.y * speed * Input.GetAxis("Horizontal");
        // 수직이동변수
        float vsp = transform.position.y * speed * Input.GetAxis("Vertical");

        // 속도가 너무 빨라지는것을 방지하기위해 로그함수사용
        // 스크롤스피드
        float scrollSp = Mathf.Log(transform.position.y)  * - zoomSpeed * Input.GetAxis("Mouse ScrollWheel");

        // 월드 밖으로 나가지 않게 제한을 건다.
        if ((transform.position.y >= maxHeight) && (scrollSp > 0))
            scrollSp = 0;
        else if ((transform.position.y <= minHeight) && (scrollSp < 0))
            scrollSp = 0;

        // 스크롤스피드에 따라서 월드 밖으로 이동이 가능할수도있기때문에 이 부분에도 제한을 둔다.
        if((transform.position.y + scrollSp) > maxHeight)
        {
            scrollSp = maxHeight - transform.position.y;
        }
        else if((transform.position.y + scrollSp) < minHeight)
        {
            scrollSp = minHeight - transform.position.y;
        }

        // 수직이동
        Vector3 verticalMove = new Vector3(0, scrollSp, 0);
        // 수평이동
        // 월드를 기준으로 좌, 우로 나가지않도록 하기위해서 transform.right를 가져온다.
        Vector3 lateralMove = hsp * transform.right;
        // 카메라가 아래로 기울어져있으므로 단순히 앞으로 움직이게 해버리면 땅으로 내려가버린다.
        // 이를 위해 벡터투영을 사용해야한다.
        Vector3 forwardMove = transform.forward;
        // forwardMove의 y를 0으로 설정해서 더 이상 내려가지 않도록한다.
        // forwardMove를 정규화한 후, 수직이동 속도롤 곱해준다.
        forwardMove.y = 0;
        forwardMove.Normalize();
        forwardMove = forwardMove * vsp;

        // 수평, 수직, 앞뒤이동 vector을 하나로 합쳐준다.
        Vector3 move = verticalMove + lateralMove + forwardMove;

        transform.position += move;

        getCameraRotation();

    }
    void getCameraRotation()
    {
        // 휠버튼을 눌렸을 시, p1에 현재 마우스의 위치를 넣는다.
        if(Input.GetMouseButtonDown(2))
        {
            p1 = Input.mousePosition;
        }

        // 휠버튼을 누르고있으면, p2에 현재 마우스의 위치를 넣는다. 
        if(Input.GetMouseButton(2))
        {
            p2 = Input.mousePosition;

            float dx = (p2 - p1).x * rotateSpeed;
            float dy = (p2 - p1).y * rotateSpeed;

            // Y rotation(좌우 회전)
            // 카메라가 앞으로 기울어져있으므로 실제로는 제대로 회전하지 않는다.
            // 그러므로 CameraParent라는 빈 오브젝트를만들어서 전역 y축에 맞게 회전하도록한다.
            transform.rotation *= Quaternion.Euler(new Vector3(0, dx, 0));

            // X rotation(상하 회전)
            // -dy는 마우스 이동시 회전이 반대로 하기때문에 주어진다.
            transform.GetChild(0).transform.rotation *= Quaternion.Euler(new Vector3(-dy, 0, 0));

            // 회전에 가속도가 붙기때문에 p1 = p2를 해준다.
            p1 = p2;
        }
    }
}