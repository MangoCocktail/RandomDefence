using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class global_selection : MonoBehaviour
{
    selected_dictionary selected_table;
    RaycastHit hit;

    // 개별 단위를 클릭할지 드래그할지 알려주는 bool값
    bool dragSelect;

    // Collider 변수

    MeshCollider selectionBox;
    Mesh selectionMesh;

    Vector3 p1;
    Vector3 p2;

    // 2d형태의 선택 상자 테두리
    Vector2[] corners;

    // meshcollider의 vertices를 저장할 Vector3
    Vector3[] verts;
    Vector3[] vecs;

    // Start is called before the first frame update
    void Start()
    {
        selected_table = GetComponent<selected_dictionary>();
        dragSelect = false;
    }

    // Update is called once per frame
    void Update() 
    {
        // 1. 좌클릭 클릭한 상태
        if(Input.GetMouseButtonDown(0))
        {
            p1 = Input.mousePosition;
        }
        
        // 2. 좌클릭을 누르고있는 상태
        if(Input.GetMouseButton(0))
        {
            if((p1 - Input.mousePosition).magnitude > 40)
            {
                dragSelect = true;
            }
        }

        // 3. 좌클릭을 떼는 상태
        if(Input.GetMouseButtonUp(0))
        {
            if(dragSelect == false)
            {
                // 월드에서 카메라에 있는 p1을 향해 선을 쏜다.
                Ray ray = Camera.main.ScreenPointToRay(p1);

                // ray의 정보를 out을 통해 hit에 저장한다
                if(Physics.Raycast(ray, out hit, 50000.0f))
                {
                    // shift키 입력시 선택한 게임오브젝트도 selected_table에 추가
                    if(Input.GetKey(KeyCode.LeftShift))
                    {
                        selected_table.addSelected(hit.transform.gameObject);
                    }
                    // 그 외에는 한 개의 게임오브젝트만 selected_table에 추가
                    else
                    {
                        selected_table.deselectAll();
                        selected_table.addSelected(hit.transform.gameObject);
                    }
                }

                // 바닥 클릭 시
                else
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        // 아무것도 하지않는다.
                    }
                    else
                    {
                        // 전체를 선택 해제한다.
                        selected_table.deselectAll();
                    }
                }
            }
            else
            {
                verts = new Vector3[4];
                vecs = new Vector3[4];
                int i = 0;
                p2 = Input.mousePosition;
                corners = getBoundingBox(p1, p2);

                foreach(Vector2 corner in corners)
                {
                    Ray ray = Camera.main.ScreenPointToRay(corner);

                    if(Physics.Raycast(ray, out hit, 50000.0f, (1 << 8)))
                    {
                        verts[i] = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                        vecs[i] = ray.origin - hit.point;
                        Debug.DrawLine(Camera.main.ScreenToWorldPoint(corner), hit.point, Color.red, 1.0f);
                    }
                    i++;
                }
                
                // mesh생성
                selectionMesh = generateSelectionMesh(verts, vecs);

                selectionBox = gameObject.AddComponent<MeshCollider>();
                selectionBox.sharedMesh = selectionMesh;
                selectionBox.convex = true;
                selectionBox.isTrigger = true;

                // shift키를 안누를시 기존 선택사항은 제거 후 새로운 선택사항을 추가한다.
                if(!Input.GetKey(KeyCode.LeftShift))
                {
                    selected_table.deselectAll();
                }

                // 0.02초뒤에 드래그해서만든 상자 제거
                Destroy(selectionBox, 0.02f);
            }

            // 다시 false로 초기화
            dragSelect = false;
        }
    }

    /// <summary>
    /// 화면에서 드래그시 사각형을 그리는 함수
    /// </summary>
    private void OnGUI()
    {
        if(dragSelect == true)
        {
            var rect = Utils.GetScreenRect(p1, Input.mousePosition);
            Utils.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
            Utils.DrawScreenRectBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));
        }
    }

    /// <summary>
    /// p1에서 p2로 드래그할 때 생성되는 사각형의 각 꼭짓점을 Vector2에 저장
    /// 이 후 mesh생성을 위해 일정한 규칙에 맞게 순서대로 p1,p2,p3,p4를 저장한다.
    /// </summary>
    Vector2[] getBoundingBox(Vector2 p1, Vector2 p2)
    {
        var bottomLeft = Vector3.Min(p1, p2);
        var topRight = Vector3.Max(p1, p2);

        // 0 = top left, 1 = top rigt, 2 = bottom left, 3 = bottom right
        Vector2[] corners =
        {
            new Vector2(bottomLeft.x, topRight.y),
            new Vector2(topRight.x, topRight.y),
            new Vector2(bottomLeft.x, bottomLeft.y),
            new Vector2(topRight.x, bottomLeft.y)
        };

        return corners;
    }

    Mesh generateSelectionMesh(Vector3[] corners, Vector3[] vecs)
    {
        Vector3[] verts = new Vector3[8];

        // map the tris of our cube
        // 폴리곤(삼각형)을 만들 꼭짓점 숫자를 배열에 저장
        int[] tris = { 
            0, 1, 2, 
            2, 1, 3, 
            4, 6, 0, 
            0, 6, 2, 
            6, 7, 2, 
            2, 7, 3, 
            7, 5, 3, 
            3, 5, 1, 
            5, 0, 1, 
            1, 4, 0, 
            4, 5, 6,
            6, 5, 7 };

        for(int i = 0; i < 4; i++)
        {
            verts[i] = corners[i];
        }

        for(int j = 4; j < 8; j++)
        {
            verts[j] = corners[j - 4] + vecs[j - 4];
        }

        // 3d mesh를 만드는 과정
        Mesh selectionMesh = new Mesh();
        selectionMesh.vertices = verts;
        selectionMesh.triangles = tris;

        return selectionMesh;
    }

    // 드래그해서 생성된 사각형안의 게임오브젝트들을 추가한다.
    private void OnTriggerEnter(Collider other)
    {
        selected_table.addSelected(other.gameObject);
    }
}