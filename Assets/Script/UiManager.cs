using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject restartPanel;
    [SerializeField] private GameObject startPanel;

    private bool stuck = false;
    public void Pause_scene() 
    {
        stuck = true;
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
       // Debug.Log("game paused");
    } 
    public void Resume_scene() 
    {
        stuck = false;
        Time.timeScale = 1f;
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);
      //  Debug.Log("game resumed");
    }

    public bool ReturnStuck() 
    {
        return stuck;
    }
    public void StartPanel()
    {
        Destroy(startPanel);
    }
    public void RestartScene() 
    {   
        restartPanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
