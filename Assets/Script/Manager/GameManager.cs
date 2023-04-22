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
        Time.timeScale = 1f;
        isPlaying = false;
        ChangeScene(0);
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
        isPlaying = true;
        Time.timeScale=1.0f;
        DataManager.Instance.resetSaphire();
        UIManager.Instance.GamePanel.updateEnergy(0);
        UIManager.Instance.GamePanel.loadData();
        UIManager.Instance.GamePanel.resetGamePanel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerLives.updateHealthDelegate(6);
    }
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
