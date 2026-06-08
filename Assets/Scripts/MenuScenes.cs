using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScenes : MonoBehaviour
{
    public PlayerData playerData;

    public void Jogar()
    {
        playerData.medalhaSalaAula = false;
        playerData.medalhaBiblioteca = false;
        playerData.medalhaCantina = false;
        playerData.quarto = false;
        playerData.biblioteca = false;
        //playerData.cantina = false;
        playerData.realityReal = false;

        SceneManager.LoadScene("Quarto");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Sair()
    {
        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void MenuInicial()
    {
        SceneManager.LoadScene("Menu");
    }
}
