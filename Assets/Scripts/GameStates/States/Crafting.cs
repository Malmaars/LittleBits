using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour, IState
{
    //array of all possible rooms
    GameObject[] possibleRooms;
    public List<StateTransition> transitions { get; protected set; }
    public Crafting()
    {
        transitions = new List<StateTransition>();

        //we'll fetch all possible rooms from the appropriate reasource folder
        //These rooms will be passed through to the movingPrefab State

        //possibleRooms = new GameObject[] { Resources.Load("Prefabs/SquareWhite") as GameObject };
    }
    public void Enter()
    {

    }

    public void Exit()
    {
    }

    public void LogicUpdate()
    {
    }

    public void PhysicsUpdate()
    {
    }

    public void OnSwitch()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
