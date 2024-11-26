using UnityEngine;

public class ObjetoRecolectar : MonoBehaviour
{
    public int valorPunto = 1; // Valor que suma este recolectable

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Asegúrate de que el jugador tenga la etiqueta "Player"
        {
            // Encuentra el controlador de puntos y actualiza el puntaje
            FindObjectOfType<ControladorPuntos>().IncrementarPuntos(valorPunto);

            // Desactiva este recolectable
            gameObject.SetActive(false);
        }
    }
}
