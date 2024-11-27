using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    [SerializeField] private float vidaActual;  // Vida actual del enemigo
    public float vidaMaxima;  // Vida m�xima del enemigo

    // Este m�todo ser� llamado cuando el enemigo reciba da�o
    public void RecibirDa�o(float da�o)
    {
        vidaActual -= da�o;

        // Muestra la vida restante en la consola
        Debug.Log("Vida restante: " + vidaActual);

        // Si la vida llega a 0 o menos, el enemigo muere
        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    // M�todo para matar al enemigo (destruir el GameObject)
    private void Morir()
    {
        Debug.Log("El enemigo ha muerto.");
        Destroy(gameObject);  // Destruye el enemigo
    }
}
