using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class StatModule : MonoBehaviour 
{
    public int MaxHealth;
    public int CurrentHealth;
    public int MaxAttack;
    public int CurrentAttack;
    public int MaxDefense;
    public int CurrentDefense;
    public int MaxSpeed;
    public int CurrentSpeed;
    public int MaxEnergy;
    public int CurrentEnergy;

    // [Header("Health UI")]
    // public GameObject healthHoverBorder;
    // public TMP_Text currentHealthText;
    // public TMP_Text maxHealthText;
    // public CanvasGroup healthCanvasGroup;

    // [Header("Attack UI")]
    // public GameObject attackHoverBorder;
    // public TMP_Text attackText;
    // public CanvasGroup attackCanvasGroup;

    // [Header("Defense UI")]
    // public GameObject defenseHoverBorder;
    // public TMP_Text defenseText;
    // public CanvasGroup defenseCanvasGroup;

    // [Header("Speed UI")]
    // public GameObject speedHoverBorder;
    // public TMP_Text speedText;
    // public CanvasGroup speedCanvasGroup;

    // [Header("Energy UI")]
    // public CanvasGroup energyCanvasGroup;
    // public List<CanvasGroup> energyIconList;
    // public Transform energyBarParent;

    public Combatant combatant;

    private void Start() {

        combatant = GetComponent<Combatant>();

    }

    public void ResetStatsToMax() {


    }

    public void UpdateEnergy(int amount)
    {
        
    }
}