using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public Text turnCount;
    public AudioSource audio;
    public AudioClip gameOverSound;
    public AudioClip victorySound;
    public GameObject gameOverScreen;
    public GameObject HUD;
    public GameObject nextScreen;

    private bool venceu = false;
    private bool perdeu = false;

    void Update()
    {
        
        GameObject[] cargos = GameObject.FindGameObjectsWithTag("Crater");
        
        if(cargos.Length == 0 && !perdeu)
        {
            Debug.Log("Game Over");
            perdeu = true;

            audio.clip = gameOverSound;
            audio.volume = 0.25f;
            
            audio.PlayOneShot(gameOverSound, 0.25f);

            GameObject.Find("TurnManager").SetActive(false);

            GameObject.Find("Guard").GetComponent<playerPiece1Movement>().enabled = false;
            GameObject.Find("Vigilant").GetComponent<VigilantMovement>().enabled = false;
            GameObject.Find("Blazer").GetComponent<BlazerMovement>().enabled = false;
            GameObject.Find("Crawler").GetComponent<CrawlerBehavior>().enabled = false;
            GameObject.Find("Dozer").GetComponent<DozerBehavior>().enabled = false;
            GameObject.Find("Titan").GetComponent<TitanBehavior>().enabled = false;

            gameOverScreen.SetActive(true);
            HUD.SetActive(false);
        }

        if (turnCount.text == "Turn: 10" && !venceu)
        {
            Debug.Log("You Win!!!");

            audio.clip = victorySound;
            audio.volume = 0.4f;

            audio.PlayOneShot(victorySound, 0.4f);

            GameObject.Find("TurnManager").SetActive(false);

            GameObject.Find("Guard").GetComponent<playerPiece1Movement>().enabled = false;
            GameObject.Find("Vigilant").GetComponent<VigilantMovement>().enabled = false;
            GameObject.Find("Blazer").GetComponent<BlazerMovement>().enabled = false;
            GameObject.Find("Crawler").GetComponent<CrawlerBehavior>().enabled = false;
            GameObject.Find("Dozer").GetComponent<DozerBehavior>().enabled = false;
            GameObject.Find("Titan").GetComponent<TitanBehavior>().enabled = false;

            nextScreen.SetActive(true);
            HUD.SetActive(false);

            if(!venceu)
                StartCoroutine(waitForNextScreen());
        }
    }

    IEnumerator waitForNextScreen()
    {
        venceu = true;
        yield return new WaitForSeconds(4.8f);
        SceneManager.LoadScene("Level1");
    }
    
}
