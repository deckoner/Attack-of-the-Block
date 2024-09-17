using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Posicion de raton en pantalla
        Vector2 posicionRaton = Input.mousePosition;

        // Convertir la posición del ratón a cordenadas en el juego
        posicionRaton = Camera.main.ScreenToWorldPoint(posicionRaton);

        // Actualizar la posición del objeto usando Rigidbody
        rb.MovePosition(posicionRaton);
    }
}
