﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{

    public float moveSpeed;
    //public Rigidbody theRB;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;





    public float knockBackForce;
    public float knockVackTime;
    private float knockBackCounter;


    // Start is called before the first frame update
    void Start()
    {
        //theRB = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //theRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, theRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        /* if (Input.GetButtonDown("Jump"))
          {
              theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);
          } */

        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

        if (knockBackCounter < 0)
        {

        

         float yStore = moveDirection.y;
         moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
         moveDirection = moveDirection.normalized * moveSpeed;
         moveDirection.y = yStore;

            if (controller.isGrounded)
            {

                moveDirection.y = 0f;
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                }
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
    }
    public void knockBack(Vector3 direction)
    {
        knockBackCounter = knockVackTime;

      

        moveDirection = direction * knockBackForce ;
        moveDirection.y = knockBackForce;

    }
}
 