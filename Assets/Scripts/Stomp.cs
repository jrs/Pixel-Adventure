using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp : MonoBehaviour
{
    public float BounceForce = 15;

    private Rigidbody2D _myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _myRigidbody = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy") && transform.position.y > other.transform.position.y)
        {
            _myRigidbody.velocity = new Vector2(_myRigidbody.velocity.x, BounceForce);
            other.gameObject.GetComponent<Enemy>().StompEnemy();
        }
    }
}
