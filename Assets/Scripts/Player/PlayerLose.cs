using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLose : MonoBehaviour
{
    public GameObject losePanel;

    private void OnEnable()
    {
        EventManager.OnPlayerLose += Lose;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerLose -= Lose;
    }

    IEnumerator WaitToDisplayMenu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }

    private void Lose()
    {
        // code to display game over.
        losePanel.SetActive(true);
        StartCoroutine(WaitToDisplayMenu());
    }
}
