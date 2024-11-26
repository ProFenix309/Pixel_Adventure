using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreVida : MonoBehaviour
{
    public delegate void ModificadorVida(float nuevoValor);
    public ModificadorVida DañoRecibido;
    public ModificadorVida CuraRecibida;


    [SerializeField] float vidaActual;
    public float vidaMaxima;

    private void Start()
    {
        vidaMaxima = vidaActual;
    }
    public void RecibirDaño(float daño)
    {
        vidaActual -= daño;

        DañoRecibido?.Invoke(vidaActual);

        if (vidaActual <= 0)
        {
            Debug.Log("Estas muerto");
            Destroy(gameObject);
        }
    }

    public void RecibirCura(float cura)
    {
        vidaActual += cura;

        CuraRecibida.Invoke(vidaActual);

        if (vidaActual >= vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }
    }
}
