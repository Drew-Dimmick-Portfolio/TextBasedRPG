using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomUIController : MonoBehaviour
{
    public int roomIndex;
    public bool[] rooms;
    
    private void Awake()
    {
        rooms = new bool[4];
        rooms[roomIndex] = true;
    }

    public void ChangeRooms(int roomNumber)
    {
        rooms = new bool[4];
        rooms[roomNumber - 1] = true;
        roomIndex = roomNumber - 1;
    }
}
