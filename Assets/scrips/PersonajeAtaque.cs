using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeAtaque : MonoBehaviour
{
    public float fuerzaAtaque = 10f;  
    public BoxCollider2D boxColliderAtaque;  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MuerteEnemigo enemigo = collision.gameObject.GetComponent<MuerteEnemigo>();
      
        if (enemigo != null && boxColliderAtaque.IsTouching(collision))
        {
            Debug.Log("¡El personaje tocó al enemigo!");
            enemigo.RecibirDaño(fuerzaAtaque); 
        }
    }
}
