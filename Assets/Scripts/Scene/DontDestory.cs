using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject cavas;
    [SerializeField]
    private GameObject eventManger;
    [SerializeField]
    private DontDestory _dontDestory;
    void Start()
    {
        if(_dontDestory == null)
        {
            _dontDestory = this;
            DontDestroyOnLoad(cavas);
            DontDestroyOnLoad(eventManger);


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
