using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler
{
    public GameObject canvas;

    public bool flip = false;

    public Quaternion quaternion;

    public void OnPointerClick(PointerEventData eventData)
    {
        Virar();
        canvas.GetComponent<MineGameMemory>().CardRevealed(this);
    }

    private void Update()
    {
        if (flip)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, quaternion, 180f * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, quaternion) < 0.1f)
            {
                transform.rotation = quaternion;
                flip = false;
            }
        }
    }

    public void Virar()
    {
        quaternion = transform.rotation * Quaternion.Euler(0, 180, 0);
        flip = !flip;
    }
}
