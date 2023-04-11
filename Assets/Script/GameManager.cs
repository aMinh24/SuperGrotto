using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : BaseManager <GameManager>
{
    private bool isPlaying = false;
    public bool IsPlaying => isPlaying;
    public void StartGame()
    {
        isPlaying = true;
        Time.timeScale = 1.0f;
    }
    public void PauseGame()
    {
        if (isPlaying)
        {
            isPlaying = false;
            Time.timeScale = 0f;
        }
    }
    public void Resume()
    {
        isPlaying=true;
        Time.timeScale = 1.0f;
    }
    public void RestartGame()
    {
        ChangeScene("Menu");
    }
    public void EndGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
