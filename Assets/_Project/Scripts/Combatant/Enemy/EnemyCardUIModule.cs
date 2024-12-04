using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class EnemyCardUIModule : MonoBehaviour 
{
    public TMP_Text nameText;
    public TMP_Text healthText;
    public TMP_Text attackText;
    public TMP_Text defenseText;
    public TMP_Text speedText;
    public GameObject statusEffectParent;
    public CanvasGroup statCanvasGroup;

    
    private void Start() {
        statCanvasGroup.alpha = 0;
    }

    public void UpdateStatValues(EnemyCombatant combatant)
    {
        nameText.DOText($"{combatant.Name}", 1f, true, ScrambleMode.All, "ASADFJKLLEWOIRUT34234234").SetEase(Ease.InSine);

        healthText.text = combatant.enemyStatModule.currentHealth.ToString() + "/" + combatant.enemyStatModule.health.ToString();

        attackText.text = combatant.enemyStatModule.currentAttack.ToString();
        defenseText.text = combatant.enemyStatModule.currentDefense.ToString();
        speedText.text = combatant.enemyStatModule.currentSpeed.ToString();
    }

    public void UpdateStatusEffects(EnemyCombatant combatant)
    {
        if (!combatant.statusEffectModule.HasStatusEffects())
        {
            combatant.statusEffectModule.DeactivateStatusEffectUI(statusEffectParent);
            return;
        }
    }
}