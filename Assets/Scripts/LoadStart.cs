using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadStartSceen()
    {
        SceneManager.LoadScene("Start");
    }

    public void Reload_03()
    {
        SceneManager.LoadScene("03-GameScene");
    }
    public void Reload_02()
    {
        SceneManager.LoadScene("02-GameScene");
    }
}
