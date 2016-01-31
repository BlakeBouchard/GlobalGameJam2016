using UnityEngine;
using System.Collections;

public class ConversationCircle : MonoBehaviour
{
    public uint num_people = 2; //affects how strong a conversation group is against awkwardness
    public uint current_convo_energy = 10;

    uint max_convo_energy; //inits to current_convo_energy in Start()

	// Use this for initialization
	void Start () {
        Color init_color = Color.grey;
        init_color.a = 0.5f;
        GetComponent<MeshRenderer>().material.color = init_color;

        max_convo_energy = current_convo_energy;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            collider.gameObject.GetComponent<PlayerStateMachine>().EnterConversation(this);

            Color c = Color.yellow;
            c.a = 0.5f;
            GetComponent<MeshRenderer>().material.color = c;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            collider.gameObject.GetComponent<PlayerStateMachine>().ExitConversation(this);

            Color c = Color.grey;
            c.a = 0.5f;
            GetComponent<MeshRenderer>().material.color = c;
        }
    }
}
