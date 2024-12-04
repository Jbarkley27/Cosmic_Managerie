using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;

public class EnemyPartyManager : MonoBehaviour 
{

    public static EnemyPartyManager instance;
    public List<EnemyCombatant> enemyCombatants = new List<EnemyCombatant>();

    [Header("Combatant Global Values")]
    public GameObject enemyCombatantUIPrefab;



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found an Enemy Party Manager object, destroying new one");
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddCombatant(EnemyCombatant combatant)
    {
        enemyCombatants.Add(combatant);
    }
}