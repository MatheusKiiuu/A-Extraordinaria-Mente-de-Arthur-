using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Reality : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public PlayerData playerData;

    public bool temUI;

    public List<SpriteRenderer> renderers;
    public List<Sprite> sReal, sRPG, sUIReal, sUIRPG;

    public List<Image> images;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();

        Troca();

        if (temUI)
            TrocarUI();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.gray;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!playerData.realityReal)
            playerData.realityReal = true;
        else
            playerData.realityReal = false;

        Troca();

        if(temUI)
            TrocarUI();
    }

    private void Troca()
    {
        if (!playerData.realityReal)
        {
            for (int i = 0; i < renderers.Count; i++)
            {
                renderers[i].sprite = sReal[i];
            }
        }
        else
        {
            for (int i = 0; i < renderers.Count; i++)
            {
                renderers[i].sprite = sRPG[i];
            }
        }
    }

    private void TrocarUI()
    {
        if (!playerData.realityReal)
        {
            for (int i = 0; i < images.Count; i++)
            {
                images[i].sprite = sUIReal[i];
            }
        }
        else
        {
            for (int i = 0; i < images.Count; i++)
            {
                images[i].sprite = sUIRPG[i];
            }
        }
    }
}
