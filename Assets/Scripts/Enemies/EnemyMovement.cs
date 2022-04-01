using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed = 5f;
    public float BounceForce = 15f;
    public bool IsFacingLeft = true;
    public bool CanTakeDamage = true;
    public Transform PatrolPointOne, PatrolPointTwo;

    private Animator _myAnim;
    private Rigidbody2D _myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _myAnim = GetComponent<Animator>();
        _myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (CanTakeDamage)
        {
            if (IsFacingLeft)
            {
                if (transform.position.x > PatrolPointOne.position.x)
                {
                    _myRigidbody.velocity = new Vector2(-Speed, _myRigidbody.velocity.y);
                    _myAnim.SetBool("IsMoving", true);
                }
                else
                {
                    IsFacingLeft = false;
                    transform.rotation = PatrolPointTwo.rotation;
                    _myAnim.SetBool("IsMoving", false);
                }
            }
            else
            {
                if (transform.position.x < PatrolPointTwo.position.x)
                {
                    _myRigidbody.velocity = new Vector2(Speed, _myRigidbody.velocity.y);
                    _myAnim.SetBool("IsMoving", true);
                }
                else
                {
                    IsFacingLeft = true;
                    transform.rotation = PatrolPointOne.rotation;
                    _myAnim.SetBool("IsMoving", false);
                }
            }
        }
    }
}
