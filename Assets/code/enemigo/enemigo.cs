using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoRebote : MonoBehaviour
{
    // Velocidad del enemigo
    [SerializeField] private float velocidad = 1000f;
    private Rigidbody2D rb;
    private Vector2 direccionMovimiento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Inicializar con una dirección aleatoria
        direccionMovimiento = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.AddForce(direccionMovimiento*velocidad);
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        Debug.Log("Funciono");
        rb.velocity=rb.velocity.normalized*100;
    }
}
