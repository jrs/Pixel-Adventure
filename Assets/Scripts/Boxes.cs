using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    public GameObject[] objectsToSpawn;

    private int hitBoxCounter;
    private Animator _myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _myAnimator = GetComponent<Animator>();
        hitBoxCounter = Random.Range(0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Player")
        {
            if(hitBoxCounter > 0)
            {
                Debug.Log("The player hit me.");
                SpawnCollectibleObject();
                _myAnimator.SetTrigger("HitBox");
                hitBoxCounter--;
            }
            else
            {
                Destroy(this.gameObject);
            }
            
        }
    }

    void SpawnCollectibleObject()
    {
        int index = Random.Range(0, objectsToSpawn.Length);
        Instantiate(objectsToSpawn[index], transform.position + new Vector3(0, 1.5f, 0), transform.rotation);
    }
}
