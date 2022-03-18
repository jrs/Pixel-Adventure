using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float waitToRespawn;

    [SerializeField] int _collectibleCount = 0;
    [SerializeField] int _livesCount = 3;
    [SerializeField] Vector3 _respawnLocation;
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
        SceneManager.LoadScene("Level 1");
        UIManager.Instance.UpdateCollectibleScoreUI(_collectibleCount);
        StartCoroutine(RespawnPlayerRoutine());
    }

    public void UpdatePlayerRespawnLocation(Vector3 location)
    {
        _respawnLocation = location;
    }

    public void UpdateCollectibleAmount()
    {
        _collectibleCount++;
        UIManager.Instance.UpdateCollectibleScoreUI(_collectibleCount);
        Debug.Log("The score is: " + _collectibleCount);
    }

    public Vector3 SetPlayerStartPostion()
    {
        return _respawnLocation;
    }

    private IEnumerator RespawnPlayerRoutine()
    {
        //PlayerController.Instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(waitToRespawn - (1f / UIManager.Instance.fadeSpeed));

        UIManager.Instance.FadeToBlack();

        yield return new WaitForSeconds((1f / UIManager.Instance.fadeSpeed) + 0.2f);

        UIManager.Instance.FadeFromBlack();

        //PlayerController.Instance.gameObject.SetActive(true);
    }

}
