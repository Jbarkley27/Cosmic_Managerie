using UnityEngine;
using UnityEngine.UI;

public class CombatantBase : MonoBehaviour {

    public string Name;
    public StatModule statModule;
    public EnemyStatModule enemyStatModule;

    public CombatantType combatantType;
    public Sprite icon;

     
    public enum CombatantType
    {
        Player,
        Enemy
    }
    

    public int GetSpeed()
    {
        return combatantType == CombatantType.Player ? statModule.currentSpeed : enemyStatModule.currentSpeed;
    }

    
    




}