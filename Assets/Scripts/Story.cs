using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    

    void OnEnable()
    {
        //SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        Debug.Log("Loading the next scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
