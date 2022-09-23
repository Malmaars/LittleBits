using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceAndBuild : MonoBehaviour
{
    Room currentRoom;

    float currentRoomLocationX, currentRoomLocationY;

    bool buttonLock;
    bool canPlaceRoom;

    public bool aiming;

    void NewRoom(Room newRoom)
    {
        currentRoom = newRoom;

        //set location based on the offset between the parent and the baseBlock
        currentRoomLocationX = currentRoom.roomObject.transform.position.x;
        currentRoomLocationY = currentRoom.roomObject.transform.position.y;
    }

    void AimBuilding()
    {
        if (!buttonLock)
        {
            //snap room to grid, move it with arrow keys
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                currentRoomLocationX += Input.GetAxisRaw("Horizontal") * GridSystem.squareSize;
                buttonLock = true;
            }

            if (Input.GetAxisRaw("Vertical") != 0)
            {
                currentRoomLocationY += Input.GetAxisRaw("Vertical") * GridSystem.squareSize;
                buttonLock = true;
            }

            currentRoom.roomObject.transform.position = new Vector3(currentRoomLocationX, currentRoomLocationY);
        }

        if(Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            buttonLock = false;
        }

        if(canPlaceRoom && Input.GetKeyDown(KeyCode.K))
        {
            PlaceBuilding();
        }

        //Check if each part of the room overlaps anything, if so, can't place it
        //Check if any part connects to another, if so, that's when you can place it

        VisualizeConnection();

    }

    void PlaceBuilding()
    {
        MakeConnection();
    }
    
    void VisualizeConnection()
    {

    }

    void MakeConnection()
    {

    }
}
