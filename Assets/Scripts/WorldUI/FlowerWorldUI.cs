using System.Collections;
using System.Collections.Generic;
using TowerDefense.Combat;
using UnityEngine;
using UnityEngine.UI;

public class FlowerWorldUI : WorldSpaceUI
{
    [SerializeField]
    Slider slider;
    FlowerTower flower;
    public override void Initialize(Combatant referencePoint, Camera referenceCamera)
    {
        referenceCam = referenceCamera;
        combatant = referencePoint;
        flower = (FlowerTower)referencePoint;
        base.FixedUpdate();
    }

    protected override void FixedUpdate()
    {
        if (!flower)
        {
            return;
        }
        base.FixedUpdate();
        slider.value = flower.getHealthPercentage();
    }
}
