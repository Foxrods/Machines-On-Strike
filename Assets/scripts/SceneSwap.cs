using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    public Button Exit;
    public Button Play;
    void Start()
    {
        Play.onClick.AddListener(LoadGame);
        Exit.onClick.AddListener(Quit);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Quit()
    {
        Application.Quit();
    }
   
}
