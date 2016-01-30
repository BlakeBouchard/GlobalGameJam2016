using UnityEngine;
using System.Collections;

public class AwkwardPerson : MonoBehaviour
{
    enum Behaviour
    {
          Idle
        , Wandering
        , MoveToObject
        , FleeObject
        , Patrolling
    }

    // Public
    public GameObject game_object;

    public GameObject patrol_start;
    public GameObject patrol_end;

    public float movement_speed = 5.0f;
    //---

    Behaviour current_behaviour = Behaviour.Idle;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        UpdateBehaviourMachine();
    }

    void UpdateBehaviourMachine ()
    {
        switch (current_behaviour)
        {
            case Behaviour.Idle:
            {
                //maybe change direction every couple seconds
                break;
            }
            case Behaviour.Patrolling:
            {
                break;
            }
        };
    }

    void MoveToward(Vector3 target_pos)
    {
        var cur_pos = gameObject.transform.position;
        var dist = target_pos - cur_pos;
        var dir = dist.normalized;

        //todo: set facing direction

        if(dist.magnitude <= movement_speed)
        {
            game_object.transform.position = target_pos;
        }
        else
        {
            game_object.transform.position  += dir * movement_speed;
        }
    }


}
