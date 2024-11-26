using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreContoller : MonoBehaviour
{
    public delegate void ContadorPuntos(int nuevoValor);
    public ContadorPuntos contadorPuntos;

    [SerializeField] int cantidadMondeda = 0;
    public void CantidadPuntos(int puntos)
    {
        cantidadMondeda += puntos;
        contadorPuntos.Invoke(cantidadMondeda);
    }

}
