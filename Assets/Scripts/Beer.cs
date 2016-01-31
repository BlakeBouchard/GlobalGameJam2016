using UnityEngine;

public class Beer : MonoBehaviour
{
    public int stressReductionAmount = 1;
    
    bool shouldDestroy = false;
    
    public float fadedOpacity = 0.3f;
    
    new AudioSource audio;
    
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            
            gameManager.ReduceStress(stressReductionAmount);
            
            shouldDestroy = true;
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, fadedOpacity);
            if (audio != null)
            {
                audio.Play();
            }
            
            Debug.Log("MMMM That's good beer!");
        }
    }
	
    // Update is called once per frame
    void Update()
    {
        if (shouldDestroy)
        {
            if (!audio.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}
