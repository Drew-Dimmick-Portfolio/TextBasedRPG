using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtonHandler : MonoBehaviour
{
    public int doorID;
    public int roomNumberEntrance;
    public RoomNodeParser roomNodeParser;
    public RoomUIController roomUIController;

    public void ChangeRooms()
    {
        Debug.Log("Changing rooms...");
        roomNodeParser.ChangeRooms(doorID);
        roomUIController.ChangeRooms(roomNumberEntrance);
    }
}
