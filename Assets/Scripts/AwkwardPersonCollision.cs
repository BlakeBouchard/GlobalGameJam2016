using UnityEngine;

public class AwkwardPersonCollision : MonoBehaviour
{
    bool hasConversedAwkwardly = false;
    
    public int stressIncrease = 2;
    
    public float fadedOpacity = 0.3f;
    
	public Renderer renderer;

    // Use this for initialization
    void Start()
    {
    
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
//            OnTriggeredAwkwardPerson();
        }
    }
    
    void OnTriggeredAwkwardPerson()
    {
        if (!hasConversedAwkwardly)
        {
            Debug.Log("Awkward Person triggered");
            GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            gameManager.IncreaseStress(stressIncrease);
            hasConversedAwkwardly = true;
            
            renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, fadedOpacity);
        }
    }
	
    // Update is called once per frame
    void Update()
    {
        
    }
}
