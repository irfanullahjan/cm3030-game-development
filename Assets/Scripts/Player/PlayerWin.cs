using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour
{
    public GameObject winPanel;

    private void OnEnable()
    {
        EventManager.OnPlayerWin += Win;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerWin -= Win;
    }

    IEnumerator WaitToDisplayMenu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }

    private void Win()
    {
        // code to display you win.
        winPanel.SetActive(true);
        StartCoroutine(WaitToDisplayMenu());
    }
}
