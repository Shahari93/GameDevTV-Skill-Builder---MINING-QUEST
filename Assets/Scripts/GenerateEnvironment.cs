// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnvironment : MonoBehaviour
{
    [SerializeField] private GameObject groundTilePrefab;
    [SerializeField] private Sprite[] groundSprites;
    [SerializeField] private GameObject rockTilePrefab;
    [SerializeField] private Sprite[] rockSprites;
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private Sprite[] foodSprites;
    [SerializeField] private GameObject exitPrefab;
    [SerializeField] private int amountOfEnemies;
    [SerializeField] private GameObject enemyPrefab;

    private int exitLocation;
    private Vector2 rockPos;


    void Start()
    {
        GenerateFloor();
        SpawnEnemies();
        SpawnFood();
    }

    private void GenerateFloor()
    {
        for (int x = 0; x < 20; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                InstantiateFloorTile(x, y);
                SpawnRocks();
            }
        }
    }

    private void InstantiateFloorTile(int x, int y)
    {
        GameObject newFloorTile = Instantiate(groundTilePrefab, new Vector2(x, y), Quaternion.identity);
        newFloorTile.GetComponent<SpriteRenderer>().sprite = groundSprites[Random.Range(0, groundSprites.Length)];
    }

    private void SpawnRocks()
    {
        rockPos = new Vector2(Random.Range(1, 20), Random.Range(1, 20));
        GameObject newRock = Instantiate(rockTilePrefab, new Vector2(rockPos.x, rockPos.y), Quaternion.identity);
        newRock.GetComponent<SpriteRenderer>().sprite = rockSprites[Random.Range(0, rockSprites.Length)];
    }

    private void SpawnFood()
    {
        for (int i = 0; i < rockPos.x; i++)
        {
            if (i == rockPos.x && i == rockPos.y)
            {
                return;
            }
            else
            {
                GameObject newFood = Instantiate(foodPrefab, new Vector2(Random.Range(1, 20), Random.Range(1, 20)), Quaternion.identity);
                newFood.GetComponent<SpriteRenderer>().sprite = foodSprites[Random.Range(0, foodSprites.Length)];
            }
        }
    }

    private void SpawnExit()
    {
        // Challenge 2
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < amountOfEnemies; i++)
        {
            Vector2 spawnLocation = new Vector2(Random.Range(0, 19), Random.Range(0, 19));
            GameObject newEnemy = Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
        }
    }
}