using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class CombatantCardUIModule : MonoBehaviour 
{
    public TMP_Text nameText;
    public TMP_Text healthText;
    public TMP_Text energyText;
    public TMP_Text speedText;
    public TMP_Text attackText;
    public TMP_Text defenseText;


    public GameObject statusEffectParent;

    public void UpdateStatValues(CombatantBase combatant)
    {
        nameText.DOText($"{combatant.Name}", 1f, true, ScrambleMode.All, "ASADFJKLLEWOIRUT34234234").SetEase(Ease.InSine);

        healthText.text = combatant.statModule.currentHealth.ToString() + "/" + combatant.statModule.health.ToString();
        energyText.text = combatant.statModule.currentEnergy.ToString() + "/" + combatant.statModule.energy.ToString();
        speedText.text = combatant.statModule.speed.ToString();
        attackText.text = combatant.statModule.currentAttack.ToString();
        defenseText.text = combatant.statModule.currentDefense.ToString();
    }

    public void UpdateStatusEffects(CombatantBase combatant)
    {
        Combatant combatant1 = combatant.gameObject.GetComponent<Combatant>();

        if (!combatant1.statusEffectModule.HasStatusEffects())
        {
            combatant1.statusEffectModule.DeactivateStatusEffectUI(statusEffectParent);
            return;
        }
    }
}