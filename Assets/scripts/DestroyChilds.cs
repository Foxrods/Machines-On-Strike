using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChilds : MonoBehaviour
{
    public void destroyAllChilds()
    {
        foreach(Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
