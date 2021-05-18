using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialDialogueManager : MonoBehaviour
{
    
    public Text dialogue1;
    [TextArea(5, 10)]
    public string fullText;
    public AudioSource source;
    public AudioClip[] audios;
    public Button Next;
    public GameObject tutorialText;

    private bool canPlay = false;

    void Start()
    {
        StartCoroutine(StartDialogue());
        Next.onClick.AddListener(ShowInstructions);
    }


    IEnumerator StartDialogue()
    {
        dialogue1.text = "";
        int i = 0;
        foreach (char letter in fullText.ToCharArray())
        {
            dialogue1.text += letter;
            if (i % 6 == 0)
                source.PlayOneShot(audios[(int)letter % audios.Length], 1);
            yield return new WaitForSeconds(0.016f);
            i++;
            //if (i > sentence.Length / 3)
            //    canSkip = true;
        }
    }

    void ShowInstructions()
    {
        if (!canPlay)
        {
            StopAllCoroutines();
            GameObject.Find("Board").SetActive(false);
            GameObject.Find("Portrait").SetActive(false);
            tutorialText.SetActive(true);
            canPlay = true;
            GameObject myEventSystem = GameObject.Find("EventSystem");
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        }
        else
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
