using UnityEngine;
using TMPro;

public class ControladorPuntos : MonoBehaviour
{
    public int puntuacion = 0;
    public TextMeshProUGUI textoPuntuacion;

    public void IncrementarPuntos(int cantidad)
    {
        puntuacion += cantidad;
        textoPuntuacion.text = puntuacion.ToString();
    }
}