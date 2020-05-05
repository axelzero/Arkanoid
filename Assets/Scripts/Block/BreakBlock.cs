using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBlock
{
    public class BreakBlock : BlockBasic
    {
        //configuration parameters
        [SerializeField] private int _timesHit; //for debug
        [SerializeField] private Sprite[] _hitSprites;

        private void Start()
        {
            InitStart();
            _level.CountUpOfBlocks();
            _level.AddBlockToList(this._spriteRenderer);
        }

        protected void BlockDestroy()
        {
            _timesHit++;
            int _maxHits = _hitSprites.Length + 1;

            _level.AddScore();

            if (_timesHit >= _maxHits)
            {
                Explosion();
                PlaySound();
                _level.BlockDesroyed();
                Destroy(gameObject);
            }
            else
            {
                ShowNextHitSprite();
            }
        }

        private void ShowNextHitSprite()
        {
            int index = _timesHit - 1;
            if (_hitSprites[index] != null)
                _spriteRenderer.sprite = _hitSprites[index];
        }

        public override void OnCollison()
        {
            BlockDestroy();
        }
    }
}