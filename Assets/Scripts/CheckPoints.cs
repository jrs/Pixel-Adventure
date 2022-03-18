using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public bool HasPlayerChecked;
    public Vector3 CheckPointLocation;

    void Start()
    {
        CheckPointLocation = transform.position;    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !HasPlayerChecked)
        {
            Animator checkPointAnim = GetComponent<Animator>();
            checkPointAnim.SetBool("playerChecked", true);
            HasPlayerChecked = true;
           
            GameManager.Instance.UpdatePlayerRespawnLocation(CheckPointLocation);
        }
    }
}
