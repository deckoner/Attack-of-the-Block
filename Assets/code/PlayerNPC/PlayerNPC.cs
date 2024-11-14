using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNPC : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    // Invulnerabilidad
    private bool esInvulnerable = false;
    [SerializeField] private int vidas = 3;
    [SerializeField] private float tiempoInvulnerable = 1.0f;

    // Referencias a las imágenes de las vidas
    [SerializeField] private Image vidaUno;
    [SerializeField] private Image vidaDos;
    [SerializeField] private Image vidaTres;


    //Maquina de estado
    // Array de enemigos
    public Transform[] enemigos;
    // Distancia para detectar enemigos
    public float distanciaDeteccion = 5f;
    // Distancia para estar seguro
    public float distanciaSegura = 10f;
    // Referencia al Animator del NPC
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        VerificarDistancias();
    }

    void OnCollisionEnter2D(Collision2D colision)
    {
        // Comprobar si ha chocado con un enemigo y no está en estado de invulnerabilidad
        if (colision.gameObject.CompareTag("Enemigo") && !esInvulnerable)
        {
            vidas--;

            if (vidas <= 0) 
            {
                Debug.Log("Bien has matado a tu hermano, has ganado puto asesino de mierda");
            } 
            else 
            {
                StartCoroutine(ActivarInvulnerabilidad());
                ActualizarVidaVisual(vidas);
            }
        }
    }

    private IEnumerator ActivarInvulnerabilidad()
    {
        // Cambiamos el sprit a rojo para que se note que esta dañado
        spriteRenderer.color = Color.red;
        esInvulnerable = true;

        yield return new WaitForSeconds(tiempoInvulnerable);

        // Le devolvemos el color normal al sprit
        spriteRenderer.color = Color.white;
        esInvulnerable = false;
    }

    private void ActualizarVidaVisual(int vidasRestantes)
    {
        // Ocultar la vida correspondiente según el número de vidas restantes
        if (vidasRestantes == 2)
        {
            vidaTres.enabled = false;
        }
        else if (vidasRestantes == 1)
        {
            vidaDos.enabled = false;
        }
        else if (vidasRestantes == 0)
        {
            vidaUno.enabled = false;
        }
    }

    private void VerificarDistancias()
    {
        bool enemigoCerca = false;
        bool estaSeguro = true;

        foreach (var enemigo in enemigos)
        {
            float distancia = Vector2.Distance(transform.position, enemigo.position);
            
            if (distancia < distanciaDeteccion)
            {
                // Un enemigo está dentro de la distancia de detección
                enemigoCerca = true;
                Debug.Log("Aiudaaaaaaaaaaaaaa");
            }
            
            if (distancia < distanciaSegura)
            {
                // Hay un enemigo demasiado cerca, no está seguro
                estaSeguro = false;
                Debug.Log("Estoy seguro");
            }
        }

        // Actualiza los parámetros en el Animator
        animator.SetBool("enemigoCerca", enemigoCerca);
        animator.SetBool("distanciaSegura", estaSeguro);
    }
}
