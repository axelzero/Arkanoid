using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private float _mousePosX;
    private Vector2 padlePos;
    [SerializeField] float _minX, _maxX;
    [SerializeField] private float screenWidthInUnits = 16f;
    private void Start()
    {
        _maxX = screenWidthInUnits - 1f;
    }
    private void Update()
    {
        _mousePosX = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        GoToMousePosX();
    }
    private void GoToMousePosX()
    {
        padlePos = new Vector2(transform.position.x, transform.position.y);
        padlePos.x = Mathf.Clamp(_mousePosX, _minX, _maxX);
        transform.position = padlePos;
    }
}
