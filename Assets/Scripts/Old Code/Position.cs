using UnityEngine;
using UnityEngine.EventSystems;

public class Position: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public int x;
    public int y;

    public bool isOccupied = false;

    public enum PositionType
    {
        Player,
        Enemy
    }

    public PositionType positionType;



    public void InitiatePosition(int x, int y, Material inactiveColor, PositionType positionType)
    {
        this.x = x;
        this.y = y;

        GetComponent<MeshRenderer>().material = inactiveColor;

        gameObject.layer = LayerMask.NameToLayer("Position");

        this.positionType = positionType;
    }

    public void SetOccupied(bool occupied = true)
    {
        isOccupied = occupied;
        GetComponent<MeshRenderer>().material = isOccupied ? GridManager.instance.activeMat : GridManager.instance.inactiveMat;
    }

    public Vector3 GetPosition()
    {
        return new Vector3(gameObject.transform.position.x,
                            gameObject.transform.position.y + GridManager.instance.combtantHeight,
                             gameObject.transform.position.z);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isOccupied)
        {
            return;
        }
        GetComponent<MeshRenderer>().material = GridManager.instance.hoverMat;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<MeshRenderer>().material = isOccupied ? GridManager.instance.activeMat : GridManager.instance.inactiveMat;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isOccupied || positionType == PositionType.Enemy)
        {
            return;
        }

        SetOccupied();
        Player player = GridManager.instance.player;
        player.currentPosition.SetOccupied(false);
        player.currentPosition = this;
        player.transform.position = GetPosition();
        player.SetAimPosition();
    }

}