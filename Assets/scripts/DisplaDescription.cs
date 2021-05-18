using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplaDescription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text Description;

    

    public void OnPointerEnter(PointerEventData eventData)
    {
        Description.color = new Color(1, 1, 1, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Description.color = new Color(0, 0, 0, 0);
        Debug.Log("Saiu");
    }
}
