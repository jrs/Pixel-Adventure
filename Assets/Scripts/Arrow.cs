using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float BounceForce;

    private Animator _arrowAnim;

    // Start is called before the first frame update
    void Start()
    {
        _arrowAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController.Instance.BouncePlayer(BounceForce);
            _arrowAnim.SetTrigger("PlayerHit");
        }
    }
}
