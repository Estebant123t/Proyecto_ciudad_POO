
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public float speed = 2;

    float ejeX;
    float ejeY;

    private void Start()
    {
        
    }
    public float velocidadMovimiento = 25.0f; // Velocidad de movimiento

    void Update()
    {
        // Movimiento de la cámara con teclas WASD
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical) * velocidadMovimiento * Time.deltaTime;
        movimiento = transform.TransformDirection(movimiento); // Transforma el movimiento relativo a la dirección de la cámara
        transform.position += movimiento;

        // Movimiento de la camara con mouse
        ejeX += speed * Input.GetAxis("Mouse X");
        ejeY -= speed * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(ejeY, ejeX, 0.0f);

        if (Input.GetKey("e"))
        {
            transform.Translate(Vector3.up * velocidadMovimiento * Time.deltaTime);
        }
        if (Input.GetKey("q"))
        {
            transform.Translate(Vector3.down * velocidadMovimiento * Time.deltaTime);
        }
    }
}