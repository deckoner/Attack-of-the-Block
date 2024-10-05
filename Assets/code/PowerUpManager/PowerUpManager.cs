using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> powerups;

    // Tiempo mínimo y máximo para aparecer un powerup
    [SerializeField] private float minTime = 5f;
    [SerializeField] private float maxTime = 10f;

    // Zona de juego donde los powerups aparecerán aleatoriamente
    [SerializeField] private Vector2 limiteMin;
    [SerializeField] private Vector2 limiteMax;

    // Powerups activos
    private List<GameObject> powerupsActivos = new List<GameObject>();

    void Start()
    {
        // Comenzamos el ciclo de aparición de powerups
        ActivarPowerups();
    }

    private void ActivarPowerups()
    {
        // Establecemos un tiempo aleatorio y llamamos a la activación de powerups usando Invoke
        float tiempoEspera = Random.Range(minTime, maxTime);
        Invoke(nameof(SeleccionarYActivarPowerup), tiempoEspera);
    }

    private void SeleccionarYActivarPowerup()
    {
        // Seleccionar un powerup que no esté activo
        List<GameObject> powerupsDisponibles = powerups.FindAll(p => !powerupsActivos.Contains(p));

        if (powerupsDisponibles.Count > 0)
        {
            // Seleccionar un powerup aleatoriamente
            GameObject powerupSeleccionado = powerupsDisponibles[Random.Range(0, powerupsDisponibles.Count)];

            // Posicionarlo dentro de la zona de juego de forma aleatoria
            Vector2 posicionAleatoria = new Vector2(
                Random.Range(limiteMin.x, limiteMax.x),
                Random.Range(limiteMin.y, limiteMax.y)
            );
            powerupSeleccionado.transform.position = posicionAleatoria;

            // Activar el powerup
            powerupSeleccionado.SetActive(true);
            powerupsActivos.Add(powerupSeleccionado);
        }

        // Llamar de nuevo a la activación después de un tiempo aleatorio
        ActivarPowerups();
    }

    public void DesactivarPowerup(GameObject powerup, Vector2 nuevaPosicion)
    {
        // Mover el powerup a la nueva posición
        powerup.transform.position = nuevaPosicion;

        // Desactivarlo
        powerup.SetActive(false);

        // Removerlo de la lista de powerups activos
        powerupsActivos.Remove(powerup);
    }
}
