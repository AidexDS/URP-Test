using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class WalkingSounds : MonoBehaviour
{
    public LayerMask RockGround;
    public AudioSource FoodSteps;
  


    // Update is called once per frame
    void Update()
    {
      //  if(Physics.Raycast(transform.position, Vector3.down, 05f, LayerMask.GetMask("Terrain") )){
        //    Debug.Log("Hit");


        
           
        
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
            FoodSteps.enabled = true;
         if(Input.GetKey(KeyCode.Space)){
           FoodSteps.enabled = false;
           }
           
        }else{
            FoodSteps.enabled = false;
        }
        

        

        }

    
        void OnDrawGizmos()
        {
           Gizmos.DrawRay(transform.position, Vector3.down * 2);
          if(Physics.Raycast(transform.position, Vector3.down * 1,1f, LayerMask.GetMask("Terrain"))){
          Gizmos.color = Color.red;
          Gizmos.DrawRay(transform.position, Vector3.down * 2);
          }
        }
       

    }
//}
