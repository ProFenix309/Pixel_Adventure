using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    [SerializeField] float daño;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreVida vida;
        if (collision.TryGetComponent(out vida))
        {
            vida.RecibirDaño(daño);
        }
    }
}
