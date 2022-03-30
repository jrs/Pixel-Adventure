using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float BounceForce = 5;
    public bool CanTakeDamage = true;

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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth.Instance.DealDamage();
        }
    }

    public void StompEnemy()
    {
        _myAnim.SetTrigger("Stomped");
        _myRigidbody.velocity = new Vector2(_myRigidbody.velocity.x, BounceForce);
        _myRigidbody.gravityScale = 3;
        _myCollider.enabled = !_myCollider.enabled;
    }
}
