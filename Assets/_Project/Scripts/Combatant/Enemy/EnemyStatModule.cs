using UnityEngine;

public class EnemyStatModule : StatModuleBase 
{

    public Transform uiParent;
    public EnemyCardUIModule combatantCardUI;
    private EnemyCombatant combatant;

    private void Start() 
    {
        combatant = GetComponent<EnemyCombatant>();
        InitiateStatUI();
    }

    public override void InitiateStatUI()
    {
        combatantCardUI = Instantiate(EnemyPartyManager.instance.enemyCombatantUIPrefab, uiParent).GetComponent<EnemyCardUIModule>();

        combatantCardUI.UpdateStatValues(combatant);
        combatantCardUI.UpdateStatusEffects(combatant);

        combatantCardUI.gameObject.name = combatant.Name == "" ? "Enemy" : combatant.Name + " Info UI";
    }

}