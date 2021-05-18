using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    public Button Exit;
    public Button PlayAgain;

    void Start()
    {
        PlayAgain.onClick.AddListener(LoadGame);
        Exit.onClick.AddListener(Quit);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Quit()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}
