using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler
{
    public string tagItem;
    public bool libray;
    public bool normal;
    public int valor;

    public GameObject Canvas;

    public void OnDrop(PointerEventData eventData)
    {
        if(normal)
            NormalDrop(eventData);
        else
            MoneyDrop(eventData);
    }

    private void NormalDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.CompareTag(tagItem))
        {
            eventData.pointerDrag.GetComponent<Items>().noDrop = false;
            if (libray)
            {
                Canvas.GetComponent<MineGameLibray>().points++;
                eventData.pointerDrag.GetComponent<Items>().enabled = false;
            }
        }
        eventData.pointerDrag.transform.position = transform.position;
    }

    private void MoneyDrop(PointerEventData eventData)
    {
        int n = Convert.ToInt32(eventData.pointerDrag.tag);
        if (valor - n >= 0)
        {
            valor -= n;
            eventData.pointerDrag.GetComponent<Items>().noDrop = false;
            eventData.pointerDrag.GetComponent<Image>().raycastTarget = false;
        }
    }
}
