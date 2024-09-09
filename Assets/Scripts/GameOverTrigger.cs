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


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Animal") && collider.gameObject.GetComponent<AnimalController>().estAffame)
        {
            isGameOver = true;
            audioSource.PlayOneShot(sonGameOver);
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
