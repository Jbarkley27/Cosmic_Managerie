using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;

public class PartyManager : MonoBehaviour 
{

    public static PartyManager instance;
    public List<Combatant> partyMembers = new List<Combatant>();
    public TMP_Text focusedCombatantName;

    public Transform combatantParent;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found an Party Manager object, destroying new one");
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        foreach (Transform combatant in combatantParent)
        {
            partyMembers.Add(combatant.GetComponent<Combatant>());
        }
    }


    public void SetFocusedCombatant(Combatant combatant) 
    {
        focusedCombatantName.text = combatant.Name;
    }
}