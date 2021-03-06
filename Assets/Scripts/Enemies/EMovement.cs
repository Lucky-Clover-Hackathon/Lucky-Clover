﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EMovement : MonoBehaviour
{
    private int _health = 3;
    public int Health
    {
        get => _health;
        set => this._health = Mathf.Clamp(value, 0, 3);
    }
    [SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    [SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching
    [SerializeField] private GameObject m_GoldProjectile;
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
    
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;
    private SpriteRenderer m_spriteRenderer;
    public Animator animator;

    [Header("Events")]
    [Space]
    [SerializeField]
    Transform player;


    [SerializeField]
    float aggroRange;

    [SerializeField]
    float moveSpeed;
    Rigidbody2D rb2d;
    BoxCollider2D bc2d;

    private delegate IEnumerator HarmPlayer ();

    private HarmPlayer onHarmPlayer;
    
    public UnityEvent OnLandEvent;
    [SerializeField] private int pointBonus = 200;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    
        private void Awake()
        {    m_spriteRenderer = GetComponent<SpriteRenderer>();
            if (OnLandEvent == null)
                OnLandEvent = new UnityEvent();
    
            player = GameObject.FindGameObjectWithTag("Player").transform;
            onHarmPlayer += player.gameObject.GetComponent<CharacterController>().Harm;
        }

        private void FixedUpdate()
        {
            bool wasGrounded = m_Grounded;
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;
                    if (!wasGrounded)
                        OnLandEvent.Invoke();
                }
            }
        }
        private void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            bc2d = GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            float distFromPlayer = Vector2.Distance(transform.position, player.position);

            if (distFromPlayer < aggroRange)
            {
                ChasePlayer();
            }
            else
            {
                StopChasing();
            }

            print("distFromPlayer" + distFromPlayer);
        }
        private void ChasePlayer()
        {
            if (transform.position.x < player.position.x)
            {
                rb2d.velocity = new Vector2(moveSpeed, 0);
                animator.SetFloat("Speed", moveSpeed);
            }
            else
            {
                rb2d.velocity = new Vector2(-moveSpeed, 0);
                animator.SetFloat("Speed", moveSpeed);
        }
        }

        private void StopChasing()
        {

        }

        public void Harm()
        {
            Health--;
            Debug.Log(Health);
            if (Health == 0)
            {
                animator.Play("Enemy_Dead");
                //Destroy(gameObject);
                moveSpeed = 0;
                rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
                bc2d.enabled = false;
                
                UIController.AddScore(pointBonus);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Player"))
            {
                
                //other.gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(m_FacingRight ? 50f: -50f,10f);
                if (other.transform.position.y > gameObject.transform.position.y && Mathf.Abs(other.transform.position.x -gameObject.transform.position.x) < .5f)
                {
                    Harm();
                }
                else
                {
                    if (!other.gameObject.GetComponent<CharacterController>().invincible)
                    {
                        StartCoroutine(onHarmPlayer());

                    }
                    
                }
}
        }
}
