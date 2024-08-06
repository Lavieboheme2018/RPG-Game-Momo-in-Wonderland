using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menuUI;
    public List<Material> materials;
    public GameObject cat;
    void Start()
    {
        //cat = GameObject.FindWithTag("Cat");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  void OnClickMenu()
    {
        if (menuUI != null)
        {
            if(!menuUI.activeInHierarchy)
            {
                menuUI.SetActive(true);
            }
            else
            {
                menuUI.SetActive(false);
            }
        }
    }

    public void OnClickExchange()
    {
        if(materials != null)
        {
            int i=Random.Range(0,materials.Count);
            cat.GetComponent<SkinnedMeshRenderer>().material = materials[i];
        }
    }
}
