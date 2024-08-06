using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : InteractableObject
{
    // Start is called before the first frame update

    [SerializeField] private string nextScene;
    protected override void Interact()
    {
        SceneManager.LoadScene(nextScene);
    }
}
