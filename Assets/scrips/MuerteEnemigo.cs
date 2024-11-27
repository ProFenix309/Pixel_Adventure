using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteEnemigo : MonoBehaviour
{
    public float vida = 100f; 

    public void Morir()
    {
        Debug.Log("�El enemigo ha muerto!");
        Destroy(gameObject);  
    }

    public void RecibirDa�o(float da�o)
    {
        vida -= da�o;
        Debug.Log("Vida del enemigo: " + vida); 

        if (vida <= 0)
        {
            Morir();  
        }
    }
}
