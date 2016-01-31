using UnityEngine;
using System.Collections;

public class ConversationCircle : MonoBehaviour
{
    public uint num_people = 2; //affects how strong a conversation group is against awkwardness
    public uint current_convo_energy = 10;

    public float transfer_tick_period = 1.0f;
    public int transfer_tick_amount = 1; //how much energy you gain per transfer_tick_period

    uint max_convo_energy; //inits to current_convo_energy in Start()

    float transfer_timer;

	// Use this for initialization
	void Start () {
        Color init_color = Color.grey;
        init_color.a = 0.5f;
        GetComponent<MeshRenderer>().material.color = init_color;

        max_convo_energy = current_convo_energy;
        transfer_timer = transfer_tick_period;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //called by player while they are inside this convo
    public void UpdateTransfer()
    {
        transfer_timer -= Time.deltaTime;

        if(transfer_timer < 0.0f)
        {
            transfer_timer = transfer_tick_period;
            TransferEnergy();
        }
    }

    void TransferEnergy()
    {
        GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.GainConversationEnergy(transfer_tick_amount);
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
