using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Video;

public class GivePointsBOX : MonoBehaviour
{
    //Seperate hitbox macht es variable wo man dinge abgeben kann 
public GivePoints givePoints;

    void OnDrawGizmos()
    {
    
   
      Vector3 ScaleTrigger = new Vector3(GetComponent<Collider>().bounds.size.x, givePoints.Blob.GetComponent<MeshRenderer>().bounds.size.y, GetComponent<Collider>().bounds.size.z); //transform.localscale
      Vector3 GreenBox = ScaleTrigger - new Vector3(2,0,2);

      if(transform.localScale.y < ScaleTrigger.y){
        transform.localScale = ScaleTrigger;
      }

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position,ScaleTrigger);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position,GreenBox);
        


        if (givePoints.interacted && givePoints.Blob.GetComponent<Collider>().bounds.size.x > GreenBox.x	) // nur eine koordinate zu nitzen geht, weil uniforme scalierung
        {
           transform.localScale += new Vector3(1,1,1);
        }
    }

    
}
