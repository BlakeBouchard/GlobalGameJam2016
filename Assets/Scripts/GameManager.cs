using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int conversationEnergy = 0;
    public int conversationGoal = 100;
    public int stressLevel = 0;
    public int stressLimit = 10;
    
    bool failed = false;
    
    bool won = false;
    
    // Use this for initialization
    void Start()
    {
    }
    
    public void IncreaseStress(int amount)
    {
        stressLevel += amount;
    }
    
    public void ReduceStress(int amount)
    {
        stressLevel = Mathf.Max(0, stressLevel - amount);
    }

    public void GainConversationEnergy(int amount)
    {
        conversationEnergy += amount;
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
    }
}
