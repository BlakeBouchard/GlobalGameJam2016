using UnityEngine;

public class RandomChatterNode : MonoBehaviour
{
    RandomDialogue randomDialogue;
    public GameObject speechBubble;
    
    // Use this for initialization
    void Start()
    {
        randomDialogue = GameObject.Find("Game Manager").GetComponent<RandomDialogue>();
        
        if (speechBubble == null || speechBubble.GetComponent<TextMesh>() == null)
        {
            Debug.LogError("Must have a GameObject attached that has a TextMesh!");
        }
    }
	
    // Update is called once per frame
    void Update()
    {
        
    }
}
