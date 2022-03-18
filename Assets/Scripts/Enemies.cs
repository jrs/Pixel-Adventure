using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float BounceForce;

    Animator _enemyAnim;
    Rigidbody2D _enemyRigidbody;
    Collider2D _enemyCollider;

    private void Start()
    {
        _enemyAnim = GetComponent<Animator>();
        _enemyCollider = GetComponent<Collider2D>();
        _enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerHealth>().DealDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Stomp" && PlayerController.Instance.transform.position.y > transform.position.y)
        {
            Debug.Log("the player stomped on me.");
            PlayerController.Instance.BouncePlayer(15);
            _enemyAnim.SetTrigger("stomped");
            _enemyRigidbody.velocity = new Vector2(_enemyRigidbody.velocity.x, BounceForce);
            _enemyRigidbody.gravityScale = 3;
            _enemyCollider.enabled = !_enemyCollider.enabled;
        }
    }
}
