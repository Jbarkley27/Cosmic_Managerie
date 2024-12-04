using System.Collections.Generic;
using UnityEngine;


public class EnemyStatusEffectModule : MonoBehaviour 
{
  public Dictionary<GameObject, GameObject> statusEffectDictionary = new Dictionary<GameObject, GameObject>();


  public bool HasStatusEffects()
  {
    return statusEffectDictionary.Count > 0;
  }

  public void DeactivateStatusEffectUI(GameObject statusEffectParent)
  {
    statusEffectParent.SetActive(false);
  }
}