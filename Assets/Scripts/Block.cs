using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip _brakeClip;
    private void OnCollisionEnter2D(Collision2D other)
    {
        AudioSource.PlayClipAtPoint(_brakeClip, transform.position);
        Destroy(gameObject, 0.05f);
    }
}
