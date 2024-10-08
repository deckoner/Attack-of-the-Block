using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoControler : MonoBehaviour
{
    // Velocidad del enemigo
    public float velocidad = 10f;
    private Rigidbody2D rb;
    private Vector2 direccionMovimiento;
    private AudioSource reboteSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        reboteSound = GetComponent<AudioSource>();

        // Inicializar con una dirección de movimiento aleatoria
        direccionMovimiento = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    void FixedUpdate()
    {
        // Mover el enemigo en la dirección actual
        rb.MovePosition(rb.position + direccionMovimiento * velocidad * Time.fixedDeltaTime);
    }

    // Método llamado automáticamente cuando hay una colisión
    void OnCollisionEnter2D(Collision2D colision)
    {
        // Reproducimos el sonido de rebote
        reboteSound.Play();

        // Rebote básico: invertir la dirección del movimiento cuando colisiona con algo
        direccionMovimiento = Vector2.Reflect(direccionMovimiento, colision.contacts[0].normal);
    }
}
