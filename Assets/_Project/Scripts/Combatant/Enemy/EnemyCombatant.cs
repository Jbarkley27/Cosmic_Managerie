using UnityEngine;
using TMPro;

public class EnemyCombatant : CombatantBase 
{
    public EnemyStatusEffectModule statusEffectModule;

    private void Awake() {
        enemyStatModule = GetComponent<EnemyStatModule>();
        statusEffectModule = GetComponent<EnemyStatusEffectModule>();
    }

    private void Start() {
        combatantType = CombatantType.Enemy;
        EnemyPartyManager.instance.AddCombatant(this);
    }

}