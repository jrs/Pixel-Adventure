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

    public Image fadeScreen;
    public float fadeSpeed;
    private bool shouldFadeToBlack, shouldFadeFromBlack;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.StartGame();
        FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
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

    public void UpdateSceneName(string sceneName)
    {
        LevelText.text = sceneName;
    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }
}
