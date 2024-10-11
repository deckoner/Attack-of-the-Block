using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuntuacionGameOver : MonoBehaviour
{

    private float puntuacion;
    private String nombre;
    [SerializeField] private TMP_Text puntuacionTexto;

    void Awake()
    {
        puntuacion = PlayerPrefs.GetFloat("Puntuacion");
        nombre = PlayerPrefs.GetString("Nombre");
    }

    void Start()
    {
        int minutos = Mathf.FloorToInt(puntuacion / 60);
        int segundos = Mathf.FloorToInt(puntuacion % 60);

        puntuacionTexto.text = "Tu puntuacion es de "+string.Format("{0:00}:{1:00}", minutos, segundos);;
    }
}
