using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    //only needed if you have different values per item
    public int Value = 1;

    //once an item is collected, a FX is created
    public GameObject CollectFX;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //create the FX when an item is collected
            Instantiate(CollectFX, transform.position, transform.rotation);
            
            //if you have different values per collectible item, you will need to update this method to pass that value along
            //update the global total of items collected
            GameManager.Instance.SetCollectibleAmount();

            //update the UI to display the newly collected item
            UIManager.Instance.UpdateCollectibleScoreUI(GameManager.Instance.GetCollectibleAmount());

            //destroy/remove the item from the scene
            Destroy(this.gameObject);
        }
    }
}
