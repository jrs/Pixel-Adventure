using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp : MonoBehaviour
{
    [SerializeField] private float BounceForce = 0;

    private Rigidbody2D _myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StompedByPlayer()
    {

    }
}
