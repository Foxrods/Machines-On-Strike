using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraterSpawn : MonoBehaviour
{
    public GameObject crater;

    void Start()
    {
        List<Vector2> list = new List<Vector2>();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var item in enemies)
        {
            list.Add(item.transform.position);
        }
        GameObject[] pieces = GameObject.FindGameObjectsWithTag("Player");
        foreach (var item in pieces)
        {
            list.Add(item.transform.position);
        }
        while (list.Count < 12) // 3 ja sao inimigos, 3 são players, sobram 6 caixas
        {
            Vector2 vetor = new Vector2(Random.Range(-5, 4) + 0.5f, Random.Range(-4, 3) + 0.5f);
            
            if(checkValues(vetor, list))
            {
                list.Add(vetor);
                Instantiate(crater, vetor, Quaternion.identity);
            }
               
        }
    }

    bool checkValues(Vector2 vetor, List<Vector2> list)
    {
        foreach (var item in list)
        {
            if (item.x == vetor.x && item.y == vetor.y)
                return false;
        }
        return true;
    }

    
}
