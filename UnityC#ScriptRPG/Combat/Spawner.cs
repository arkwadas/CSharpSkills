using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // parametry spawnu
    public Vector2 spawnArea = new Vector2(2, 2); // wymiary kwadratu
    public float spawnFrequency = 1.0f; // co ile sekund ma siê pojawiaæ nowy wrog
    public List<GameObject> enemyPrefabs; // lista prefabów wrogów do spawnowania
    public bool infiniteWave = true; // czy spawner ma dzia³aæ w trybie "nieskoñczonej fali"
    private float spawnTimer = 0.0f; // licznik czasu do nastêpnego spawnu
    private int enemyIndex = 0; // indeks aktualnie spawnowanego wroga

    void Update()
    {
        // zwiêkszamy licznik czasu
        spawnTimer += Time.deltaTime;

        // sprawdzamy, czy licznik osi¹gn¹³ wartoœæ spawnFrequency
        if (spawnTimer >= spawnFrequency)
        {
            // spawnujemy nowego wroga
            SpawnEnemy();

            // resetujemy licznik
            spawnTimer = 0.0f;
        }
    }

    /*private void SpawnEnemy()
    {
        // losujemy pozycjê spawnu w obrêbie kwadratu
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            Random.Range(-spawnArea.y / 2, spawnArea.y / 2),
            0);
        spawnPosition += transform.position;

        // Pobieramy prefab wroga z
    }*/

    private void SpawnEnemy()
    {
        // sprawdzenie czy lista prefabów jest pusta
        if (enemyPrefabs.Count == 0)
        {
            Debug.LogError("Lista prefabów jest pusta.");
            return;
        }

        // losujemy pozycjê spawnu w obrêbie kwadratu
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            Random.Range(-spawnArea.y / 2, spawnArea.y / 2),
            0);
        spawnPosition += transform.position;

        // Sprawdzamy czy indeks jest mniejszy ni¿ liczba elementów w liœcie
        if (enemyIndex >= enemyPrefabs.Count)
        {
            // Jeœli tak, resetujemy indeks do 0
            enemyIndex = 0;
        }

        // Pobieramy prefab wroga z listy na pozycji enemyIndex
        GameObject enemyPrefab = enemyPrefabs[enemyIndex];

        // Tworzymy nowy obiekt wroga na pozycji spawnPosition
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Inkrementujemy indeks wroga
        enemyIndex++;

        // Sprawdzamy czy tryb jest ustawiony na "koñcow¹ falê"
        if (!infiniteWave)
        {
            // Sprawdzamy czy indeks przekroczy³ liczbê prefabów
            if (enemyIndex >= enemyPrefabs.Count)
            {
                //resetujemy indeks wroga na pocz¹tek listy
                enemyIndex = 0;
                //usuwamy obiekt spawnera z sceny
                Destroy(this.gameObject);
                return;
            }
        }
    }
}