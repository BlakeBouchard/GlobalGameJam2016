using UnityEngine;
using System.Collections;

public class AwkwardPerson : MonoBehaviour
{
    public enum Behaviour
    {
          Idle
        , Wandering
        , MoveToObject
        , FleeObject
        , Patrolling
        , PatrolWait
    }

    // Public
    public GameObject game_object;
    public Behaviour current_behaviour = Behaviour.Patrolling;

    public GameObject patrol_start;
    public GameObject patrol_end;

    public float movement_speed = 5.0f;
    //---

    Vector3 movement_target;

    // Use this for initialization
    void Start () {
        movement_target = patrol_start.transform.position;
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
                //todo: handle iterating path list instead of hard coding for two points

                if(game_object.transform.position == patrol_start.transform.position)
                {
                    movement_target = patrol_end.transform.position;
                }
                else if(game_object.transform.position == patrol_end.transform.position)
                {
                    movement_target = patrol_start.transform.position;
                }

                MoveToward(movement_target);
            break;
            }
            case Behaviour.PatrolWait:
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
