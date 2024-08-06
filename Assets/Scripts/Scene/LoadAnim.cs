using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAnim : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dotText;
    [SerializeField] private string sceneName;
    private float dotRate = 0.3f;


    private void Start()
    {
        StartCoroutine(DotAnimation());
    }

    IEnumerator DotAnimation()
    {
        while (true)
        {
            dotText.text = ".";
            yield return new WaitForSeconds(dotRate);
            dotText.text = "..";
            yield return new WaitForSeconds(dotRate);
            dotText.text = "...";
            yield return new WaitForSeconds(dotRate);
            dotText.text = "....";
            yield return new WaitForSeconds(dotRate);
            dotText.text = "....";
            yield return new WaitForSeconds(dotRate);
            dotText.text = ".....";
            yield return new WaitForSeconds(dotRate);
            dotText.text = ".....";
            SceneManager.LoadScene(sceneName);
            yield return new WaitForSeconds(dotRate);
            
        }
    }
}
