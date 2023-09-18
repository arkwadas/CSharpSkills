using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutMethody : MonoBehaviour
{
    public GameObject cutter;
    public float cutSpeed = 1.0f;

    void Start()
    {
        cutter.GetComponent<MeshCollider>().isTrigger = true;
    }

    void Update()
    {
        // Przesuñ tn¹cy obiekt w kierunku przecinanego obiektu z okreœlon¹ prêdkoœci¹
        transform.position = Vector3.MoveTowards(transform.position, cutter.transform.position, cutSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // ZnajdŸ obiekt, który zosta³ przeciêty
        GameObject objectToCut = other.gameObject;

        // Wytnij obiekt za pomoc¹ tn¹cego obiektu
        Cut(objectToCut, cutter);
    }

    void Cut(GameObject objectToCut, GameObject cutter)
    {
        // Utwórz nowe GameObjecty dla obu po³ówek przecinanego obiektu
        GameObject newObject1 = new GameObject();
        GameObject newObject2 = new GameObject();

        // Ustaw nowe obiekty jako dzieci przecinanego obiektu
        newObject1.transform.parent = objectToCut.transform;
        newObject2.transform.parent = objectToCut.transform;

        // Dodaj MeshFilter i MeshRenderer do nowych obiektów
        newObject1.AddComponent<MeshFilter>();
        newObject1.AddComponent<MeshRenderer>();
        newObject2.AddComponent<MeshFilter>();
        newObject2.AddComponent<MeshRenderer>();

        // Wytnij siatkê przecinanego obiektu za pomoc¹ tn¹cego obiektu
        Mesh cutMesh1 = newObject1.GetComponent<MeshFilter>().mesh = objectToCut.GetComponent<MeshFilter>().mesh;
        Mesh cutMesh2 = newObject2.GetComponent<MeshFilter>().mesh = objectToCut.GetComponent<MeshFilter>().mesh;

        // Dodaj materia³ do nowych obiektów
        newObject1.GetComponent<MeshRenderer>().material = objectToCut.GetComponent<MeshRenderer>().material;
        newObject2.GetComponent<MeshRenderer>().material = objectToCut.GetComponent<MeshRenderer>().material;

        // Wytnij siatkê za pomoc¹ klasy PlaneCut
        //PlaneCut.Cut(cutMesh1, cutMesh2, cutter.transform.position, cutter.transform.up, objectToCut.transform.position);
    }
}

