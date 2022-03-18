using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float BounceForce;

    private Animator _myAnim;

    // Start is called before the first frame update
    void Start()
    {
        _myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.Instance.BouncePlayer(BounceForce);
            _myAnim.SetTrigger("Jump");
        }
    }


}
