using UnityEngine;

public class StatModule : StatModuleBase 
{
    public Combatant combatant;
    public CombatantCardUIModule combatantCardUI;

    private void Start() 
    {
        combatant = GetComponent<Combatant>();
        InitiateStatUI();
    }

    public override void InitiateStatUI()
    {
        // player combatant
        GameObject statUI = Instantiate(PartyManager.instance.combatantUIPrefab, PartyManager.instance.combatantParent);

        combatantCardUI = statUI.GetComponent<CombatantCardUIModule>();

        combatantCardUI.gameObject.name = combatant.Name + " Info UI";

        combatantCardUI.UpdateStatValues(combatant);
        combatantCardUI.UpdateStatusEffects(combatant);
    }

}