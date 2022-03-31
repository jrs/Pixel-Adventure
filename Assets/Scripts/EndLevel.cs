using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private Animator _myAnim;

    private void Start()
    {
        _myAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            _myAnim.SetTrigger("Start");
            FindObjectOfType<LevelLoader>().LoadNextLevel();
        }
    }
}
