using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;

    public int xSize, ySize;
    public float squareSize;

    //GameStateMachine stateMachine;

    private void OnDrawGizmos()
    {
        GridSystem.DrawGizmos();
    }
    // Start is called before the first frame update
    void Start()
    {
        GridSystem.InitializeGrid(xSize, ySize, squareSize);
        //stateMachine = new GameStateMachine(typeof(FreeMovementState));
    }

    // Update is called once per frame
    void Update()
    {
        //stateMachine.LogicUpdate();
    }

    private void FixedUpdate()
    {
        //stateMachine.PhysicsUpdate();
    }

    void ScreenShake()
    {
        
    }
}
