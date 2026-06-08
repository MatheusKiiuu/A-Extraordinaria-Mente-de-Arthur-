using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MineGameMemory : MonoBehaviour
{
    public PlayerData playerData;

    public TextMeshProUGUI textMesh;

    private GraphicRaycaster raycaster;

    private Card firstCard;
    private Card secondCard;

    public int points;

    private void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>();
    }

    private void Update()
    {
        if (points == 5)
        {
            textMesh.text = "Parabéns, você concluiu o desafio!!";
            playerData.medalhaSalaAula = true;
        }
    }

    public void CardRevealed(Card card)
    {
        if(firstCard == null)
            firstCard = card;
        else if (secondCard == null)
        {
            secondCard = card;
            raycaster.enabled = false;
            StartCoroutine(Check());
        }
    }

    private IEnumerator Check()
    {
        yield return new WaitForSeconds(1f);

        if (!firstCard.CompareTag(secondCard.tag))
        {
            firstCard.Virar();
            secondCard.Virar();
        }
        else
        {
            points++;

            firstCard.GetComponent<Card>().enabled = false;
            secondCard.GetComponent<Card>().enabled = false;
        }

        firstCard = null;
        secondCard = null;

        raycaster.enabled =  true;
    }
}
