using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Medal : MonoBehaviour
{
    public PlayerData playerData;

    public List<GameObject> medalhas;
    private void Start()
    {
        for (int i = 0; i < medalhas.Count; i++)
        {
            medalhas[i].SetActive(false);
        }
    }

    private void Update()
    {
        if(playerData.medalhaSalaAula)
            medalhas[0].SetActive(true);
        if (playerData.medalhaBiblioteca)
            medalhas[1].SetActive(true);
        if (playerData.medalhaCantina)
            medalhas[2].SetActive(true);

        if(playerData.medalhaSalaAula && playerData.medalhaBiblioteca && playerData.medalhaCantina)
            SceneManager.LoadScene("Final");
    }
}
