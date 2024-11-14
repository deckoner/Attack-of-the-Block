using UnityEngine;
using System.IO;
using System.Collections.Generic;

[System.Serializable]
public class DatosPuntuacion
{
    public float puntuacion;
    public string nombre;

    public DatosPuntuacion(float puntuacion, string nombre)
    {
        this.puntuacion = puntuacion;
        this.nombre = nombre;
    }
}

public static class ManagerJSON
{
    private static string rutaArchivo = Application.persistentDataPath + "/puntuacion.json";

    public static void GuardarPuntuacion(DatosPuntuacion nuevaPuntuacion)
    {
        // Cargar puntuaciones existentes
        DatosPuntuacion[] puntuacionesExistentes = CargarPuntuaciones();

        // Crear una lista a partir de las puntuaciones existentes
        List<DatosPuntuacion> listaPuntuaciones = new List<DatosPuntuacion>(puntuacionesExistentes);

        // Agregar la nueva puntuación a la lista
        listaPuntuaciones.Add(nuevaPuntuacion);

        // Serializar la lista completa usando el wrapper
        Wrapper<DatosPuntuacion> wrapper = new Wrapper<DatosPuntuacion> { items = listaPuntuaciones.ToArray() };
        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(rutaArchivo, json);
    }

    public static DatosPuntuacion[] CargarPuntuaciones()
    {
        // Comprobamos si existe ya un archivo de puntuación
        if (File.Exists(rutaArchivo))
        {
            // Leer y deserializar las puntuaciones usando el wrapper
            string json = File.ReadAllText(rutaArchivo);
            Wrapper<DatosPuntuacion> wrapper = JsonUtility.FromJson<Wrapper<DatosPuntuacion>>(json);
            return wrapper.items;
        }
        else
        {
            // Crear y guardar datos por defecto
            DatosPuntuacion[] datosPorDefecto = new DatosPuntuacion[]
            {
                new DatosPuntuacion(5000, "El rulas"),
                new DatosPuntuacion(2000, "Pedro el mapache"),
                new DatosPuntuacion(100, "El tipo gitano de barrio estereotípico, payo")
            };

            // Guardar los datos predeterminados directamente sin llamar a GuardarPuntuacion
            Wrapper<DatosPuntuacion> wrapper = new Wrapper<DatosPuntuacion> { items = datosPorDefecto };
            string json = JsonUtility.ToJson(wrapper, true);
            File.WriteAllText(rutaArchivo, json);

            return datosPorDefecto;
        }
    }

    // Wrapper para serializar y deserializar arrays de DatosPuntuacion
    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] items;
    }
}
