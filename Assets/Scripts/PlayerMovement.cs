using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController cController;

    private float horizontalMove = 0f;
    public float runSpeed = 40f;
    private bool jump;
    private bool fire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
         if (Input.GetButtonDown("Jump"))
         {
             jump = true;
         }

         if (Input.GetButtonDown("Fire1"))
         {
             fire = true;
         }
    }

    private void FixedUpdate()
    {
        cController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        if(fire) cController.Fire();
        fire = false;
    }
}
