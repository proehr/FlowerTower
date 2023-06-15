using System.Collections;
using System.Collections.Generic;
using TowerDefense.Combat;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWorldUI : WorldSpaceUI
{
    [SerializeField]
    Slider slider;
    TowerDefense.Combat.Enemy.Enemy enemy;
    public override void Initialize(Combatant referencePoint, Camera cam)
    {
        referenceCam = cam;
        enemy = (TowerDefense.Combat.Enemy.Enemy)referencePoint;
        slider.value = enemy.getHealthPercentage();
        combatant = referencePoint;
        base.FixedUpdate();
    }

    protected override void FixedUpdate()
    {
        if (!enemy)
        {
            gameObject.SetActive(false);
            return;
        }
        base.FixedUpdate();
        slider.value = enemy.getHealthPercentage();
    }
}
