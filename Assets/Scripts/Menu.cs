using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.instance.bitcoins = 10000;
        SceneManager.LoadScene(4);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
