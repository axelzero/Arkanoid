using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] private float _xPush = 2f;
    [SerializeField] private float _yPush = 15f;
    [SerializeField] private Paddle paddle;
                     private Vector2 paddleToBall;
                     private Rigidbody2D rb2d;
                     private bool _isBallOnStartPos = true;
                     private AudioSource audioSource;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        paddleToBall = transform.position - paddle.transform.position;

        audioSource = GetComponent<AudioSource>();
        _xPush = Random.Range(-25f, 25f);
    }
    private void Update()
    {
        OnStartGame();
    }
    private void OnStartGame()
    {
        if (_isBallOnStartPos)
        {
            LockBall();
            LanchOnClick();
        }
    }
    private void LanchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb2d.velocity = new Vector2(_xPush, _yPush);
            _isBallOnStartPos = false;
        }
    }
    private void LockBall()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBall;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_isBallOnStartPos)
        {
            AudioClip clip = clips[Random.Range(0, clips.Length)];
            audioSource.PlayOneShot(clip);
        }
    }
}