using UnityEngine;
using TMPro;

public class Combatant : CombatantBase 
{
    public StatusEffectModule statusEffectModule;

    private void Awake() {
        statModule = GetComponent<StatModule>();
        statusEffectModule = GetComponent<StatusEffectModule>();
    }

    private void Start() {
        combatantType = CombatantType.Player;
        PartyManager.instance.AddCombatant(this);
    }

}