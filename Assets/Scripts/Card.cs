using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler
{
    public GameObject canvas;

    private bool flip = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!flip)
        {
            StartCoroutine(Virar());
            canvas.GetComponent<MineGameMemory>().CardRevealed(this);
        }
    }

    public IEnumerator Virar()
    {
        for(int i = 0; i < 180; i++)
        {
            transform.Rotate(new Vector3(0, 1, 0));
            yield return null;
        }

        flip = !flip;
    }
}
