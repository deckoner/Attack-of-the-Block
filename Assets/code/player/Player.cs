using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool esInvulnerable = false;
    [SerializeField] private int vidas = 3;
    [SerializeField] private float tiempoInvulnerable = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            if (vidas <= 0) 
            {
                // Cerramos el juego ya que el jugador ha muerto
                Application.Quit();
                Debug.Log("Me morí al chocar con un enemigo");
            } 
            else 
            {
                vidas--;
                Debug.Log("Auch pierdo una vida");
                StartCoroutine(ActivarInvulnerabilidad());
            }
        }
    }

    private IEnumerator ActivarInvulnerabilidad()
    {
        esInvulnerable = true;
        // Aquí podrías agregar un efecto visual para indicar invulnerabilidad

        yield return new WaitForSeconds(tiempoInvulnerable);

        esInvulnerable = false;
        // Aquí podrías quitar el efecto visual
    }
}