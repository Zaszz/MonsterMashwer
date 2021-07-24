using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public void ClickStart()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickQuit()
    {
        Application.Quit();
    }
}
