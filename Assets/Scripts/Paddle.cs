using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //configuration parameters
    private float _mousePosX;
    private Vector2 padlePos;
    [SerializeField] float _minX, _maxX;
    [SerializeField] private float screenWidthInUnits = 16f;

    //cached references
    private Ball ball;
    private LevelManager levelManager;
    private void Start()
    {
        _maxX = screenWidthInUnits - 1f;
        ball = FindObjectOfType<Ball>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    private void Update()
    {
        GoToMousePosX();
    }
    private void GoToMousePosX()
    {
        padlePos = new Vector2(transform.position.x, transform.position.y);
        padlePos.x = Mathf.Clamp(GetPosX(), _minX, _maxX);
        transform.position = padlePos;
    }

    private float GetPosX() 
    {
        if (levelManager.AutoPlay())
        {
            return ball.transform.position.x;
        }
        else 
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
