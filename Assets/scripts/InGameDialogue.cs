using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameDialogue : MonoBehaviour
{
    public Text dialogue1;
    [TextArea(2, 10)]
    public string text1; //falta 3 caixas
    [TextArea(2, 10)]
    public string text2; //falta 3 turnos
    [TextArea(2, 10)]
    public string text3; //falta 1 turno
    [TextArea(2, 10)]
    public string text4; //falta uma caixa
    public TurnManager turnManager;
    public AudioSource source;
    public AudioClip[] audios;
    public GameObject board;

    private bool chamouTexto1 = false;
    private bool chamouTexto4 = false;

    // Update is called once per frame
    public void chamaDialogo()
    {
        
        if (turnManager.turn == 9)
        {
            StartCoroutine(StartDialogue(text3));
        }
        else if(turnManager.turn == 6)
        {
            StartCoroutine(StartDialogue(text2));
            
        }
        else if (GameObject.FindGameObjectsWithTag("Crater").Length == 3 && chamouTexto1 == false)
        {
            StartCoroutine(StartDialogue(text1));
            chamouTexto1 = true;
        }
        else if (GameObject.FindGameObjectsWithTag("Crater").Length == 1 && chamouTexto4 == false)
        {
            StartCoroutine(StartDialogue(text4));
            chamouTexto4 = true;
        }
    }

    IEnumerator StartDialogue(string fullText)
    {
        board.SetActive(true);
        dialogue1.text = "";
        int i = 0;
        foreach (char letter in fullText.ToCharArray())
        {
            dialogue1.text += letter;
            if (i % 6 == 0)
                source.PlayOneShot(audios[(int)letter % audios.Length], 1);
            yield return new WaitForSeconds(0.016f);
            i++;
            
        }
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        board.SetActive(false);
    }
}
