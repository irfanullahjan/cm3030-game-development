using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLose : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.OnPlayerLose += Lose;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerLose -= Lose;
    }

    private void Lose()
    {
        // code to display game over.
    }
}
