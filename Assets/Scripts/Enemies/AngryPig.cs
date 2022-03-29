using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryPig : MonoBehaviour
{
    public float Speed = 5f;
    public float BounceForce = 15f;
    public bool IsFacingLeft = true;
    public bool CanTakeDamage = true;
    public Transform PatrolPointOne, PatrolPointTwo;

    private Animator _myAnim;
    private Collider2D _myCollider;
    private Rigidbody2D _myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _myAnim = GetComponent<Animator>();
        _myCollider = GetComponent<Collider2D>();
        _myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
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

    void SetAngryPig()
    {
        _myAnim.SetTrigger("Stomped");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerHealth>().DealDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Stomp" && CanTakeDamage)
        {
            Debug.Log("the player stomped on me.");
            PlayerController.Instance.BouncePlayer(BounceForce);
            _myAnim.SetTrigger("Stomped");
            _myRigidbody.velocity = new Vector2(_myRigidbody.velocity.x, BounceForce);
            _myRigidbody.gravityScale = 3;
            _myCollider.enabled = !_myCollider.enabled;
        }
    }
}
