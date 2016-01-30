using UnityEngine;

public class Beer : MonoBehaviour
{
    public int stressReductionAmount = 1;
    
    // Use this for initialization
    void Start()
    {
    }
    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            
            gameManager.ReduceStress(stressReductionAmount);
            
            // TODO: Play sound like "Ahhh"
            
            Debug.Log("MMMM That's good beer!");
            
            Destroy(gameObject);
        }
    }
	
    // Update is called once per frame
    void Update()
    {
    }
}
