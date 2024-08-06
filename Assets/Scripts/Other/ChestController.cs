using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager_02 gameManager;
    bool once;
    void Start()
    {
        gameManager=GameObject.FindWithTag("GameManager").GetComponent<GameManager_02>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null)
        {
            if(collision.gameObject.tag =="Player"&&!once)
            {
                Debug.Log("A player!");
                gameManager.GetKey();
                transform.GetComponent<Animator>().SetBool("isOpen", true);
                once = true;
                //transform.GetComponent<Collider>().enabled = false;
                Destroy(transform.gameObject,2f);
            }
        }
    }
}
