using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VigilantMovement : MonoBehaviour
{
    public GameObject cellToMove;
    public GameObject cellToAttack;
    public GameObject shield;
    public Image unitFrame;
    public Sprite moveIcon;
    public Image moveFrame;
    public Sprite skillIcon;
    public Image skillFrame;
    public Sprite unitIcon;
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
                        && hit.collider.name != gameObject.name + "cell2move"
                        && hit.collider.name != gameObject.name + "cell2attack")
                    {
                        Debug.Log("entrei");

                        DestroyAllCells2Move();
                        DestroyAllCells2Attack();

                        mostrandoAtaque = false;
                        mostrandoMovimentos = false;
                        gameObject.GetComponent<SpriteRenderer>().color = corInicial;

                    }
                }
                catch
                {
                    Debug.Log("entrei");

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
                    Debug.Log("entrei");

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
                        && hit.collider.name != gameObject.name + "cell2move"
                        && hit.collider.name != gameObject.name + "cell2attack")
                    {
                        Debug.Log("entrei");

                        DestroyAllCells2Move();
                        DestroyAllCells2Attack();

                        mostrandoAtaque = false;
                        mostrandoMovimentos = false;
                        gameObject.GetComponent<SpriteRenderer>().color = corInicial;

                    }
                }
                catch
                {
                    Debug.Log("entrei");

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
                try
                {
                    if (hit.collider.tag == "Cell")
                    {
                        Debug.Log("ATACANDOOOOOOOOOO");

                        //DestroyAllCells2Move();
                        DestroyAllCells2Attack();
                        Ataque();

                        atacou = true;
                        mostrandoAtaque = false;
                        mostrandoMovimentos = false;
                        gameObject.GetComponent<SpriteRenderer>().color = corInicial;
                    }
                    else if (hit.collider.name != gameObject.name
                        && hit.collider.name != gameObject.name + "cell2move"
                        && hit.collider.name != gameObject.name + "cell2attack")
                    {
                        Debug.Log("entrei");

                        DestroyAllCells2Move();
                        DestroyAllCells2Attack();

                        mostrandoAtaque = false;
                        mostrandoMovimentos = false;
                        gameObject.GetComponent<SpriteRenderer>().color = corInicial;

                    }
                }
                catch
                {
                    Debug.Log("entrei");

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
                Name.text = "Vigilant";
                Skill.text = "Shield";
                SkillDescription.text = "Creates a shild barrier around this unity, preventing any damage to those tiles";
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
        Instantiate(cellToMove, new Vector2(transform.position.x + 1, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x + 2, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 1, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 2, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x + 0, transform.position.y + 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x + 0, transform.position.y + 2), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 0, transform.position.y - 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 0, transform.position.y - 2), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x + 0, transform.position.y + 3), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x + 0, transform.position.y + 4), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 0, transform.position.y - 3), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 0, transform.position.y - 4), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x + 3, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x + 4, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 3, transform.position.y - 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 4, transform.position.y - 0), Quaternion.identity, gameObject.transform);

        Instantiate(cellToMove, new Vector2(transform.position.x + 1, transform.position.y + 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x + 2, transform.position.y + 2), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 1, transform.position.y - 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 2, transform.position.y - 2), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x + 1, transform.position.y - 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 1, transform.position.y + 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x - 2, transform.position.y + 2), Quaternion.identity, gameObject.transform);
        Instantiate(cellToMove, new Vector2(transform.position.x + 2, transform.position.y - 2), Quaternion.identity, gameObject.transform);
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
        Instantiate(cellToAttack, new Vector2(transform.position.x + 1, transform.position.y + 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x - 1, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x - 1, transform.position.y + 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x + 1, transform.position.y - 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x + 0, transform.position.y - 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x - 1, transform.position.y - 1), Quaternion.identity, gameObject.transform);
        Instantiate(cellToAttack, new Vector2(transform.position.x - 0, transform.position.y + 1), Quaternion.identity, gameObject.transform);
        GameObject[] cells = GameObject.FindGameObjectsWithTag("Cell");

        foreach (var item in cells)
        {
            item.name = gameObject.name + "cell2attack";

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
        GameObject[] cells = GameObject.FindGameObjectsWithTag("Cell");

        foreach (var item in cells)
        {
            if (item.name == gameObject.name + "cell2attack")
                if (item.layer == 9)
                    Destroy(item);

        }
    }

    void DestroyAllCells()
    {
        GameObject[] cells = GameObject.FindGameObjectsWithTag("Cell");
        foreach (var item in cells)
        {
            if (item.layer == 9)
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

    void Ataque()
    {
        Instantiate(shield, new Vector2(transform.position.x + 1, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(shield, new Vector2(transform.position.x + 1, transform.position.y + 1), Quaternion.identity, gameObject.transform);
        Instantiate(shield, new Vector2(transform.position.x - 1, transform.position.y + 0), Quaternion.identity, gameObject.transform);
        Instantiate(shield, new Vector2(transform.position.x - 1, transform.position.y + 1), Quaternion.identity, gameObject.transform);
        Instantiate(shield, new Vector2(transform.position.x + 1, transform.position.y - 1), Quaternion.identity, gameObject.transform);
        Instantiate(shield, new Vector2(transform.position.x + 0, transform.position.y - 1), Quaternion.identity, gameObject.transform);
        Instantiate(shield, new Vector2(transform.position.x - 1, transform.position.y - 1), Quaternion.identity, gameObject.transform);
        Instantiate(shield, new Vector2(transform.position.x - 0, transform.position.y + 1), Quaternion.identity, gameObject.transform);
    }
}
