using System.Collections;
using TMPro;
using UnityEngine;

public class MineGameMemory : MonoBehaviour
{
    public float stop = 1f;

    public PlayerData playerData;

    public TextMeshProUGUI textMesh;

    private Card firstCard;
    private Card secondCard;

    public int points;

    private void Update()
    {
        if (points == 5)
        {
            textMesh.text = "Parabens!!";
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
            StartCoroutine(Check());
        }
    }

    private IEnumerator Check()
    {
        yield return new WaitForSeconds(stop);

        if (!firstCard.CompareTag(secondCard.tag))
        {
            StartCoroutine(firstCard.Virar());
            StartCoroutine(secondCard.Virar());
        }
        else
        {
            points++;
        }

        firstCard = null;
        secondCard = null;
    }
}
