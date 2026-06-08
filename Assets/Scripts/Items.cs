using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Items : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public bool noDrop = true;
    public bool money;

    private Vector3 positionGameObject;

    private Image image;

    private void Start()
    {
        positionGameObject = transform.position;

        image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.gray;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
    }

    public void OnDrag(PointerEventData eventData)
    {
        noDrop = true;
        transform.position = eventData.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (noDrop)
            transform.position = positionGameObject;
        if (!money)
            image.raycastTarget = true;
    }
}
