using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
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

    [SerializeField] private ScenesManager scenesManager;
    [SerializeField] private PuntuacionManager puntuacionManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Cursor.visible=false;
    }

    // Update is called once per frame
    void Update()
    {
        // Posicion de raton en pantalla
        Vector2 posicionRaton = Input.mousePosition;

        // Convertir la posición del ratón a cordenadas en el juego
        posicionRaton = Camera.main.ScreenToWorldPoint(posicionRaton);

        // Actualizar la posición del objeto usando Rigidbody
        rb.MovePosition(posicionRaton);
    }

    void OnCollisionEnter2D(Collision2D colision)
    {
        // Comprobar si ha chocado con un enemigo y no está en estado de invulnerabilidad
        if (colision.gameObject.CompareTag("Enemigo") && !esInvulnerable)
        {
            vidas--;

            if (vidas <= 0) 
            {
                // Guardamos la puntuacion y ponemos la pantalla de gameover
                puntuacionManager.GuardarPuntuacion();
                scenesManager.cargarGameOver();
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
}