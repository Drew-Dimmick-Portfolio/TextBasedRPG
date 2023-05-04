using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public int roomNumber;
    public GameObject conditionalUI;
    public RoomUIController roomUIController;
    
    void Start()
    {
        string debugString = " ";
        foreach(bool b in roomUIController.rooms)
        {
            if(b)
            {
                debugString += "1, ";
            }
            else
            {
                debugString += "0, ";
            }
        }
        //Debug.Log(debugString);
        if (roomUIController.rooms[roomNumber - 1])
        {
            conditionalUI.SetActive(true);
        }
    }

    void Update()
    {
        if (roomUIController.rooms[roomNumber - 1])
        {
            conditionalUI.SetActive(true);
        }
        else
        {
            conditionalUI.SetActive(false);
        }
    }
}
