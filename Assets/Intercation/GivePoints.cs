using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePoints : MonoBehaviour
{

    public InteractionTest interTest;
    private bool triggerd;
    public bool interacted;
    public GameObject Blob;

    // Start is called before the first frame update
   void OnTriggerEnter(Collider other)
   {
    if(other.CompareTag("Player")){
    triggerd = true;
    }
   }

   void OnTriggerExit(Collider other)
   {
    if(other.CompareTag("Player")){
        triggerd = false;
    }
   }



    // Update is called once per frame
    void Update()
    {
          Grow();

        
    }

    public void Grow(){
        if(interTest.points >= 5 && triggerd && Input.GetKeyDown(KeyCode.E)){
            interTest.points -= 5;
            Blob.transform.localScale += new Vector3(1,1,1);
            Debug.Log(interTest.points);
            interacted = true;

        }else{
            interacted = false;
        }
    }

}
