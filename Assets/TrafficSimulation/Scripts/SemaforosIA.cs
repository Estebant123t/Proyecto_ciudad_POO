using System.Collections;
using System.Collections.Generic;
using TrafficSimulation;
using UnityEngine;

public class SemaforosIA : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    public List<GameObject> objectList = new List<GameObject>();
    public float rayLenght = 50;


    void Update()
    {

        Intersection intersection = new Intersection();
        GameObject object0 = objectList[0];

        Ray ray0 = new Ray(object0.transform.position, object0.transform.forward);
        Debug.DrawRay(ray0.origin, ray0.direction, Color.green);

        RaycastHit[] hits = Physics.RaycastAll(object0.transform.position, transform.forward, rayLenght);

        RaycastHit hit0;

        if (!Physics.Raycast(ray0, out hit0, rayLenght))//, mask))
        {
            print("se ha cancelado");
            //CancelInvoke("SwitchLights");
            //CancelInvoke("MoveVehiclesQueue");

            //InvokeRepeating("SwitchLights", intersection.lightsDuration, intersection.lightsDuration);
            //Invoke("MoveVehiclesQueue", intersection.orangeLightDuration);
        }
    }
    void ContarVehiculo(GameObject vehiculo)
    {
        // Aquí puedes realizar acciones específicas para contar el vehículo
        // Puedes aumentar un contador, imprimir en la consola, etc.
        print("Ha pasado un vehículo: " + vehiculo.name);
    }
}