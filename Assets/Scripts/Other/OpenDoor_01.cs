using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor_01 : MonoBehaviour
{
    // Start is called before the first frame update
    private TaskNPCObject taskNPCObject;
    public GameObject door;
    void Start()
    {
        taskNPCObject = GameObject.Find("Npc").GetComponent<TaskNPCObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (taskNPCObject != null&& taskNPCObject.gameTaskSO.state== GameTaskState.Completed)
        {
            Debug.Log("Open!");
            door.SetActive(true);
        }
    }
}
