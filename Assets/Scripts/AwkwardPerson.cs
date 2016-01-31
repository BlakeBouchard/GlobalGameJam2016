using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AwkwardPerson : MonoBehaviour
{
    public enum Behaviour
    {
          Idle
        , Patrolling
        , PatrolWait
        , MoveToObject
        , FleeObject
        , Conversing
    }
        
    public bool has_conversed = false; //no longer an active threat when true
    public Behaviour current_behaviour = Behaviour.Patrolling;
    public float movement_speed = 5.0f;

    public Camera view_cam;
    public BoxCollider player_test;

    public float[] patrol_wait_time_bounds = {0.5f, 2.0f};

    public List<Transform> current_path;
    public bool path_loops = true;
    int current_path_node_index = 0;

    public float conversation_range = 2.0f; //how close the player is before starting a conversation


    Vector3 movement_target;

    Quaternion idle_original_rotation;
    Quaternion target_rotation;
    Quaternion prev_target_rotation;

    GameObject target_object = null;

    float wait_timer = 0.0f;

    bool HasPath { get { return current_path.Count > 0; } }

    int NextPathNodeIndex
    {
        get{ return (current_path_node_index + 1) % current_path.Count; }
    }

    int NearestPathNodeIndex()
    {
        int nearest = 0;
        float nearest_dist_sq = float.PositiveInfinity;

        int i = 0;
        foreach(var node in current_path)
        {
            var dist_sq = (node.position - transform.position).sqrMagnitude;

            if(dist_sq < nearest_dist_sq)
            {
                nearest = i;
                nearest_dist_sq = dist_sq;
            }

            i++;
        }

        return nearest;
    }

    // Use this for initialization
    void Start ()
    {
        if(HasPath)
        {
            movement_target = current_path[0].position;
        }
        
        if (player_test == null)
        {
            // Find the player object and grab the BoxCollider from it
            player_test = GameObject.Find("Player").GetComponent<BoxCollider>();
        }

        idle_original_rotation = transform.rotation;
        target_rotation        = transform.rotation;
        prev_target_rotation   = transform.rotation;
    }

    // Update is called once per frame
    void Update () {
        UpdateBehaviourMachine();

        //testing frustum collision
//        if(CanSeePlayer(player_test.bounds))
        if(ShouldFollowPlayer())
        {
            GetComponent<MeshRenderer>().material.color = Color.red;

            this.SendMessage("OnTriggeredAwkwardPerson", null, SendMessageOptions.DontRequireReceiver);

            if(WithinConversationRange(player_test.transform))
            {
                //todo: trigger conversation
                if(current_behaviour != Behaviour.Conversing)
                {
                    SetState(Behaviour.Conversing);
                }
            }
            else
            {
                if(current_behaviour != Behaviour.MoveToObject)
                {
                    target_object = player_test.gameObject;
                    SetState(Behaviour.MoveToObject);
                }
            }    
        }
        else //else should not follow player
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }

    bool CanSeePlayer(Bounds player_bounds)
    {
        Plane[] frustum_planes = GeometryUtility.CalculateFrustumPlanes(view_cam);
        return GeometryUtility.TestPlanesAABB(frustum_planes, player_bounds);
    }

    bool WithinConversationRange(Transform obj)
    {
        return (obj.transform.position - transform.position).magnitude <= conversation_range;
    }

    bool ShouldFollowPlayer()
    {
        //todo: check if eye contact is established, or already moving to target

        return CanSeePlayer(player_test.bounds);
    }

    void SetState(Behaviour new_behaviour)
    {
        //todo: state transitions
        //        switch(current_behaviour)
        //        {
        //        };

        switch(new_behaviour)
        {
        case Behaviour.Idle:
            {
                idle_original_rotation = transform.rotation;
                break;
            }

        case Behaviour.PatrolWait:
            {
                wait_timer = Random.Range(patrol_wait_time_bounds[0], patrol_wait_time_bounds[1]);
                break;
            }
        }

        current_behaviour = new_behaviour;
    }

    void UpdateBehaviourMachine ()
    {
        switch (current_behaviour)
        {
        case Behaviour.Idle:
            {
                wait_timer -= Time.deltaTime;

                if(wait_timer <= 0)
                {
                    prev_target_rotation = target_rotation;
                    target_rotation = idle_original_rotation;

                    var tmp = target_rotation.eulerAngles;
                    tmp.x += Random.Range(-20, 20);
                    target_rotation.eulerAngles = tmp;
                    wait_timer = Random.Range(1.0f, 3.0f); //TODO expose as public var (or change to constant var)
                }

                transform.rotation = Quaternion.Lerp(prev_target_rotation, target_rotation, (1 - (wait_timer / 3.0f))); //FIXME do something less broken so it lerps from 0 to 1 properly

                break;
            }

        case Behaviour.Patrolling:
            {
                if(current_path.Count < 2)
                {
                    SetState(Behaviour.Idle);
                }

                MoveToward(movement_target);

                //if arrived at the current dest node (positions overlap
                if(transform.position == current_path[current_path_node_index].position)  //FIXME use epsilon? idk if C# needs it
                {
                    if(current_path_node_index == current_path.Count - 1 && !path_loops)
                    {
                        current_path.Reverse();
                        current_path_node_index = 0;
                    }

                    movement_target = current_path[NextPathNodeIndex].position;
                    current_path_node_index = NextPathNodeIndex;
                    SetState(Behaviour.PatrolWait);
                }
                break;
            }

        case Behaviour.PatrolWait:
            {
                wait_timer -= Time.deltaTime;

                if(wait_timer <= 0)
                {
                    SetState(Behaviour.Patrolling);
                }
                break;
            }

        case Behaviour.MoveToObject:
            {
                movement_target = target_object.transform.position;
                MoveToward(movement_target);
                break;
            }
        }
    }

    void MoveToward(Vector3 target_pos)
    {
        var dist = target_pos - transform.position;
        var dir = dist.normalized;
        var movement_amount = movement_speed * Time.deltaTime;
        var movement_vec = dir * movement_speed * Time.deltaTime;

        //set facing direction
        transform.LookAt(target_pos, Vector3.forward); //use forward to rotate around Z axis

        if(dist.magnitude <= movement_amount)
        {
            transform.position = target_pos;
        }
        else
        {
            transform.position  += movement_vec;
        }
    }




}
