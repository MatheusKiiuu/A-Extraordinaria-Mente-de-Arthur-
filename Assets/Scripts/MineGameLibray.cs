using TMPro;
using UnityEngine;

public class MineGameLibray : MonoBehaviour
{
    public PlayerData playerData;

    public int points;

    public TextMeshProUGUI textMesh;

    private void Update()
    {
        if (points == 5)
        {
            textMesh.text = "Parabens!!";
            playerData.medalhaBiblioteca = true;
        }
    }
}
