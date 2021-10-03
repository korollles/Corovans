using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Robber : MonoBehaviour
{
    public int sceneLoad;

    void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(sceneLoad);
    }
}
