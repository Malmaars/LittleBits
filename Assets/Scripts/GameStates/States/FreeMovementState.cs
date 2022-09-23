using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMovementState : MonoBehaviour, IState
{
    Player player;
    public List<StateTransition> transitions { get; protected set; }
    public FreeMovementState()
    {
        transitions = new List<StateTransition>();
        player = FindObjectOfType<Player>();
        //add transition here
    }
    public void Enter()
    {

    }

    public void Exit()
    {
    }

    public void LogicUpdate()
    {
        player.LogicUpdate();
    }

    public void PhysicsUpdate()
    {
        player.PhysicsUpdate();
    }

    public void OnSwitch()
    {
    }
}
