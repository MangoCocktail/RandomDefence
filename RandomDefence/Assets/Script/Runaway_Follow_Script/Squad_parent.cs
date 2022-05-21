using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squad_parent : MonoBehaviour
{
    // 타겟과 자식리스트를 생성
    // chile_prefab에 생성할 자식을 넣어두면 동일한 자식이 생성된다.
    public GameObject target;
    public GameObject child_prefab;
    public List<GameObject> children;

    // Start is called before the first frame update
    void Start()
    {
        children = new List<GameObject>();

        // 시작할때 12개의 자식을 필드에 생성한다.
        for(int i = 0; i < 12; i++)
        {
            // 스폰위치지정
            Vector3 relative_spawn = new Vector3(i % 4, 0.33f, i / 4);
            GameObject temp = Instantiate(child_prefab, transform.position + (relative_spawn * 0.6f), transform.rotation);
            temp.GetComponent<base_behavior>().target = gameObject;
            children.Add(temp);
        }
    }

    // Update is called once per frame
    // 매 프레임마다 상대를 쫓게한다.
    void Update()
    {
        transform.position += (target.transform.position - transform.position).normalized * Time.deltaTime * 5.0f;   
    }
}
