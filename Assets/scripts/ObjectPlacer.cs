using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public GameObject[] objects;

   
    // Start is called before the first frame update
    void Start()
    {
        


        Vector2 pos1 = new Vector2(Random.Range(3, -3) + 0.5f, Random.Range(-2, -4) + 0.5f);
        
        Vector2 pos2 = new Vector2(Random.Range(3, -3) + 0.5f, Random.Range(-2, -4) + 0.5f);
        while (pos1 == pos2)
        {
            pos2 = new Vector2(Random.Range(3, -3) + 0.5f, Random.Range(-2, -4) + 0.5f);
        }

        Vector2 pos3 = new Vector2(Random.Range(3, -3) + 0.5f, Random.Range(-2, -4) + 0.5f);
        while (pos1 == pos3 || pos3 == pos2)
        {
            pos3 = new Vector2(Random.Range(3, -3) + 0.5f, Random.Range(-2, -4) + 0.5f);
        }

        Instantiate(objects[0], pos1, Quaternion.identity);
        Instantiate(objects[1], pos2, Quaternion.identity);
        Instantiate(objects[2], pos3, Quaternion.identity);
    }

    
}
