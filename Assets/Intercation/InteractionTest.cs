using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTest : MonoBehaviour
{
  
     [SerializeField]  private bool triggerActive = false;
     [SerializeField]  private bool DevMode;

     
    public int points = 5; 
    public void  OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            triggerActive = true;
        }
    }


void OnTriggerExit(Collider other)
{
    if(other.CompareTag("Player")){
        triggerActive = false;
    }
}
    // Update is called once per frame
    void Update()
    {
      if(triggerActive && Input.GetKeyDown(KeyCode.E) && DevMode == false){
        points ++;
        Debug.Log(points);
      }else if(triggerActive && Input.GetKeyDown(KeyCode.E) && DevMode == true){
        points =+ 1000;
        Debug.Log(points);
      }

    }
}
