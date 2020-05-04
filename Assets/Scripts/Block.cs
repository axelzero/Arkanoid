using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip _brakeClip;
                     private LevelManager level;

    private void Start()
    {
        level = FindObjectOfType<LevelManager>();
        level.CountUpOfBlocks();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        BlockDestroy();
    }

    private void BlockDestroy()
    {
        level.AddScore();
        AudioSource.PlayClipAtPoint(_brakeClip, transform.position);
        level.BlockDesroyed();
        Destroy(gameObject);
    }
}
