using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private LevelManager levelManager;
    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    public void LoadNextScene() 
    {
        int currentSceneId = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneId + 1);
    }
    public void LoadStartScene() 
    {
        SceneManager.LoadScene(0);
        levelManager.GameOver();
    }
    public void Quit() 
    {
        Application.Quit();
    }
}
