using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public EMovement emovement;
    public Animator animator;
    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private static readonly int Punch = Animator.StringToHash("punch");
    private static readonly int IsJumping = Animator.StringToHash("isJumping");
    private bool attack;
    private bool jump;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

}
