using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MineGameMoney : MonoBehaviour
{
    public PlayerData playerData;

    public int fase;

    public GameObject slot;

    public Image frut;

    public TextMeshProUGUI textMesh;
    public TextMeshProUGUI valor;

    public List<GameObject> gameObjects;
    public List<Sprite> sprites;

    private void Start()
    {
        ResetMoney();
    }

    private void Update()
    {
        valor.text = "$ " + slot.GetComponent<Slot>().valor;
    }

    public void ResetMoney()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].transform.position = gameObjects[i].GetComponent<Items>().positionGameObject;
            gameObjects[i].GetComponent<Image>().raycastTarget = true;
        }
    }

    public decimal RetornValor()
    {
        fase++;

        if (fase == 1)
        {
            if (!playerData.realityReal)
                frut.sprite = sprites[0];
            else
                frut.sprite = sprites[2];
            return 2.25M;
        }
        else if (fase == 2)
        {
            if (!playerData.realityReal)
                frut.sprite = sprites[1];
            else
                frut.sprite = sprites[3];
            return 3.00M;
        }
        else
        {
            textMesh.text = "Parabéns, calculou corretamente seu lanche!";
            playerData.medalhaCantina = true;
            return 0M;
        } 
    }
}
