using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    private bool isGameOver = false;
    public AudioClip sonGameOver;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            isGameOver = true;
            audioSource.PlayOneShot(sonGameOver);
            // Vous pouvez ajouter d'autres actions ici si nécessaire
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
