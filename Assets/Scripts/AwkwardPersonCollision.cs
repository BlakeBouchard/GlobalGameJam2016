using UnityEngine;

public class AwkwardPersonCollision : MonoBehaviour
{
    bool hasConversedAwkwardly = false;
    
    public int stressIncrease = 2;
    
    // Use this for initialization
    void Start()
    {
    
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (!hasConversedAwkwardly && collision.collider.tag == "Player")
        {
            GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            
            gameManager.IncreaseStress(stressIncrease);
            
            hasConversedAwkwardly = true;
        }
    }
	
    // Update is called once per frame
    void Update()
    {
    
    }
}
