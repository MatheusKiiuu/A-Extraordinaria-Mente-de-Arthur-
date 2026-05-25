using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public DialogueData data;

    private string nameCharacter;
    private int i1 = 0;
    public float speedText = 0.2f;

    private List<string> dialogueCharacter;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public GameObject button;
    public GameObject canvas;
    public GameObject keyF;
    public MonoBehaviour playerScript;

    private void Awake()
    {
        nameCharacter = data.nameData;
        dialogueCharacter = data.dialogueData;
    }
    private void Start()
    {
        StartCoroutine(EscreveName());
        StartCoroutine(EscreveDialogue());
    }

    IEnumerator EscreveName()
    {
        for(int i = 0; i < nameCharacter.Length; i++)
        {
            nameText.text += nameCharacter[i];
            yield return new WaitForSecondsRealtime(speedText);
        }
    }

    IEnumerator EscreveDialogue()
    {
        dialogueText.text = null;
        button.SetActive(false);

        for (int j = 0; j < dialogueCharacter[i1].Length; j++)
        {
            dialogueText.text += dialogueCharacter[i1][j];
            yield return new WaitForSecondsRealtime(speedText);
        }

        i1++;
        button.SetActive(true);
    }

    public void OnClick()
    {
        if(dialogueCharacter.Count > i1)
        {
            StartCoroutine(EscreveDialogue());
        }
        else
        {
            canvas.SetActive(false);
            playerScript.enabled = true;
            keyF.SetActive(true);
        }
    }
}
