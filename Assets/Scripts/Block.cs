using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private ParticleSystem vfxExplosion;
    [SerializeField] private ParticleSystem vfxExplosionUnBreak;
    [SerializeField] private AudioClip _brakeClip;
                     private LevelManager level;

    private void Start()
    {
        level = FindObjectOfType<LevelManager>();
        if (tag == "Breakable") 
        {
            level.CountUpOfBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.tag == "Breakable")
        {
            BlockDestroy();
        }
        else if (gameObject.tag == "UnBreakable") 
        {
            Explosion(false);
            PlaySound();
        }
    }

    private void BlockDestroy()
    {
        level.AddScore();
        Explosion(true);
        PlaySound();
        level.BlockDesroyed();
        Destroy(gameObject);
    }

    private void PlaySound()
    {
        AudioSource.PlayClipAtPoint(_brakeClip, transform.position);
    }

    private void Explosion(bool breakable) 
    {
        if (breakable)
        {
            var explosion = Instantiate(vfxExplosion, transform.position, Quaternion.identity);
            Destroy(explosion.gameObject, explosion.main.duration);
        }
        else if(!breakable) 
        {
            var explosion = Instantiate(vfxExplosionUnBreak, transform.position, Quaternion.identity);
            Destroy(explosion.gameObject, explosion.main.duration);
        }
        
    }
}
