using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBlock
{
    public class BlockBasic : MonoBehaviour/*, IDamage*/
    {
        //cached references
                        protected          LevelManager            _level;
                        protected          SpriteRenderer          _spriteRenderer;

        //configuration parameters
        [SerializeField] private            ParticleSystem         _vfxExplosion;
        [SerializeField] private            AudioClip              _brakeClip;

        protected void InitStart()
        {
            _level = FindObjectOfType<LevelManager>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.enabled = false;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnCollison();
        }

        protected void PlaySound()
        {
            AudioSource.PlayClipAtPoint(_brakeClip, transform.position);
        }
        protected void Explosion()
        {
                var explosion = Instantiate(_vfxExplosion, transform.position, Quaternion.identity);
                Destroy(explosion.gameObject, explosion.main.duration);
        }

        public virtual void OnCollison()
        {
            Debug.LogError("Empty !!!");
        }
    }
}