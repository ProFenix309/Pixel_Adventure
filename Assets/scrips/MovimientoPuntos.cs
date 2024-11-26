using UnityEngine;

public class MovimientoPuntos : MonoBehaviour
{
    public Transform[] puntos; 
    public float velocidad = 5f; 
    private int puntoActual = 0; 

    void Update()
    {
        if (puntos.Length == 0) return;

        transform.position = Vector3.MoveTowards(transform.position, puntos[puntoActual].position, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, puntos[puntoActual].position) < 0.1f)
        {
            puntoActual = (puntoActual + 1) % puntos.Length; 
        }
    }
}
