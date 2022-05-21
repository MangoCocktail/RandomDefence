using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seek_script : MonoBehaviour
{
    base_behavior bb;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        bb = gameObject.GetComponent<base_behavior>();
        target = bb.target;


        if (bb.seekScript == null)
        {
            // 위4줄코드 - seek모드에서 상대를 향해 움직임
            // 아래 3줄코드 - seek모드에서 상대에서 도망감

            bb.seekScript = gameObject.AddComponent<Seek>();
            bb.seekScript.target = target;
            bb.seekScript.weight = 0.7f;
            bb.seekScript.enabled = true;

            /*bb.fleeScript = gameObject.AddComponent<Flee>();
            bb.fleeScript.target = target;
            bb.fleeScript.enabled = true;*/

            bb.boidcoh = gameObject.AddComponent<BoidCohesion>();
            bb.boidcoh.targets = bb.target.GetComponent<Squad_parent>().children;
            bb.boidcoh.weight = 0.4f;
            bb.boidcoh.enabled = true;

            bb.boidsep = gameObject.AddComponent<BoidSeparation>();
            bb.boidsep.targets = bb.target.GetComponent<Squad_parent>().children;
            bb.boidsep.weight = 70.0f;
            bb.boidsep.enabled = true;
        }

    }


    private void OnDestroy()
    {
        DestroyImmediate(bb.seekScript);
    }


    private void OnDrawGizmos()
    {
        UnityEditor.Handles.Label(transform.position + Vector3.up * 3, "Seek");
    }

}