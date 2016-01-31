using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int conversationEnergy = 0;
    public int conversationGoal = 100;
    public int stressLevel = 0;
    public int stressLimit = 10;
    
    public Canvas guiObject;
    Text conversationText;
    string conversationString;
    Text stressText;
    string stressString;
    
    bool failed = false;
    
    bool won = false;
    
    // Use this for initialization
    void Start()
    {
        if (guiObject != null)
        {
            conversationText = guiObject.transform.Find("Conversation").GetComponent<Text>();
            if (conversationText != null)
            {
                Debug.Log("Found conversation text");
                conversationString = conversationText.text;
            }
            
            stressText = guiObject.transform.Find("Stress").GetComponent<Text>();
            if (stressText != null)
            {
                Debug.Log("Found stress text");
                stressString = stressText.text;
            }
            UpdateGUI();
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
        if (conversationText != null)
        {
            conversationText.text = conversationString + conversationEnergy;
        }
        
        if (stressText != null)
        {
            stressText.text = stressString + stressLevel;
        }
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
    }
}
