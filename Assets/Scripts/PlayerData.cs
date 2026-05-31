using UnityEngine;

[CreateAssetMenu(fileName = "AssetPlayerData", menuName = "New AssetPlayerData")]
public class PlayerData : ScriptableObject
{
    public bool quarto;
    public bool salaAula;
    public bool biblioteca;
    public bool cantina;
    public bool medalhaSalaAula;
    public bool medalhaBiblioteca;
    public bool medalhaCantina;
    public bool realityReal;

    public void VerificarScene(string scene)
    {
        switch (scene)
        {
            case "Quarto": quarto = true;
                break;
            case "Cantina": cantina = true;
                break;
            case "Sala de aula": salaAula = true;
                break;
            case "Biblioteca": biblioteca = true;
                break;
        }
    }
}
