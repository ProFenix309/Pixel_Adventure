using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemi_Controller : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigid;

    public Collider2D objetivo;
    public float speed;
    public Transform centroVision;
    public Vector2 tamañoVision;
    public LayerMask capasVision;
    public float distancia;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        objetivo = Physics2D.OverlapBox(centroVision.position, tamañoVision,0 , capasVision);
        anim.SetBool("JugadorDetectado", objetivo);

        if (objetivo != null)
        {
            distancia = Vector2.Distance(transform.position, objetivo.transform.position);
            anim.SetFloat("Distancia",distancia);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(centroVision.position, tamañoVision);
    }
}
