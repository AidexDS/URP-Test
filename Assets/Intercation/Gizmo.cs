using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    

    void Update()
    {
       
    }

    void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.yellow;
        Gizmos.DrawWireCube(transform.position,GetComponent<Collider>().bounds.size);
    }
}
