using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] private float _xPush = 5f;
    [SerializeField] private float _yPush = 15f;
    [SerializeField] private Paddle paddle;
                     private Vector2 paddleToBall;
                     private Rigidbody2D rb2d;
                     private bool _isBallOnStartPos = true;
                     private AudioSource audioSource;

    [SerializeField] private float _randomAngle = 0.2f;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        paddleToBall = transform.position - paddle.transform.position;

        audioSource = GetComponent<AudioSource>();
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
        Vector2 velocityTweak = new Vector2(Random.Range(0f, _randomAngle), Random.Range(0f, _randomAngle));

        if (!_isBallOnStartPos)
        {
            AudioClip clip = clips[Random.Range(0, clips.Length)];
            audioSource.PlayOneShot(clip);
            rb2d.velocity += velocityTweak;
        }
    }
}