using UnityEngine;
using TMPro;
using DG.Tweening;

public class Combatant : MonoBehaviour 
{
    public string Name;

    [TextArea(3, 10)]
    public string Description;
    public VesselFrameType Type;
    public TMP_Text NameText;

    [HideInInspector]
    public StatModule Stats;

    public enum VesselFrameType
    {
        BURST,
        CELEST,
        AEGIS,
        ENEMY
    }

    private void Start() {
        // Stats = GetComponent<StatModule>();
        NameText.text = Name;
    }

}