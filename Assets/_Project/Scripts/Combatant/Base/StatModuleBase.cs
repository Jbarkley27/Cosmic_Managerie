using UnityEngine;

public class StatModuleBase : MonoBehaviour 
{

    [Header("Stat Values")]
    public int health;
    public int currentHealth;
    public int energy;
    public int currentEnergy;

    public int currentSpeed;
    public int speed;

    public int attack;
    public int currentAttack;

    public int defense;
    public int currentDefense;




    public virtual void InitiateStatUI(){}
 

}