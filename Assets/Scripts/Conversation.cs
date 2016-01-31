using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class Conversation : MonoBehaviour
{
    public string conversationFile = "Assets/Speech/Conversations.txt";
    
    List<ConversationOptions> conversations;
    
    public struct ConversationOptions
    {
        public string conversationText;
        public List<KeyValuePair<string, int>> options;
    }
    
    // Use this for initialization
    void Start()
    {
        conversations = new List<ConversationOptions>();
        ParseConversationFile(conversationFile);
    }
    
    void ParseConversationFile(string fileToParse)
    {
        StreamReader reader = File.OpenText(fileToParse);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            ConversationOptions co = new ConversationOptions();
            co.options = new List<KeyValuePair<string, int>>();
            string[] splitStrings = line.Split('|');
            foreach (string s in splitStrings)
            {
                s.Trim();
                if (s.StartsWith("!"))
                {
                    co.conversationText = s.Substring(1);
                    co.conversationText.Trim();
                }
                else if (s.StartsWith("?"))
                {
                    string optionString = s.Substring(1);
                    optionString = optionString.Trim();
                    string[] optionStrings = optionString.Split(':');
                    if (optionStrings.Length == 2)
                    {
                        // That's what we need
                        string optionText = optionStrings[0].Trim();
                        co.options.Add(new KeyValuePair<string, int>(optionText, int.Parse(optionStrings[1])));
                    }
                    else
                    {
                        Debug.LogError("Malformed string");
                    }
                }
            }
            
            conversations.Add(co);
        }
    }
    
    public ConversationOptions GetRandomConversation()
    {
        int random = Random.Range(0, conversations.Count);
        
        return conversations[random];
    }
	
    // Update is called once per frame
    void Update()
    {
        
    }
}
