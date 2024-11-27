using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefabOne;
    public GameObject enemyPrefabTwo;
    public int spawnHeight;
    public float spawnRate;

    public enum EnemyType
    {
        ONE,
        TWO
    }

    public List<EnemyType> enemyTypes = new List<EnemyType>();

    public static EnemyManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found an Enemy Manager object, destroying new one.");
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator StartSpawning()
    {
        foreach (EnemyType enemyType in enemyTypes)
        {
            SpawnEnemy(enemyType);
            yield return new WaitForSeconds(spawnRate);
        }
    }

    public GameObject GetEnemyPrefab(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.ONE:
                return enemyPrefabOne;
            case EnemyType.TWO:
                return enemyPrefabTwo;
            default:
                return enemyPrefabOne;
        }
    }

    public void SpawnEnemy(EnemyType enemyType)
    {

        GameObject enemyPrefab = GetEnemyPrefab(enemyType);

        // Get a random position from the enemy grid
        int randomIndex = Random.Range(0, GridManager.instance.enemyGrid.Count);

        // Get an open position object from the enemy grid and make sure it's not occupied
        Position position = GridManager.instance.enemyGrid[randomIndex].GetComponent<Position>();

        while (position.isOccupied)
        {
            randomIndex = Random.Range(0, GridManager.instance.enemyGrid.Count);
            position = GridManager.instance.enemyGrid[randomIndex].GetComponent<Position>();
        }
        

        Vector3 targetPos = position.GetPosition();
        targetPos.y += spawnHeight;

        // Instantiate the enemy object
        GameObject enemy = Instantiate(enemyPrefab, targetPos, Quaternion.identity);

        targetPos.y -= spawnHeight;
        enemy.transform.DOMove(targetPos, 1f)
            .SetEase(Ease.InBounce)
            .OnComplete(() =>
            {
                        // Set the position to occupied
                        position.SetOccupied();
            });
    }
}
