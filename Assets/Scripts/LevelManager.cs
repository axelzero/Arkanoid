using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int brekeBlocks = 0;
    [SerializeField] private List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();
                     private SceneLoader sceneLoader;

    [SerializeField, Range(0.1f, 2f)] private float _gameSpeed = 1f;

    [SerializeField] private int currentScore = 0;
    [SerializeField] private int pointsDestroy = 10;
    [SerializeField] private TextMeshProUGUI _txtScore;
    [SerializeField] private bool _isAutoPlay;

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
         Time.timeScale = _gameSpeed;
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
    public void AddBlockToList(SpriteRenderer obj) 
    {
        spriteRenderers.Add(obj);
    }
    public List<SpriteRenderer> GetBlockList() 
    {
        return spriteRenderers;
    }
    public void BlockDesroyed() 
    {
        brekeBlocks--;
        spriteRenderers.Clear();
        LoadNextLevel();
    }
    private void LoadNextLevel() 
    {
        if (brekeBlocks <= 0) 
        {
            sceneLoader.LoadNextScene();
        }
    }
    public bool AutoPlay() 
    {
        return _isAutoPlay;
    }
    public void BtnAutoPlay() 
    {
        if (_isAutoPlay)
        {
            _isAutoPlay = false;
        }
        else 
        {
            _isAutoPlay = true;
        }
    }
    public void GameOver() 
    {
        Destroy(gameObject);
    }
}