using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    private bool isGameOver = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            isGameOver = true;
            // Vous pouvez ajouter d'autres actions ici si nécessaire
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
