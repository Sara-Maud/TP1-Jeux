using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    /* Si affamé et en jeu (pas gameOver), l’animal se déplace de droite à gauche lentement mais demeure à l’écran
            ➢ Si nourri et en jeu, l’animal se déplace vers en dehors de l’écran par la gauche ou par la droite
            ➢ Fonction Manger() qui nourri l’animal et change son état
            ➢ Gère les animations de l’animal
            ➢ Si gameOver, l’animal doit agir d’une autre façon (au choix de l’étudiant)*/


    private float speed = 3f;
    private Vector3 direction;
    public bool estAffame = true;
    private bool gameOver = false;
    private Animator animatorAnimal;
    private GameOverTrigger gameOverTrigger;
    public AudioClip sonManger;
    private float limite = 10;

    private AudioSource audioSource;
    private float tempsAttente = 0f;


    void Start()
    {
        // Initialiser la direction de l'animal
        direction = Vector3.forward;
        animatorAnimal = GetComponent<Animator>();
        gameOverTrigger = FindObjectOfType<GameOverTrigger>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (gameOverTrigger != null && gameOverTrigger.IsGameOver())
        {
            Debug.Log("Game Over");
            animatorAnimal.SetFloat("Speed_f", 0f);
            //Les animaux s'envolent
            transform.Rotate(0, 2, 0);
            transform.Translate(0, 0.001f, 0);

            return;
        }

        if (estAffame)
        {
            // Déplacer l'animal dans la direction actuelle
            transform.Translate(direction * speed * Time.deltaTime);

            // Vérifier si l'animal touche les bords gauche ou droit
            if (transform.position.x <= -limite || transform.position.x >= limite)
            {
                direction.x = -direction.x;
                transform.Rotate(0, 180, 0);
            }
        }
        else
        {
            animatorAnimal.SetBool("Eat_b", true);
            animatorAnimal.SetFloat("Speed_f", 0f);
            tempsAttente += Time.deltaTime;
            if(tempsAttente >= 3f)
            {
                animatorAnimal.SetBool("Eat_b", false);
                animatorAnimal.SetFloat("Speed_f", 0.8f);

                transform.Translate(direction * speed * Time.deltaTime * 3);
                if (transform.position.x >= 20 || transform.position.x <= -20)
                    Destroy(gameObject);
            }
        }
       
    }
    

    public void Manger()
    {
        //transform.Translate(direction * speed * Time.deltaTime);
        Debug.Log("Manger");
        //Faire jouer le son de manger
        audioSource.PlayOneShot(sonManger);
        estAffame = false;
    }


}