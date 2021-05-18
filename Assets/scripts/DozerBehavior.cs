using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DozerBehavior : MonoBehaviour
{
    public GameObject cellToMove;
    public GameObject cellToAttack;
    public AudioClip audioClip;

    public bool selecionado = false;
    public bool realizouTurno = false;

    private bool playerAchado = false;
    private GameObject playerPieceEncontrado;
    private float menorDistancia = 100f;
    private GameObject playerMaisPerto;
    private GameObject cellMaisPerto;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("TurnManager").GetComponent<TurnManager>().playerTurn == false)
        {
            if (selecionado)
            {
                menorDistancia = 100f;
                Attack();

                selecionado = false;
            }
        }
    }

    private IEnumerator waitToMove()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip, 1);
        Instantiate(cellToMove, new Vector2(transform.position.x + 1, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x + 2, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 1, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 2, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x + 0, transform.position.y + 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x + 0, transform.position.y + 2), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 0, transform.position.y - 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 0, transform.position.y - 2), Quaternion.identity, gameObject.transform);
        

        yield return new WaitForSeconds(1.5f);

        GameObject[] playerPiecesPositions = GameObject.FindGameObjectsWithTag("Crater");
        float distance;
        playerMaisPerto = playerPiecesPositions[Random.Range(0, playerPiecesPositions.Length)];

        //foreach (var item in playerPiecesPositions)
        //{
        //    distance = Vector3.Distance(this.transform.position, item.transform.position);
        //    if (distance < menorDistancia)
        //    {
        //        menorDistancia = distance;
        //        playerMaisPerto = item;
        //    }
        //}

        GameObject[] cells = GameObject.FindGameObjectsWithTag("Cell");
        foreach (var item in cells)
        {
            if(item.GetComponent<cellCollision>().type == "move")
            {
                distance = Vector3.Distance(item.transform.position, playerMaisPerto.transform.position);
                if (distance < menorDistancia)
                {
                    menorDistancia = distance;
                    cellMaisPerto = item;
                }
            }
        }
        try
        {
            gameObject.transform.position = cellMaisPerto.transform.position;
        }
        catch
        {

        }

        StartCoroutine(waitToAttack());
    }

    IEnumerator waitToAttack()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip, 1);
        DestroyAllCells();
        Instantiate(cellToAttack, new Vector2(transform.position.x + 1, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x + 2, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x + 3, transform.position.y - 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x + 4, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x - 1, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x - 2, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x - 3, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x - 4, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x + 0, transform.position.y + 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x + 0, transform.position.y + 2), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x + 0, transform.position.y + 3), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x + 0, transform.position.y + 4), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x - 0, transform.position.y - 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x - 0, transform.position.y - 2), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x + 0, transform.position.y - 3), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x + 0, transform.position.y - 4), Quaternion.identity, gameObject.transform);

        yield return new WaitForSeconds(1.5f);

        realizouTurno = true;
    }

    void DestroyAllCells()
    {
        GameObject[] cells = GameObject.FindGameObjectsWithTag("Cell");
        foreach (var item in cells)
        {
            if (item.GetComponent<cellCollision>().type == "move")
                Destroy(item);
        }
    }

    void Attack()
    {
        
        DestroyAllCells();
        StartCoroutine(waitToMove());
    }
}
