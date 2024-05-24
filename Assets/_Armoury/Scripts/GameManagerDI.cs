using System.Collections.Generic;
using UnityEngine;

public class GameManagerDI : MonoBehaviour
{
    public static GameManagerDI Instance;

    public GameObject playerPrefab;
    public GameObject gunPrefab;
    public GameObject swordPrefab;
    public Transform spawnPoint;

    public List<EnemyDI> enemies = new List<EnemyDI>(); // List of enemies


    void Start()
    {
        if (Instance == null) Instance = this;
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        if (playerPrefab != null)
        {
            GameObject player = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);

            
        }
        else
        {
            Debug.LogError("Player prefab is not assigned in the GameManager!");
        }
    }

    // Method to add an enemy to the list
    public void AddEnemy(EnemyDI enemy)
    {
        enemies.Add(enemy);
    }

    // Method to remove an enemy from the list
    public void RemoveEnemy(EnemyDI enemy)
    {
        enemies.Remove(enemy);
    }
}