using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOvementTest : MonoBehaviour
{

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.UpArrow)){
            rb.AddForce(1,0,0,ForceMode.Acceleration);
       }
    }
}
