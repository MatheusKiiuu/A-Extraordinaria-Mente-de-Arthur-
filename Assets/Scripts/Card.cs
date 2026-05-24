using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler
{
    private bool flip = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(!flip)
            StartCoroutine(Virar());
    }

    IEnumerator Virar()
    {
        flip = true;

        for(int i = 0; i < 180; i++)
        {
            transform.Rotate(new Vector3(0, 1, 0));
            yield return null;
        }
    }
}
