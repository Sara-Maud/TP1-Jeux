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

    public bool gameOver = false;
    public bool affame = true;
    public Animator animator;
    public float moveSpeed = 1.5f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            animator.SetTrigger("GameOver"); return;
        }

        if (affame)
        {

           
        }
        
      
    }


    void Manger()
    {
        affame = false;
    }
}
