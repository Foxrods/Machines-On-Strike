using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellCollision : MonoBehaviour
{
    public string type;

    private bool colidiuComPlayer = false;
    private GameObject inimigoColidido;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            colidiuComPlayer = true;
        }

        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Player")
        {
            inimigoColidido = col.gameObject;
        }

        if (col.gameObject.name != "Tilemap")
        {
            if((col.gameObject.tag == "Enemy" || col.gameObject.tag == "Player" || col.gameObject.tag == "Crater") && type=="move")
                Destroy(gameObject);
            if(col.gameObject.name == "Border")
                Destroy(gameObject);
        }

        if(type == "shield" && col.gameObject.tag == "Cell")
        {
            Destroy(col.gameObject);
        }

    }

    public bool ColidiuComPlayer()
    {
        return colidiuComPlayer;
    }

    public GameObject InimigoColidido()
    {
        return inimigoColidido;
    }

}
