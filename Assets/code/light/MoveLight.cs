using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLight : MonoBehaviour
{
    // Radio del círculo
    [SerializeField] private float radio = 5f;
    // Velocidad de movimiento
    [SerializeField] private float velocidadMovimiento = 1f;
    private Vector2 posicionInicial;
    private Vector2 objetivoActual;

    void Start()
    {
        // Guardar la posición inicial del objeto (en 2D)
        posicionInicial = transform.position;

        // Generar una posición aleatoria inicial dentro del círculo
        objetivoActual = GenerarPosicionAleatoria();
    }

    void FixedUpdate()
    {
        // Mover el objeto hacia la posición objetivo de forma suave usando Lerp
        Vector2 nuevaPosicion = Vector2.Lerp(transform.position, objetivoActual, velocidadMovimiento * Time.fixedDeltaTime);
        transform.position = nuevaPosicion;

        // Si el objeto está cerca de la posición objetivo, generar una nueva
        if (Vector2.Distance(transform.position, objetivoActual) < 0.1f)
        {
            objetivoActual = GenerarPosicionAleatoria();
        }
    }

    // Generar una posición aleatoria dentro de un círculo (en 2D)
    Vector2 GenerarPosicionAleatoria()
    {
        // Generar un ángulo aleatorio
        float anguloAleatorio = Random.Range(0f, Mathf.PI * 2f);

        // Generar una distancia aleatoria dentro del radio
        float distanciaAleatoria = Random.Range(0f, radio);

        // Calcular la nueva posición en coordenadas X e Y
        float x = Mathf.Cos(anguloAleatorio) * distanciaAleatoria;
        float y = Mathf.Sin(anguloAleatorio) * distanciaAleatoria;

        // Devolver la nueva posición sumada a la posición inicial del objeto
        return new Vector2(posicionInicial.x + x, posicionInicial.y + y);
    }
}