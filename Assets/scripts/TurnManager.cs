using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public int turn = 1;
    public GameObject[] playerPieces;
    public GameObject titan;
    public GameObject crawler;
    public GameObject dozer;
    public Text turnoCounter;
    public Text phase;
    public AudioClip attackSound;
    public InGameDialogue inGameDialogue;

    public bool playerTurn = false; //false = enemy turn

    private bool botsAtacando = false;

    void Update()
    {
        if (playerTurn)
        {
            phase.text = "Your Phase";
        }
        if (Input.GetKeyDown("space") && playerTurn)
        {
            turn++;
            Invoke("chamaDialogo", 0.2f);
            
            phase.text = "Enemy Phase";
            Debug.Log("próximo turno");
            playerTurn = false;

            gameObject.GetComponent<AudioSource>().PlayOneShot(attackSound, 1);

            StartCoroutine(changeTurn());

            GameObject[] cells = GameObject.FindGameObjectsWithTag("Cell");
            GameObject[] cargos = GameObject.FindGameObjectsWithTag("Crater");
            foreach (var item in cells)
            {
                foreach (var cargo in cargos)
                {
                    if (item.transform.position == cargo.transform.position && item.GetComponent<cellCollision>().type == "attack")
                        Destroy(cargo);
                }
    
                Destroy(item);
            }
        }
        else if (!playerTurn)
        {
            if(!botsAtacando)
                StartCoroutine(moveTitan());
        }
        
    }

    IEnumerator moveTitan()
    {
        botsAtacando = true;
        titan.GetComponent<TitanBehavior>().selecionado = true;
        yield return new WaitForSeconds(3.1f);
        StartCoroutine(moveCrawler());
    }

    IEnumerator moveCrawler()
    {
        crawler.GetComponent<CrawlerBehavior>().selecionado = true;
        yield return new WaitForSeconds(3.1f);
        StartCoroutine(moveDozer());
    }

    IEnumerator moveDozer()
    {
        dozer.GetComponent<DozerBehavior>().selecionado = true;
        yield return new WaitForSeconds(3.1f);
        playerTurn = true;
        botsAtacando = false;
    }

    void chamaDialogo()
    {
        inGameDialogue.chamaDialogo();
    }

    IEnumerator changeTurn()
    {
        yield return new WaitForSeconds(0.5f);
        turnoCounter.text = "Turn: " + turn;
    }

}
