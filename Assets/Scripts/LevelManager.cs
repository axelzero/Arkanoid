using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int brekeBlocks = 0;
                     private SceneLoader sceneLoader;

    [SerializeField, Range(0.1f, 2f)] private float _gameSpeed = 1f;

    [SerializeField] private int currentScore = 0;
    [SerializeField] private int pointsDestroy = 10;
    [SerializeField] private TextMeshProUGUI _txtScore;

    private void Awake()
    {
        int levelCount = FindObjectsOfType<LevelManager>().Length;
        if (levelCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        _txtScore.text = currentScore.ToString();
    }
    private void Update()
    {
        // Time.timeScale = _gameSpeed;
    }
    public void AddScore()
    {
        currentScore += pointsDestroy;
        _txtScore.text = currentScore.ToString();
    }
    public void CountUpOfBlocks() 
    {
        brekeBlocks++;
    }
    public void BlockDesroyed() 
    {
        brekeBlocks--;
        LoadNextLevel();
    }
    private void LoadNextLevel() 
    {
        if (brekeBlocks <= 0) 
        {
            sceneLoader.LoadNextScene();
        }
    }

    public void GameOver() 
    {
        Destroy(gameObject);
    }
}