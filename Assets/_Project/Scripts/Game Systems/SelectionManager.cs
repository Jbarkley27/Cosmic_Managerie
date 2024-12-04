using UnityEngine;

public class SelectionManager : MonoBehaviour {

    public static SelectionManager instance;
    public LayerMask enemyCombatantLayer;

    public GameObject hoveredCombatant;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found an Selection Manager object, destroying new one");
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        WatchEnemyHover();
    }


    public void WatchEnemyHover()
    {
        // Generate a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, enemyCombatantLayer))
        {

            EnemyCombatant validEnemyCombatant;
            Combatant validPlayerCombatant;

            // // Get the GameObject that the ray hit
            GameObject hoveredObject = hit.collider.gameObject;

            if(hoveredObject.transform.parent.TryGetComponent(out validEnemyCombatant))
            {
                hoveredCombatant = hoveredObject;
            }
            else if (hoveredObject.transform.parent.TryGetComponent(out validPlayerCombatant))
            {
                hoveredCombatant = hoveredObject;
            }
            else
            {
                hoveredCombatant = null;
            }
    
        }
        else
        {
            hoveredCombatant = null;
        }
    }
}