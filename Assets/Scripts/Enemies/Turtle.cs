using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    public float BounceForce;
    public float PlayerBounceForce;
    public bool CanTakeDamage;

    private float _waitTime;
    private float _startwaitTime;

    Animator _enemyAnim;
    Rigidbody2D _enemyRigidbody;
    Collider2D _enemyCollider;

    private void Start()
    {
        _enemyAnim = GetComponent<Animator>();
        _enemyCollider = GetComponent<Collider2D>();
        _enemyRigidbody = GetComponent<Rigidbody2D>();

        _startwaitTime = Random.Range(0, 5);
    }

    private void Update()
    {
        if(_waitTime <= 0)
        {
            if (_startwaitTime < 3)
            {
                SpikesIn();
                _waitTime = _startwaitTime;
                _startwaitTime = Random.Range(0, 5);
            }
            else
            {
                SpikesOut();
                _waitTime = _startwaitTime;
                _startwaitTime = Random.Range(0, 5);
            }
        }
        _waitTime -= Time.deltaTime;
    }

    private void SpikesIn()
    {
        CanTakeDamage = true;
        _enemyAnim.SetBool("Attack", false);
    }

    private void SpikesOut()
    {
        CanTakeDamage = false;
        _enemyAnim.SetBool("Attack", true);
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
            _enemyAnim.SetTrigger("Stomped");
            _enemyRigidbody.velocity = new Vector2(_enemyRigidbody.velocity.x, BounceForce);
            _enemyRigidbody.gravityScale = 3;
            _enemyCollider.enabled = !_enemyCollider.enabled;
        }
    }
}
