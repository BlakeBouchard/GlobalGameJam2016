using UnityEngine;

public class AwkwardPersonCollision : MonoBehaviour
{
    bool hasConversedAwkwardly = false;
    
    public int stressIncrease = 2;
    
    public float fadedOpacity = 0.3f;
    
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
            
            // Fade the Awkward Person out for now
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            Color color = spriteRenderer.color;
            color.a = fadedOpacity;
        }
    }
	
    // Update is called once per frame
    void Update()
    {
        
    }
}
