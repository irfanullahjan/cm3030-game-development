using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.OnPlayerWin += Win;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerWin -= Win;
    }

    private void Win()
    {
        // code to display you win.
    }
}
