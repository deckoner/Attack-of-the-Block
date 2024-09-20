using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class putuacionMnager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterText;
    private int counter = 0;

    // Controla el tiempo transcurrido
    private float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Mostrar el contador a 0
        counterText.text = counter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // Incrementar el tiempo transcurrido
        timeElapsed += Time.deltaTime;

        // Convertir el tiempo en minutos y segundos
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);

        // Formatear el texto para que se muestre como mm:ss
        counterText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
