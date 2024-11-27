using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Position currentPosition;
    public GameObject aimObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitiatePosition()
    {
        // Get a random position from the player grid
        int randomIndex = Random.Range(0, GridManager.instance.playerGrid.Count);

        // Get the position object
        Position position = GridManager.instance.playerGrid[randomIndex].GetComponent<Position>();

        // Set the position to occupied
        position.SetOccupied();

        // Set the player object to the position
        transform.position = position.GetPosition();

        // Set the current position
        currentPosition = position;

        SetAimPosition();
    }

    public void SetAimPosition()
    {
        // figure out whice row where on
        int row = currentPosition.y;

        // figure out which column we're on
        int column = currentPosition.x;

        // get the enemy position and set the aim object to that position
        aimObject.transform.position = GridManager.instance.GetEnemyPosition(column, row).gameObject.transform.position;
    }
}
