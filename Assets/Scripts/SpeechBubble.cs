using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    public float timeBetweenRolls = 1.0f;
    public float probabilityPercent = 10;
    
    // Use this for initialization
    void Start()
    {
        // Set this object's rotation to be the same as the Main Camera
        transform.rotation = Camera.main.transform.rotation;
    }
    
    // IEnumerator RollForDialog(float waitTime)
    // {
    //     yield return new WaitForSeconds(waitTime);
    //     Random.Range(0, 100);
    // }
	
    // Update is called once per frame
    void Update()
    {
        
    }
}
