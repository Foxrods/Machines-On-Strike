using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlazerMovement : MonoBehaviour
{
    public GameObject cellToMove;
    public GameObject cellToAttack;
    public Image unitFrame;
    public Sprite unitIcon;
    public Sprite moveIcon;
    public Image moveFrame;
    public Sprite skillIcon;
    public Image skillFrame;
    public Text Name;
    public Text Skill;
    public Text SkillDescription;
    public AudioClip audioClip;

    private bool mostrandoAtaque = false;
    private bool mostrandoMovimentos = false;
    private bool moveu = false;
    private bool atacou = false;
    private Color corInicial;
    // Start is called before the first frame update
    void Start()
    {
        corInicial = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        if (GameObject.Find("TurnManager").GetComponent<TurnManager>().playerTurn)
        {
            if (Input.GetMouseButtonDown(0) && !mostrandoMovimentos && !moveu)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

                try
                {
                    if (hit.collider.name == gameObject.name)
                    {
                        DestroyAllCells2Attack();
                        DestroyAllCells2Move();

                        Debug.Log("movimento");

                        mostrandoMovimentos = true;
                        mostrandoAtaque = false;
                        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                        putCellsToMove();
                        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip, 1);
                    }
                    else if (hit.collider.name != gameObject.name
                        && !hit.collider.name.Contains(gameObject.name + "cell2move")
                        && !hit.collider.name.Contains(gameObject.name + "cell2attack"))
                    {
                        Debug.Log("entrei aqui 5");

                        DestroyAllCells2Move();
                        DestroyAllCells2Attack();

                        mostrandoAtaque = false;
                        mostrandoMovimentos = false;
                        gameObject.GetComponent<SpriteRenderer>().color = corInicial;

                    }
                }
                catch
                {
                    Debug.Log("entrei aqui 4");

                    DestroyAllCells2Move();
                    DestroyAllCells2Attack();

                    mostrandoAtaque = false;
                    mostrandoMovimentos = false;
                    gameObject.GetComponent<SpriteRenderer>().color = corInicial;
                }


            }
            if (Input.GetMouseButtonDown(1) && !mostrandoAtaque && !atacou)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                try
                {
                    if (hit.collider.name == gameObject.name)
                    {
                        DestroyAllCells2Attack();
                        DestroyAllCells2Move();

                        Debug.Log("ataque");

                        mostrandoAtaque = true;
                        mostrandoMovimentos = false;
                        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                        putCellsToAttack();
                        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip, 1);
                    }
                }
                catch
                {
                    Debug.Log("entrei aqui 3");

                    DestroyAllCells2Move();
                    DestroyAllCells2Attack();

                    mostrandoAtaque = false;
                    mostrandoMovimentos = false;
                    gameObject.GetComponent<SpriteRenderer>().color = corInicial;
                }


            }
            if (Input.GetMouseButtonDown(0) && mostrandoMovimentos && !moveu)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                try
                {
                    if (hit.collider.tag == "Cell")
                    {
                        gameObject.transform.position = hit.transform.position;

                        DestroyAllCells2Move();
                        //DestroyAllCells2Attack();

                        moveu = true;
                        mostrandoAtaque = false;
                        mostrandoMovimentos = false;
                        gameObject.GetComponent<SpriteRenderer>().color = corInicial;
                    }
                    else if (hit.collider.name != gameObject.name
                        && !hit.collider.name.Contains(gameObject.name + "cell2move")
                        && !hit.collider.name.Contains(gameObject.name + "cell2attack"))
                    {
                        Debug.Log("entrei aqui 1");

                        DestroyAllCells2Move();
                        DestroyAllCells2Attack();

                        mostrandoAtaque = false;
                        mostrandoMovimentos = false;
                        gameObject.GetComponent<SpriteRenderer>().color = corInicial;

                    }
                }
                catch
                {
                    Debug.Log("entrei aqui 2");

                    DestroyAllCells2Move();
                    DestroyAllCells2Attack();

                    mostrandoAtaque = false;
                    mostrandoMovimentos = false;
                    gameObject.GetComponent<SpriteRenderer>().color = corInicial;
                }
            }
            if (Input.GetMouseButtonDown(0) && mostrandoAtaque && !atacou)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                Debug.Log("era p atacar");
                try
                {
                    Debug.Log(hit.collider.name);
                    if (hit.collider.tag == "Enemy")
                    {
                        Debug.Log("ATACANDOOOOOOOOOO");

                        DestroyAllCells2Attack();
                        AtaqueDireto((hit.collider.name));

                        atacou = true;
                        mostrandoAtaque = false;
                        mostrandoMovimentos = false;
                        gameObject.GetComponent<SpriteRenderer>().color = corInicial;
                    }
                    else if (hit.collider.tag == "Cell")
                    {
                        Debug.Log("ATACANDOOOOOOOOOO");

                        //DestroyAllCells2Move();
                        DestroyAllCells2Attack();
                        Ataque((hit.collider.name));

                        atacou = true;
                        mostrandoAtaque = false;
                        mostrandoMovimentos = false;
                        gameObject.GetComponent<SpriteRenderer>().color = corInicial;
                    }
                    else if (hit.collider.name != gameObject.name
                        && !hit.collider.name.Contains(gameObject.name + "cell2move")
                        && !hit.collider.name.Contains(gameObject.name + "cell2attack"))
                    {
                        Debug.Log("entrei no else");

                        DestroyAllCells2Move();
                        DestroyAllCells2Attack();

                        mostrandoAtaque = false;
                        mostrandoMovimentos = false;
                        gameObject.GetComponent<SpriteRenderer>().color = corInicial;

                    }
                }
                catch
                {
                    Debug.Log("entrei no catch");

                    DestroyAllCells2Move();
                    DestroyAllCells2Attack();

                    mostrandoAtaque = false;
                    mostrandoMovimentos = false;
                    gameObject.GetComponent<SpriteRenderer>().color = corInicial;
                }
            }
            if (mostrandoAtaque || mostrandoMovimentos)
            {
                unitFrame.sprite = unitIcon;
                Name.text = "Levitator";
                Skill.text = "Swap Places";
                SkillDescription.text = "Select a unit to swap places";
                moveFrame.sprite = moveIcon;
                skillFrame.sprite = skillIcon;
            }
            
        }
        else
        {
            moveu = false;
            atacou = false;
            mostrandoAtaque = false;
            mostrandoMovimentos = false;
            gameObject.GetComponent<SpriteRenderer>().color = corInicial;
            DestroyAllCells2Move();
            DestroyAllCells2Attack();
        }
        
    }

    void putCellsToMove()
    {
        DestroyAllCells();
        Instantiate(cellToMove, new Vector2(transform.position.x + 1, transform.position.y + 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x + 2, transform.position.y + 2), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 1, transform.position.y - 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 2, transform.position.y - 2), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x + 3, transform.position.y + 3), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x + 4, transform.position.y + 4), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 3, transform.position.y - 3), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 4, transform.position.y - 4), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x + 1, transform.position.y - 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x + 2, transform.position.y - 2), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 1, transform.position.y + 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 2, transform.position.y + 2), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x + 3, transform.position.y - 3), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x + 4, transform.position.y - 4), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 3, transform.position.y + 3), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 4, transform.position.y + 4), Quaternion.identity, gameObject.transform);

        GameObject[] cells = GameObject.FindGameObjectsWithTag("Cell");

        foreach (var item in cells)
        {
            item.name = gameObject.name + "cell2move";

        }
    }

    void putCellsToAttack()
    {
        DestroyAllCells();
        Instantiate(cellToAttack, new Vector2(transform.position.x + 1, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x + 2, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x - 1, transform.position.y - 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x - 2, transform.position.y - 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x + 3, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x + 4, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x - 3, transform.position.y - 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x - 4, transform.position.y - 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x + 0, transform.position.y - 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x + 0, transform.position.y - 2), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x - 0, transform.position.y + 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x - 0, transform.position.y + 2), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x + 0, transform.position.y - 3), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x + 0, transform.position.y - 4), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x - 0, transform.position.y + 3), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x - 0, transform.position.y + 4), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x + 0, transform.position.y - 5), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x - 0, transform.position.y + 5), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x + 5, transform.position.y - 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x - 5, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        GameObject[] cells = GameObject.FindGameObjectsWithTag("Cell");

        int i = 0;
        foreach (var item in cells)
        {
            item.name = gameObject.name + "cell2attack" + i;
            i++;
        }
    }

    void DestroyAllCells2Move()
    {
        GameObject[] cells = GameObject.FindGameObjectsWithTag("Cell");

        foreach (var item in cells)
        {
            if (item.name == gameObject.name + "cell2move")
                if (item.layer == 9)
                    Destroy(item);

        }
    }

    void DestroyAllCells2Attack()
    {
        //GameObject[] cells = GameObject.FindGameObjectsWithTag("Cell");

        //foreach (var item in cells)
        //{
        //    if (item.name == gameObject.name + "cell2attack")
        //        if (item.layer == 9)
        //            Destroy(item);

        //}
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
    }

    void DestroyAllCells()
    {
        GameObject[] cells = GameObject.FindGameObjectsWithTag("Cell");
        foreach (var item in cells)
        {
            if(item.layer == 9)
                Destroy(item);
        }
    }

    public bool getMoveu()
    {
        return moveu;
    }

    public bool getAtacou()
    {
        return atacou;
    }

    void Ataque(string name)
    {
        GameObject collided = GameObject.Find(name);
        Debug.Log(name);
        GameObject inimigo = collided.GetComponent<cellCollision>().InimigoColidido();
        if (inimigo != null)
        {
            Vector2 inimigoPos = inimigo.transform.position;
            Vector2 blazerPos = gameObject.transform.position;
            gameObject.transform.position = inimigoPos;
            inimigo.transform.position = blazerPos;
        }
    }

    void AtaqueDireto(string name)
    {
        GameObject inimigo = GameObject.Find(name);
        
        Vector2 inimigoPos = inimigo.transform.position;
        Vector2 blazerPos = gameObject.transform.position;
        gameObject.transform.position = inimigoPos;
        inimigo.transform.position = blazerPos;
        
    }

}
