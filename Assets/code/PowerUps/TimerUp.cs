using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUp : MonoBehaviour
{
    private bool activo;
    [SerializeField] float tiempoActivo = 1f;
    [SerializeField] private AudioSource musica;
    [SerializeField] private Vector2 fueraDeEscena;
    [SerializeField] private PowerupManager powerupManager;

    void OnCollisionEnter2D(Collision2D colision)
    {
        // Comprobar si ha chocado con el jugador
        if (colision.gameObject.CompareTag("Player"))
        {
            // Activar el temporizador
            activo = true;

            // Realentizamos el juego a la mitad
            Time.timeScale = 0.5f;

            // Bajamos el pitch de la música un 0,05 para el efecto de relentización
            musica.pitch = 0.95f;

            Invoke(nameof(ResetEffects), tiempoActivo * Time.timeScale);

            // Desactivar y mover el powerup fuera de la escena
            powerupManager.DesactivarPowerup(this.gameObject, fueraDeEscena);
        }
    }

    private void ResetEffects()
    {
        // Restablecer el tiempo y el pitch
        Time.timeScale = 1f;
        musica.pitch = 1f;

        // Desactivar el temporizador
        activo = false;

        // Reiniciar el tiempo activo
        tiempoActivo = 1f;
    }
}
