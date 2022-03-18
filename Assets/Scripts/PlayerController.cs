using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    //Config
    public float MoveSpeed = 8f;
    public float JumpForce = 15f;
    public float KnockBackLength;
    public float KnockBackForce;
    public LayerMask WhatIsGround;

    private float _knockBackCounter;

    // States
    [SerializeField] private bool _isOnGround;
    [SerializeField] private bool _canDoubleJump;

    // Cached component references
    private Rigidbody2D _playerRb;
    private Animator _playerAnim;
    private CapsuleCollider2D _playerCollider;

    void Awake()
    {
        Instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<Animator>();
        _playerCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_knockBackCounter <= 0)
        {
            Run();
            Jump();
            FlipSprite();
        }
        else
        {
            _knockBackCounter -= Time.deltaTime;

            if(transform.localScale.x == 1)
            {
                _playerRb.velocity = new Vector2(-KnockBackForce, _playerRb.velocity.y);
            }
            else
            {
                _playerRb.velocity = new Vector2(KnockBackForce, _playerRb.velocity.y);
            }
        }
    }

    void Run()
    {
       float _horizontalInput = Input.GetAxis("Horizontal");

       _playerRb.velocity = new Vector2(_horizontalInput * MoveSpeed, _playerRb.velocity.y);

       if(Mathf.Abs(_horizontalInput) > 0)
       {
           _playerAnim.SetFloat("Speed", Mathf.Abs(_horizontalInput));
       }
       else
       {
           _playerAnim.SetFloat("Speed", 0);
       }
    }

    void Jump()
    {
        if (_playerCollider.IsTouchingLayers(WhatIsGround)) //_playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))
        {
            _isOnGround = true;
            _canDoubleJump = true;
            _playerAnim.SetBool("IsOnGround", _isOnGround);
        }
        else
        {
            _isOnGround = false;
            _playerAnim.SetBool("IsOnGround", _isOnGround);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (_isOnGround)
            {
                _playerRb.velocity = new Vector2(_playerRb.velocity.x, JumpForce);
            }
            else
            {
                if (_canDoubleJump)
                {
                    _playerRb.velocity = new Vector2(_playerRb.velocity.x, JumpForce);
                    _playerAnim.SetTrigger("DoubleJump");
                    _canDoubleJump = false;
                }
            }
        }
    }

    void FlipSprite()
    {
        bool _playerHasHorizontalSpeed = Mathf.Abs(_playerRb.velocity.x) > Mathf.Epsilon;

        if(_playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(_playerRb.velocity.x), 1f);
        }
    }

    public void DamagePlayer()
    {
        _playerAnim.SetTrigger("IsHit");

    }

    public void KnockBack()
    {
        _knockBackCounter = KnockBackLength;
        _playerRb.velocity = new Vector2(0f, KnockBackForce);
    }

    public void BouncePlayer(float bounceForce)
    {
        _playerRb.velocity = new Vector2(_playerRb.velocity.x, bounceForce);
    }
}
