using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBlock
{
    public class BlockShow : MonoBehaviour
    {
        LevelManager levelManager;

        private void Start()
        {
            levelManager = FindObjectOfType<LevelManager>();

            StartCoroutine(EnebleSprites(levelManager.GetBlockList()));
        }

        public IEnumerator EnebleSprites(List<SpriteRenderer> list)
        {
            while (list.Count <= 0) 
            {
                yield return new WaitForSeconds(0.5f);
            }
            for (int i = 0; i < list.Count; i++)
            {
                list[i].enabled = true;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}