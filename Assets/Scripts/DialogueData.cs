using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AssetDialoque", menuName = "New AssetDialoque")]
public class DialogueData : ScriptableObject
{
    public string nameData;
    public List<string> dialogueData;
}
