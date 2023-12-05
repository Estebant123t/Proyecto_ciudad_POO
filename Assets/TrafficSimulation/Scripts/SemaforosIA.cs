using System.Collections;
using System.Collections.Generic;
using TrafficSimulation;
using UnityEngine;

public class SemaforosIA : MonoBehaviour
{
    [SerializeField] private LayerMask toDetect;
    public List<GameObject> objectList = new List<GameObject>();
    public float rayLenght = 10;
    public Color rayColor = Color.green;
    public Color rayColor1 = Color.red;

    public Intersection inter;

    private GameObject object0;
    private GameObject object1;
    private GameObject object2;
    private GameObject object3;


    // Start is called before the first frame update
    void Start() {
        GameObject tuObjeto = new GameObject("NombreDelObjeto");
        Intersection intersection = tuObjeto.AddComponent<Intersection>();

        object0 = objectList[0];
        object1 = objectList[1];
        object2 = objectList[2];
        object3 = objectList[3];


        InvokeRepeating("revisar", 1, 1);
    }

    public void revisar()
    {
        GameObject tuObjeto = new GameObject("NombreDelObjeto");
        Intersection intersection = tuObjeto.AddComponent<Intersection>();

        RaycastHit hit;

        Ray ray0 = new(object0.transform.position, object0.transform.forward);
        Debug.DrawRay(ray0.origin, ray0.direction * rayLenght, Color.green);
        Ray ray1 = new Ray(object1.transform.position, object1.transform.forward);
        Debug.DrawRay(ray1.origin, ray1.direction * rayLenght, Color.green);
        Ray ray2 = new Ray(object2.transform.position, object2.transform.forward);
        Debug.DrawRay(ray2.origin, ray2.direction * rayLenght, Color.green);
        Ray ray3 = new Ray(object3.transform.position, object3.transform.forward);
        Debug.DrawRay(ray3.origin, ray3.direction * rayLenght, Color.green);



        if ((!Physics.Raycast(ray0, out hit, rayLenght)) || (!Physics.Raycast(ray, out hit, rayLenght)))
        {
            intersection.cambiar();
            
            print("no toca nada");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
