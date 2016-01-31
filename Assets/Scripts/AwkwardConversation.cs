using UnityEngine;
using System;

public class AwkwardConversation
{
    PlayerStateMachine player;
    AwkwardPerson awkward_person;
//    int stress_to_give;

    float convo_duration = 2.0f;

    public AwkwardConversation (PlayerStateMachine _player, AwkwardPerson _person/*, int _stress*/)
    {
        player         = _player;
        awkward_person = _person;
//        stress_to_give = _stress;
    }

    public void Update()
    {
        convo_duration -= Time.deltaTime;

        if(convo_duration < 0.0)
        {
            EndConversation();
        }
    }

    public void EndConversation()
    {
        awkward_person.EndAwkwardConversation();
        player.EndAwkwardConversation();
    }
}
