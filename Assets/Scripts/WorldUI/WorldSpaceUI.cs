using System.Collections;
using System.Collections.Generic;
using TowerDefense.Level;
using UnityEngine;

public abstract class WorldSpaceUI : MonoBehaviour
{
    [SerializeField]
    protected TowerDefense.Combat.Combatant combatant;
    protected Camera referenceCam;
    protected virtual void OnEnable()
    {
        combatant = GetComponent<TowerDefense.Combat.Combatant>();
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        transform.position = RectTransformUtility.WorldToScreenPoint(referenceCam, combatant.transform.position);
        //transform = Camera.main.WorldToViewportPoint(combatant.transform.position);
    }

    public abstract void Initialize(TowerDefense.Combat.Combatant referencePoint, Camera referenceCamera);
}


