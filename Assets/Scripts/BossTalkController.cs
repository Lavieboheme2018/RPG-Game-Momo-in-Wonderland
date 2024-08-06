using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossTalkController : MonoBehaviour
{
    // Start is called before the first frame update
    private int num = 0;
    public List<string> bossTalks = new List<string>();
    public GameObject txt;
    void Start()
    {
        //transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (num >= bossTalks.Count)
        {
            transform.gameObject.SetActive(false);
        }
        else
        {
            txt.GetComponent<TextMeshProUGUI>().text = bossTalks[num];
        }
       
        
    }

    public void OnClickOK()
    {
        num++;
    }
}
