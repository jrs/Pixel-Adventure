using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour
{
    public bool IsMoving;
    public float Speed;
    public float WaitTime;
    public Transform[] PatrolPoints;

    private int _currentPointIndex;
    private float _waitTimeCounter;
   // private Rigidbody2D _myRigidbody;
    private Collider2D _myCollider;
    private Animator _myAnim;

    // Start is called before the first frame update
    void Start()
    {
        //_myRigidbody = GetComponent<Rigidbody2D>();
        _myCollider = GetComponent<Collider2D>();
        _myAnim = GetComponent<Animator>();

        IsMoving = true;
        _waitTimeCounter = WaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, PatrolPoints[_currentPointIndex].position, Speed * Time.deltaTime);

            if (transform.position == PatrolPoints[_currentPointIndex].position)
            {
                if (_currentPointIndex + 1 < PatrolPoints.Length)
                {
                    _currentPointIndex++;
                }
                else
                {
                    _currentPointIndex = 0;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            
        }
    }

    void FallingPlatformOff()
    {
        _myAnim.SetBool("Off", true);
        //_myRigidbody.gravityScale = 3;
        _myCollider.enabled = !_myCollider.enabled;
        IsMoving = false;
    }
}
