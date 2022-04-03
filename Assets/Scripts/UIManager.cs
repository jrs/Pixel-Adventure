using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    public Image HeartOne, HeartTwo, HeartThree;
    public TextMeshProUGUI CollectibleCountText;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI GlobalLivesText;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateCollectibleScoreUI(GameManager.Instance.GetCollectibleAmount());
        UpdatePlayerGlobalLivesUI(GameManager.Instance.GetPlayerLives());
        UpdateSceneNameUI(GameManager.Instance.GetCurrentSceneName());
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateCollectibleScoreUI(GameManager.Instance.GetCollectibleAmount());
    }

    public void UpdatePlayerHealthUI(int healthAmount)
    {
        switch(healthAmount)
        {
            case 0:
                HeartOne.gameObject.SetActive(false);
                HeartTwo.gameObject.SetActive(false);
                HeartThree.gameObject.SetActive(false);
                break;
            case 1: 
                HeartOne.gameObject.SetActive(true);
                HeartTwo.gameObject.SetActive(false);
                HeartThree.gameObject.SetActive(false);
                break;
            case 2:
                HeartOne.gameObject.SetActive(true);
                HeartTwo.gameObject.SetActive(true);
                HeartThree.gameObject.SetActive(false);
                break;
            case 3:
                HeartOne.gameObject.SetActive(true);
                HeartTwo.gameObject.SetActive(true);
                HeartThree.gameObject.SetActive(true);
                break;
            default:
                HeartOne.gameObject.SetActive(true);
                HeartTwo.gameObject.SetActive(true);
                HeartThree.gameObject.SetActive(true);
                break;
        }
    }

    public void UpdateCollectibleScoreUI(int amount)
    {
        CollectibleCountText.SetText(amount.ToString());
    }

    public void UpdatePlayerGlobalLivesUI(int amount)
    {
        GlobalLivesText.text = "Player x " + amount.ToString();
    }

    public void UpdateSceneNameUI(string name)
    {
        LevelText.text = name;
    }


}
