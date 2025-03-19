using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoRenderer : MonoBehaviour


{


  void OnDrawGizmos()
  {
    
    GizmoBox();
  }

  public void GizmoBox()
    {
        
    Gizmos.color = Color.cyan;
    Gizmos.DrawWireCube(GetComponent<Collider>().transform.position, GetComponent<Collider>().bounds.size);
    
}
}


