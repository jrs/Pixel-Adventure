using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public float TransitionTime = 1f;

    private Animator _transition;

    // Start is called before the first frame update
    void Start()
    {
        _transition = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ReloadLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //play animation
        _transition.SetTrigger("Start");

        //wait
        yield return new WaitForSeconds(TransitionTime);

        //load scene
        SceneManager.LoadScene(levelIndex);
    }
}
