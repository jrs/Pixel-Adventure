using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform SpawnPointLocation;
    public float DistanceToPlayer;
    public float BounceForce;
    public float PlayerBounceForce;
    public bool IsFacingLeft;

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
    void FixedUpdate()
    {
        if (CanSeePlayer(DistanceToPlayer))
        {
            ShootAtPlayer();
        }
        else
        {
            DontShootAtPlayer();
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

        if(hit.collider != null)
        {
            if(hit.collider.gameObject.CompareTag("Player"))
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

    void ShootAtPlayer()
    {
        //Debug.Log("Enemy is shooting");
        _myAnim.SetBool("Attack", true);
    }

    void DontShootAtPlayer()
    {
        //Debug.Log("Enemy is idle");
        _myAnim.SetBool("Attack", false);
    }

    void FireShot()
    {
        Instantiate(ProjectilePrefab, SpawnPointLocation.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Stomp")
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
