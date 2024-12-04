using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour {
    
    public static RoundManager instance;
    public List<GameObject> combatants = new List<GameObject>();

    private void Awake()
    {
        // if there is already an instance of this object
        if (instance != null)
        {
            // log an error message
            Debug.LogError("Found an Round Manager object, destroying new one");
            // destroy the new object
            Destroy(gameObject);
            // return from this method
            return;
        }
        // set the instance to this object
        instance = this;
        // don't destroy this object when loading a new scene
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        // invoke the get all combatants on field method to fire after 3 seconds
        Invoke("GetAllCombatantsOnField", 3f);
    }

    public void GetAllCombatantsOnField()
    {
        // get all combatants on the field
        combatants.Clear();

        // get all combatants on the field from the party manager
        foreach (var combatant in PartyManager.instance.partyMembers)
        {
            combatants.Add(combatant.gameObject);
        }

        // get all combatants on the field from the enemy party manager
        foreach (var combatant in EnemyPartyManager.instance.enemyCombatants)
        {
            combatants.Add(combatant.gameObject);
        }

        // sort the combatants by speed
        SortCombatantsBySpeed(combatants);






        // // create dictionary
        // Dictionary<int, GameObject> combatantSpeeds = new Dictionary<int, GameObject>();


        // // get all combatants on the field from the enemy party manager and sort them by speed, if they are the same speed, combatants go first then enemies
        
        // foreach (var combatant in PartyManager.instance.partyMembers)
        // {
        //     combatantSpeeds.Add(combatant.GetSpeed(), combatant.gameObject);
        // }

        // foreach (var combatant in EnemyPartyManager.instance.enemyCombatants)
        // {
        //     combatantSpeeds.Add(combatant.GetSpeed(), combatant.gameObject);
        // }

        // // sort the dictionary by key - this sorts by speed in ascending order
        // // lowest speed is first
        // SortedDictionary<int, GameObject> sortedCombatantSpeeds = new SortedDictionary<int, GameObject>(combatantSpeeds);


        // // add the sorted combatants to the combatants list in reverse order
        // foreach (var combatant in sortedCombatantSpeeds)
        // {
        //     combatants.Insert(0, combatant.Value);
        // }
        
        

    }

    public void SortCombatantsBySpeed(List<GameObject> combatants)
    {
        // sort the combatants by speed
        // combatants.Sort((x, y) => x.GetComponent<CombatantBase>().GetSpeed().CompareTo(y.GetComponent<CombatantBase>().GetSpeed()));

        combatants.Sort((a, b) =>
        {
            float speedA = a.GetComponent<CombatantBase>().GetSpeed();
            float speedB = b.GetComponent<CombatantBase>().GetSpeed();
            return speedB.CompareTo(speedA); // Ascending order
        });
    }

}