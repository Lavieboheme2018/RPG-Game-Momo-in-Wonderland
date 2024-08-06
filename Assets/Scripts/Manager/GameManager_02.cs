using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager_02 : MonoBehaviour
{
    // Start is called before the first frame update
    private int keyNum = 0;
    public GameObject winBoard;
    public GameObject txt;
    public GameObject defeat;
    public int needNum = 3;
    public GameObject door;
    private PlayerProperty playerProperty ;
    void Start()
    {
        playerProperty = GameObject.FindWithTag("Player").GetComponent<PlayerProperty>();
        if(winBoard!=null)
        {
            winBoard.SetActive(false);
        }
        if(defeat!=null)
        {
            defeat.SetActive(false);
        }
        if (door != null)
        {
            door.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(keyNum>= needNum)
        {
            if (door == null)
            {
                Time.timeScale = 0.1f;
                winBoard.SetActive(true);
            }else door.SetActive(true);
            

        }
        if(playerProperty.hp<=0)
        {
            Debug.Log("Player is die");
            defeat.SetActive(true);
        }
        if(txt!=null)
        {
            txt.GetComponent<TextMeshProUGUI>().text = keyNum + "/" + needNum;
        }
    }

    public void GetKey()
    {
        keyNum++;
    }
}
