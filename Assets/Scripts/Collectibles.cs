using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public int Value = 1;

    public GameObject CollectFX;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Instantiate(CollectFX, transform.position, transform.rotation);
            Destroy(this.gameObject);
            GameManager.Instance.UpdateCollectibleAmount();
        }
    }
}
