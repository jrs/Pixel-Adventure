using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] int _collectibleCount = 0;
    [SerializeField] int _livesCount = 3;
    [SerializeField] string _sceneName;

    void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void StartGame()
    {
        UIManager.Instance.UpdateCollectibleScoreUI(_collectibleCount);
        _sceneName = SceneManager.GetActiveScene().name;
        UIManager.Instance.UpdateSceneName(_sceneName);
    }

    public void RestartLevel()
    {
        _livesCount--;

        if (_livesCount > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            UIManager.Instance.UpdateCollectibleScoreUI(_collectibleCount);
        }
        else
        {
            _collectibleCount = 0;
            _livesCount = 3;
            SceneManager.LoadScene("Game Over");
        }
    }

    public void UpdateCollectibleAmount()
    {
        _collectibleCount++;
        UIManager.Instance.UpdateCollectibleScoreUI(_collectibleCount);
        Debug.Log("The score is: " + _collectibleCount);
    }

}
