using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuntuacionMneu : MonoBehaviour
{
    private DatosPuntuacion[] puntuaciones;
    private float puntuacionActual;
    [SerializeField] private TMP_Text[] puntuacionTextos;
    [SerializeField] private TMP_InputField nombreInputField;

    void Awake()
    {
        // Guardamos el nombre por defecto del participante
        PlayerPrefs.SetString("Nombre", "Pringado");
        PlayerPrefs.Save();

        // Cargar todas las puntuaciones desde el archivo
        puntuaciones = ManagerJSON.CargarPuntuaciones();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        MostrarTop5();
    }

    private void MostrarTop5()
    {
        // Crear una lista a partir de las puntuaciones cargadas
        List<DatosPuntuacion> listaPuntuaciones = new List<DatosPuntuacion>(puntuaciones);

        // Ordenar de mayor a menor
        listaPuntuaciones.Sort((a, b) => b.puntuacion.CompareTo(a.puntuacion));

        // Comprobar si hay puntuaciones
        if (listaPuntuaciones.Count == 0)
        {
            // Si no hay puntuaciones, mostrar un mensaje solo en el primer texto
            puntuacionTextos[0].text = "No hay puntuaciones disponibles";
            return; // No se si usar esto asi esta mal o no, en pythom estaria bien en C# no se
        }

        // Mostrar las 5 mejores puntuaciones
        for (int i = 0; i < 5; i++)
        {
            if (i < listaPuntuaciones.Count)
            {
                // Formatear el texto para el top 5 y pasamos lap untuacion a tiempo
                int minutos = Mathf.FloorToInt(listaPuntuaciones[i].puntuacion / 60);
                int segundos = Mathf.FloorToInt(listaPuntuaciones[i].puntuacion % 60);
                puntuacionTextos[i].text = $"{i + 1}. {listaPuntuaciones[i].nombre}: {minutos:00}:{segundos:00}";
            }
            else
            {
                // Si hay menos de 5 puntuaciones, limpiar el texto restante
                puntuacionTextos[i].text = "";
            }
        }
    }

    // Método para guardar el nombre del jugador
    public void GuardarNombre()
    {
        string nombre = nombreInputField.text;
        PlayerPrefs.SetString("Nombre", nombre);
        PlayerPrefs.Save();
    }
}
