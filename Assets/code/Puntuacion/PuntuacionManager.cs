using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuntuacionManager : MonoBehaviour
{
    public float puntuacion;
    [SerializeField] private TMP_Text  puntuacionTexto;

    void Start()
    {
        puntuacion = 0f;
    }

    void Update()
    {
        // Solo actualiza la puntuación si el juego no está en pausa
        if (Time.timeScale > 0)
        {
            puntuacion += Time.unscaledDeltaTime;
            
            // Actualizar el texto de puntuación
            ActualizarTextoPuntuacion();
        }
    }

    private void ActualizarTextoPuntuacion()
    {
        // Convertir el tiempo a minutos y segundos
        int minutos = Mathf.FloorToInt(puntuacion / 60);
        int segundos = Mathf.FloorToInt(puntuacion % 60);
        
        // Formatear el texto
        puntuacionTexto.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    public void GuardarPuntuacion() 
    {
        PlayerPrefs.SetFloat("Puntuacion", puntuacion);
        PlayerPrefs.Save();
    }
}