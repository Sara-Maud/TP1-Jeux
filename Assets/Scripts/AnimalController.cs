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


    public float speed = 3f;
    private Vector3 direction;
    private bool estAffame = true;
    private bool gameOver = false;


    void Start()
    {
        // Initialiser la direction de l'animal
        direction = Vector3.forward;
    }
    void Update()
    {

        if (estAffame)
        {
            // Déplacer l'animal dans la direction actuelle
            transform.Translate(direction * speed * Time.deltaTime);

            // Vérifier si l'animal touche les bords gauche ou droit
            if (transform.position.x <= -25 || transform.position.x >= 25)
            {
                direction.x = -direction.x;
                transform.Rotate(0, 180, 0);
            }

            if (transform.position.z <= -25 )
            {
                gameOver = true;
                Debug.Log("Game Over");
            }
        }
        else
        {
        }

    }
}