using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class HPController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hp;
    public GameObject hpTxt;
    PlayerProperty PlayerProperty;

    void Start()
    {
        PlayerProperty = GameObject.FindWithTag("Player").GetComponent<PlayerProperty>();
    }


    private void FixedUpdate()
    {
        hp.transform.localScale = new Vector3(PlayerProperty.hp / PlayerProperty.hpValue, 1, 1);
        hpTxt.GetComponent<TextMeshProUGUI>().text=(PlayerProperty.hp+ "/" +PlayerProperty.hpValue);
    }
}

