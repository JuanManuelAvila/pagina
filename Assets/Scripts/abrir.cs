using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class abrir : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool state = true;
    private void Start()
    {
        state = GetComponent<Button>().interactable;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (state)
            transform.GetChild(0).GetComponent<Text>().color = new Color32(255, 255, 255, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (state)
            transform.GetChild(0).GetComponent<Text>().color = new Color32(50, 50, 50, 255);
    }
}
