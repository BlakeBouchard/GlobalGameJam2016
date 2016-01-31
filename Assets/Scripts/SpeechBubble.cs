using UnityEngine;
using System.Collections;

public class SpeechBubble : MonoBehaviour
{
    GameManager gameManager;
    RandomDialogue randomDialogue;
    public float lifeTime = 3.0f;
    public float timeBetweenRolls = 1.0f;
    public float probabilityPercent = 10;
    
    bool showing = false;
    
    // Use this for initialization
    void Start()
    {
        // Set this object's rotation to be the same as the Main Camera
        transform.rotation = Camera.main.transform.rotation;
        
        GameObject gameManagerObject = GameObject.Find("Game Manager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
        randomDialogue = gameManagerObject.GetComponent<RandomDialogue>();
        
        if (GetComponent<TextMesh>() == null)
        {
            Debug.LogError("Must have a GameObject attached that has a TextMesh!");
        }
        StartCoroutine("RollForShowBubble", timeBetweenRolls);
    }
    
    IEnumerator RollForShowBubble(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            if (GetComponent<TextMesh>().text == "" && !gameManager.inConversation && Random.Range(0, 100) < probabilityPercent)
            {
                ShowSpeechBubble();
            }
        }
    }
    
    void ShowSpeechBubble()
    {
        // Enable the speech bubble
        Debug.Log("Speech should be shown here");
        StartCoroutine("HideSpeechBubble", lifeTime);
        SetText(randomDialogue.GetRandomDialogueLine());
        showing = true;
    }
    
    IEnumerator HideSpeechBubble(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SetText("");
        showing = false;
    }
    
    void SetText(string text)
    {
        GetComponent<TextMesh>().text = text;
    }
	
    // Update is called once per frame
    void LateUpdate()
    {
        if (gameManager.inConversation && showing)
        {
            SetText("");
            showing = false;
        }
        transform.rotation = Camera.main.transform.rotation;
    }
}
