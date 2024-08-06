using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraAnim : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainCamera;
    public GameObject animCamera;
    void Start()
    {
        StartCoroutine(SetCam());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void SetCamera()
    {
        animCamera.SetActive(false);
        mainCamera.SetActive(true);
    }
    IEnumerator SetCam()
    {
        yield return new WaitForSeconds(3.55f);
        SetCamera();
    }
}
