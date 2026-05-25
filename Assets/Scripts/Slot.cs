using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<Items>().noDrop = false;
        eventData.pointerDrag.transform.position = transform.position;
    }
}
