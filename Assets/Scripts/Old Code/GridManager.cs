using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridManager : MonoBehaviour
{

    public List<GameObject> playerGrid = new List<GameObject>();
    public List<GameObject> enemyGrid = new List<GameObject>();

    // 2d grid
    private GameObject[,] playerGrid2D = new GameObject[4, 4];
    private GameObject[,] enemyGrid2D = new GameObject[4, 4];

    public Transform playerGridParent;
    public Transform enemyGridParent;

    // colors
    public Material inactiveMat;
    public Material activeMat;

    public static GridManager instance;

    public Material hoverMat;

    public int combtantHeight = 10;

    public Player player;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found an Grid Manager object, destroying new one.");
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Position GetEnemyPosition(int x, int y)
    {
        return enemyGrid2D[x, y].GetComponent<Position>();
    }

    public void CreateGrid()
    {
        // loop through each parent, there are 4 children in each parent, and they all have 4 children, this makes up the 4x4 grid
        for (int i = 0; i < playerGridParent.childCount; i++)
        {
            for (int j = 0; j < playerGridParent.GetChild(i).childCount; j++)
            {
                // add to the player grid and list
                playerGrid2D[i, j] = playerGridParent.GetChild(i).GetChild(j).gameObject;
                playerGrid.Add(playerGrid2D[i, j]);

                // add to the enemy grid and list
                enemyGrid2D[i, j] = enemyGridParent.GetChild(i).GetChild(j).gameObject;
                enemyGrid.Add(enemyGrid2D[i, j]);


                playerGrid2D[i, j].AddComponent<Position>().InitiatePosition(i, j, inactiveMat, Position.PositionType.Player);

                enemyGrid2D[i, j].AddComponent<Position>().InitiatePosition(i, j, inactiveMat, Position.PositionType.Enemy);
            }
        }

        // initiate the player
        player.InitiatePosition();
        StartCoroutine(EnemyManager.instance.StartSpawning());
    }
}
