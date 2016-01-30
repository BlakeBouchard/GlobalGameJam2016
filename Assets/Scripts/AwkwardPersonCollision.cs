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
    
    void OnTriggerEnter(Collider collider)
    {
        if (!hasConversedAwkwardly && collider.tag == "Player")
        {
            Debug.Log("Awkward Person triggered");
            GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            gameManager.IncreaseStress(stressIncrease);
            hasConversedAwkwardly = true;
            
            // Fade the Awkward Person out for now
            Renderer renderer = GetComponent<Renderer>();
            
            renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, fadedOpacity);
        }
    }
	
    // Update is called once per frame
    void Update()
    {
        
    }
}
