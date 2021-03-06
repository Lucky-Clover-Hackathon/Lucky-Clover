using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController cController;
    public Animator cAnimator;

    private float horizontalMove = 0f;
    public float runSpeed = 40f;
    public float maxY = 10.0f;
    public float maxX = 8.0f;
    private bool jump;
    private bool fire;
    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private static readonly int Punch = Animator.StringToHash("punch");
    private static readonly int IsJumping = Animator.StringToHash("isJumping");

    // Start is called before the first frame update
    void Start()
    {
        cAnimator = GetComponent<Animator>();
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
        cAnimator.SetBool(IsMoving, horizontalMove != 0f);
        cAnimator.SetBool(IsJumping, jump);
        cController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        if (fire)
        {

            fire = false;
            cAnimator.Play("leprechaun_punch");
            cController.Fire();
        };
        jump = false;
        // if (Mathf.Abs(gameObject.transform.position.y) > maxY)
        // {
        //     gameObject.transform.position = new Vector3(gameObject.transform.position.x , -gameObject.transform.position.y, gameObject.transform.position.z);
        // }
        // if (Mathf.Abs(gameObject.transform.position.x) > maxX)
        // {
        //     gameObject.transform.position = new Vector3(-gameObject.transform.position.x , gameObject.transform.position.y, gameObject.transform.position.z);
        // }
    }
}
