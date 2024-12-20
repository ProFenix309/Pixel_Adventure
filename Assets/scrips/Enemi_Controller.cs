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
    public Vector2 tamaņoVision;
    public LayerMask capasVision;
    public float distancia;

    private bool facingRight = true; 
    public BoxCollider2D areaDeDaņo;
    public float daņo;

    private float tiempoEntreAtaques = 1f;
    private float tiempoUltimoAtaque = 0f;  
 
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        objetivo = Physics2D.OverlapBox(centroVision.position, tamaņoVision, 0, capasVision);
        anim.SetBool("JugadorDetectado", objetivo != null);

        if (objetivo != null)
        {
            distancia = Vector2.Distance(transform.position, objetivo.transform.position);
            anim.SetFloat("Distancia", distancia);

            Vector2 direccion = (objetivo.transform.position - transform.position).normalized;
            rigid.velocity = new Vector2(direccion.x * speed, rigid.velocity.y);

            FlipTowards(objetivo.transform.position.x);
        }
        else
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);

            GameObject jugador = GameObject.FindGameObjectWithTag("Player");
            if (jugador != null)
            {
                FlipTowards(jugador.transform.position.x);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(centroVision.position, tamaņoVision);

        if (areaDeDaņo != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(areaDeDaņo.transform.position, areaDeDaņo.size);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 escala = transform.localScale;
        escala.x = Mathf.Abs(escala.x) * (facingRight ? -1 : 1);
        transform.localScale = escala;
    }

    private void FlipTowards(float targetX)
    {
        if ((targetX > transform.position.x && !facingRight) || (targetX < transform.position.x && facingRight))
        {
            Flip();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && areaDeDaņo.IsTouching(other))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
            {
                if (Time.time - tiempoUltimoAtaque >= tiempoEntreAtaques)
                {
                    ScoreVida vida = other.GetComponent<ScoreVida>();
                    if (vida != null)
                    {
                        vida.RecibirDaņo(daņo); 
                        tiempoUltimoAtaque = Time.time;  
                    }
                }
            }
        }
    }
}
