using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selected_dictionary : MonoBehaviour
{
    /// <summary>
    /// 게임오브젝트를 모아놓을 Dictionary생성
    /// </summary>
    public Dictionary<int, GameObject> selectedTable = new Dictionary<int, GameObject>();

    /// <summary>
    /// go라는 게임오브젝트를 Dictonary에 추가
    /// 그리고 Script를 추가해준다.
    /// </summary>
    public void addSelected(GameObject go)
    {
        int id = go.GetInstanceID();

        if(!(selectedTable.ContainsKey(id)))
        {
            selectedTable.Add(id, go);
            // 객체에 selection_component(Script)를 추가한다.
            go.AddComponent<selection_component>();
            Debug.Log("Added " + id + " to selected dict");
        }
    }

    /// <summary>
    /// 선택 해제 시 Dictonary에서 제거
    /// </summary>
    public void deselect(int id)
    {
        Destroy(selectedTable[id].GetComponent<selection_component>());
        selectedTable.Remove(id);
    }

    /// <summary>
    /// Dictonary의 전체 내용 삭제
    /// </summary>
    public void deselectAll()
    {
        // pair에 Dictonary의 게임오브젝트를 한개씩 넣어서 실행
        foreach(KeyValuePair<int, GameObject> pair in selectedTable)
        {
            if(pair.Value != null)
            {
                Destroy(selectedTable[pair.Key].GetComponent<selection_component>());
            }
        }
        // foreach문 밖에서 실행해야함
        selectedTable.Clear();
    }
}
