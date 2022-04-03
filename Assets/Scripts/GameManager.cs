using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] int _collectibleCount = 0;
    [SerializeField] int _livesCount = 3;
    [SerializeField] string _sceneName = "Name";

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void RestartLevel()
    {
        SetPlayerLives();
    }

    public void SetPlayerLives()
    {
        _livesCount--;

        if (_livesCount > 0)
        {
            FindObjectOfType<LevelLoader>().ReloadLevel();
            UIManager.Instance.UpdateCollectibleScoreUI(_collectibleCount);
        }
        else
        {
            SetNewGame();
            SceneManager.LoadScene("Game Over");
        }
    }

    public void SetNewGame()
    {
        _collectibleCount = 0;
        _livesCount = 3;
    }

    public int GetPlayerLives()
    {
        return _livesCount;
    }

    public void SetCollectibleAmount()
    {
        _collectibleCount++;
    }

    public int GetCollectibleAmount()
    {
        return _collectibleCount;
    }

    public void SetCurrentSceneName()
    {
        _sceneName = SceneManager.GetActiveScene().name;
    }

    public string GetCurrentSceneName()
    {
        SetCurrentSceneName();
        return _sceneName;
    }
}
