using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    [SerializeField] ScoreVida vida;

    [SerializeField] Image barra;

    private void Start()
    {
        vida.DañoRecibido += ActualizarBarra;
        vida.CuraRecibida += ActualizarBarra;
    }

    public void ActualizarBarra(float nuevoValor)
    {
        barra.fillAmount = (1/vida.vidaMaxima) * nuevoValor;
    }
}
