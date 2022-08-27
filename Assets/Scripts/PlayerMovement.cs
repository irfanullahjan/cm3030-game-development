using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    private TrailRenderer _trailRenderer;
    private Rigidbody2D _rigidbody;

    //Dashing Variables
    private float _dashingVelocity = 14f;
    private float _dashingTime = 0.5f;
    private Vector2 _dashingDir;
    private bool _isDashing;
    private bool _canDash = true;

    void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    
    // Update is called once per frame
    void Update()
    {
        var dashInput = Input.GetButtonDown("Dash");

        if (dashInput && _canDash)
        {
            _isDashing = true;
            _canDash = false;
            _trailRenderer.emitting = true;
            _dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            if (_dashingDir == Vector2.zero)
            {
                _dashingDir = new Vector2(transform.localScale.x, 0);
            }
            //Stop Dashing
            StartCoroutine(StopDashing());
        }
        if (_isDashing)
        {
            animator.SetBool("IsDashing", _isDashing);
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsCrouching", false);

        }
        else
        {
            animator.SetBool("IsDashing", false);
        }

        if (_isDashing)
        {
            _rigidbody.velocity = _dashingDir.normalized * _dashingVelocity;
            return;
        }
        if (controller.m_Grounded)
        {
            _canDash = true;
            animator.SetBool("IsGrounded", true);
        }

        
        
        
        
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        animator.SetFloat("yVelocity", _rigidbody.velocity.y);
    }

   public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }
    void FixedUpdate()
    {
        // Moving Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(_dashingTime);
        _trailRenderer.emitting = false;
        _isDashing = false;
    }


}
