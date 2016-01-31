using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class RandomDialogue : MonoBehaviour
{
    public string randomDialogueFile = "Assets/Speech/RandomDialogue.txt";
    
    public List<string> randomDialog;
    
    // Use this for initialization
    void Start()
    {
        ParseDialogueFile(randomDialogueFile);
    }
    
    // Parse Dialogue Files
    void ParseDialogueFile(string file)
    {
        StreamReader reader = File.OpenText(file);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            randomDialog.Add((string)line.Clone());
        }
    }
    
    public string GetRandomDialogueLine()
    {
        int lineNumber = Random.Range(0, randomDialog.Count);
        return randomDialog[lineNumber];
    }
	
    // Update is called once per frame
    void Update()
    {
    
    }
}
