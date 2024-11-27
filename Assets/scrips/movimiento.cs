using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    Rigidbody2D rg;
    float valorHorizontal;
    public float velocidad;
    [SerializeField] float JumpForce;


    float xInicial, yInicial;

    public Joystick joystick;

    [SerializeField] bool isGrounded;
    [SerializeField] Transform puntoDeteccion;
    [SerializeField] Vector2 tamanoDeteccion;
    [SerializeField] LayerMask capaDeteccion;

    private Animator animator;
    private SpriteRenderer render;


    void Start()
    {
        xInicial = transform.position.x;
        yInicial = transform.position.y;
        rg = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapBox(puntoDeteccion.position, tamanoDeteccion, 0, capaDeteccion);
        animator.SetBool("enSuelo", isGrounded);

        float velocidadVertical = rg.velocity.y;
        animator.SetFloat("VelocidadVertical", velocidadVertical);

        Movimiento();
        animator.SetFloat("horizantal", Mathf.Abs(valorHorizontal));
        Flip();
    }

    private void Movimiento()
    {
       // valorHorizontal = Input.GetAxis("Horizontal");
        valorHorizontal = joystick.Horizontal;
        rg.velocity = new Vector2(valorHorizontal * velocidad, rg.velocity.y);
    }


    public void JumpButton()
    {
        if (isGrounded)
        {
            rg.AddForce(new Vector2(0, 1) * JumpForce, ForceMode2D.Impulse);
        }
    }

    private void Flip()
    {
        if (valorHorizontal >= 0)
        {
            render.flipX = false;
        }
        else if (valorHorizontal != 0)
        {
            render.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(puntoDeteccion.position, tamanoDeteccion);
    }

    public void Recolocar()
    {
        transform.position = new Vector3(xInicial, yInicial, 0);
    }




}