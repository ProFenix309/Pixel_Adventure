using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curar : MonoBehaviour
{
    [SerializeField] float cura;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreVida vida;
        if (collision.TryGetComponent(out vida))
        {
            vida.RecibirCura(cura);
            gameObject.SetActive(false);
        }
    }
}
