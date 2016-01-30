using UnityEngine;

public class GameManager : MonoBehaviour
{
    int ConversationEnergy = 0;
    public int ConversationGoal = 100;
    int StressLevel = 0;
    public int StressLimit = 10;
    
    // Use this for initialization
    void Start()
    {
        
    }
    
    public void ReduceStress(int amount)
    {
        StressLevel = Mathf.Max(0, StressLevel - amount);
    }
	
    // Update is called once per frame
    void Update()
    {
        if (StressLevel >= StressLimit)
        {
            Debug.Log("OH NO YOU GOT TOO STRESSED OUT");
        }
        
        if (ConversationEnergy >= ConversationGoal)
        {
            Debug.Log("You did it! You put an effort in and everybody saw it so now you can go home and watch Game of Thrones!");
        }
    }
}
