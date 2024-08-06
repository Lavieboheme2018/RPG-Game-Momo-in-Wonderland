using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_03 : MonoBehaviour
{
    public GameObject firstTalk;
    public GameObject mainCamera;
    public GameObject animCamera;
    public GameObject bossTalk;
    static public bool animOver;
    bool once=false;
    bool once_2 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReadOver();
        StartAnimCamera();
        StartBossTalk();
    }


    private void ReadOver()
    {
        if(Input.anyKey)
        {
           firstTalk.SetActive(false);
            
        }

    }
    private void StartAnimCamera()
    {
        if(!firstTalk.activeInHierarchy&&!animCamera.activeInHierarchy&&!once_2)
        {
            animCamera.SetActive(true);
            once_2 = true;
            StartCoroutine(AnimEnd());
        }
    }

    private void StartBossTalk()
    {
        if(animOver&&!once)
        {
            bossTalk.SetActive(true);
            once = true;
            
        }
        if (!bossTalk.activeInHierarchy&&animOver)
        {
            animCamera.SetActive(false);
            mainCamera.SetActive(true);
        }
    }
    IEnumerator AnimEnd()
    {
        yield return new WaitForSeconds(1f);
        animOver = true;
    }
}
