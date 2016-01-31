using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int conversationEnergy = 0;
    public int conversationGoal = 100;
    public int stressLevel = 0;
    public int stressLimit = 10;
    
    public Canvas guiObject;
    Text conversationLevelText;
    string conversationLevelString;
    Text stressText;
    string stressString;
    
    Text conversationText;
    Text option1Text;
    Text option2Text;
    
    public bool inConversation;
    
    bool failed = false;
    
    bool won = false;
    
    Conversation.ConversationOptions currentConversation;
    
    // Use this for initialization
    void Start()
    {
        if (guiObject != null)
        {
            conversationLevelText = guiObject.transform.Find("Conversation").GetComponent<Text>();
            if (conversationLevelText != null)
            {
                Debug.Log("Found conversation text");
                conversationLevelString = conversationLevelText.text;
            }
            
            stressText = guiObject.transform.Find("Stress").GetComponent<Text>();
            if (stressText != null)
            {
                Debug.Log("Found stress text");
                stressString = stressText.text;
            }
            UpdateGUI();
            
            conversationText = guiObject.transform.Find("Conversation Text").GetComponent<Text>();
            
            option1Text = guiObject.transform.Find("Option 1 Text").GetComponent<Text>();
            option2Text = guiObject.transform.Find("Option 2 Text").GetComponent<Text>();
        }
    }
    
    public void IncreaseStress(int amount)
    {
        stressLevel += amount;
        UpdateGUI();
    }
    
    public void ReduceStress(int amount)
    {
        stressLevel = Mathf.Max(0, stressLevel - amount);
        UpdateGUI();
    }

    public void GainConversationEnergy(int amount)
    {
        conversationEnergy += amount;
        UpdateGUI();
    }
    
    void UpdateGUI()
    {
        if (conversationLevelText != null)
        {
            conversationLevelText.text = conversationLevelString + conversationEnergy;
        }
        
        if (stressText != null)
        {
            stressText.text = stressString + stressLevel;
        }
    }
    
    public void StartAwkwardConversation()
    {
        inConversation = true;
        currentConversation = GetComponent<Conversation>().GetRandomConversation();
        conversationText.text = currentConversation.conversationText;
        option1Text.text = currentConversation.options[0].Key;
        option2Text.text = currentConversation.options[1].Key;
    }
    
    public void AnswerAwkwardConversation(int optionPicked)
    {
        IncreaseStress(currentConversation.options[optionPicked].Value);
        conversationText.text = "";
        option1Text.text = "";
        option2Text.text = "";
        inConversation = false;
        
        GameObject.Find("AwkwardTurtle").SendMessage("EndAwkwardConversation", SendMessageOptions.DontRequireReceiver);
        GameObject.Find("Player").SendMessage("EndAwkwardConversation", SendMessageOptions.DontRequireReceiver);
    }
	
    // Update is called once per frame
    void Update()
    {
        if (!failed && stressLevel >= stressLimit)
        {
            Debug.Log("OH NO YOU GOT TOO STRESSED OUT");
            failed = true;
        }
        
        if (!won && conversationEnergy >= conversationGoal)
        {
            Debug.Log("You did it! You put an effort in and everybody saw it so now you can go home and watch Game of Thrones!");
            won = true;
        }
        
        if (Input.GetButtonDown("Escape"))
        {
            Debug.Log("Escape key pressed, quitting game");
            Application.Quit();
        }
        
        if (inConversation)
        {
            float verticalAxis = Input.GetAxis("Vertical");
            if (verticalAxis > 0)
            {
                AnswerAwkwardConversation(0);
            }
            else if (verticalAxis < 0)
            {
                AnswerAwkwardConversation(1);
            }
        }
    }
}
