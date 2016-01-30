using UnityEngine;

public class Beer : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }
    
    void OnCollisionEnter(Collision collision)
    {
        GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        gameManager.ReduceStress(1);
        
        // TODO: Play sound like "Ahhh"
        
        Destroy(transform);
    }
	
    // Update is called once per frame
    void Update()
    {
    }
}
