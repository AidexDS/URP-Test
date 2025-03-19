using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirPersonCam : MonoBehaviour
{
        [Header("referrence")]
        public Transform orientation;
        public Transform player;
        public Transform playerObj;
        public Rigidbody rb;

        public float rotSpeed;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

        void Update()
        {
            //rot orientation
            Vector3 viewDir = player.position - new Vector3(transform.position.x,player.position.y,transform.position.z);
            orientation.forward = viewDir.normalized;

            // toz player obj
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if(inputDir != Vector3.zero)
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotSpeed);

        }

    
}
