using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chameleon : MonoBehaviour
{
    public float DistanceToPlayer;
    public float Speed;
    public bool IsFacingLeft;

    private float _waitTime = 0.5f;
    private float _startWaitTime = 0;
    private Animator _myAnim;
    private Rigidbody2D _myRigidbody;
    private Collider2D _myCollider;

    // Start is called before the first frame update
    void Start()
    {
        _myAnim = GetComponent<Animator>();
        _myRigidbody = GetComponent<Rigidbody2D>();
        _myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSeePlayer(DistanceToPlayer))
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.transform.position, Speed * Time.deltaTime);
            _myAnim.SetBool("IsMoving", true);
        }
        else
        {
            _myAnim.SetBool("IsMoving", false);
        }
    }

    bool CanSeePlayer(float distance)
    {
        bool var = false;
        float castDist = distance;

        if (IsFacingLeft)
        {
            castDist = -distance;
        }

        Vector2 endPos = transform.position + Vector3.right * castDist;

        RaycastHit2D hit = Physics2D.Linecast(transform.position, endPos, 1 << LayerMask.NameToLayer("Player"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                var = true;
            }
            else
            {
                var = false;
            }

            Debug.DrawLine(transform.position, endPos, Color.green);
        }
        else
        {
            Debug.DrawLine(transform.position, endPos, Color.red);
        }

        return var;
    }

    void AttackPlayer()
    {
        PlayerHealth.Instance.DealDamage();
    }

    void DontAttackPlayer()
    {
        _myAnim.SetBool("IsMoving", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            _myAnim.SetTrigger("Attack");
        }
    }
}
