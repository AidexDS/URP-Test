using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class Jumppad : MonoBehaviour
{
    public GizmoRenderer GR;
    public ThirdPersonController PlayerCRT;
    GameObject ThisObjekt;
    bool Triggerd;
    
    
    void OnTriggerEnter(Collider other)
    {
        Triggerd = true;
    }

    void OnTriggerExit(Collider other)
    {
        Triggerd = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(Triggerd && Input.GetKeyDown(KeyCode.Space)){
            PlayerCRT.GetComponent<Rigidbody>().AddForce(0, 5, 0, ForceMode.Impulse);
        }
    }

    void OnDrawGizmos()
    {
      
       GR.GizmoBox();
    }
}
