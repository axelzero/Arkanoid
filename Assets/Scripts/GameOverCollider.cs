using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCollider : MonoBehaviour
{
    [SerializeField] private string sceneGameOverName;
    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(sceneGameOverName);
    }
}
