using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private GameObject Levels;
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Reload();
        }
        else if (Input.GetKey(KeyCode.P))
        {
            Pause();
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            QuitButton();
        }
    }


    public void LoadScene(int SceneId)
    {

        StartCoroutine(LoadSceneAsync(SceneId));
        Time.timeScale = 1;

    }
     IEnumerator LoadSceneAsync(int SceneId)
    {
   
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneId);
        Levels.SetActive(true);
        yield return null;
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Unpause()
    {
        Time.timeScale = 1;
    }
    public void Reload()
    {

        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
    }
    public void LevelNext()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = CurrentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
    public void QuitButton()
    {
        Debug.Log("I Quit");
        Application.Quit();
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
