using System.Collections;
using System.Collections.Generic;
using TowerDefense.Combat;
using UnityEngine;
using UnityEngine.UI;

public class TowerWorldUI : WorldSpaceUI
{
    [SerializeField]
    Slider slider;
    [SerializeField]
    TMPro.TMP_Text nameField;
    [SerializeField]
    Image rankIcon;
    TowerDefense.Combat.Tower.TowerBehaviour tower;
    public override void Initialize(Combatant referencePoint, Camera cam)
    {
        referenceCam = cam;
        tower = (TowerDefense.Combat.Tower.TowerBehaviour)referencePoint;
        combatant = referencePoint;
        slider.value = tower.getHealthPercentage();
        nameField.text = tower.getName();
        base.FixedUpdate();
    }

    protected override void FixedUpdate()
    {
        if (!tower)
        {
            gameObject.SetActive(false);
            return;
        }
        base.FixedUpdate();
       slider.value = tower.getHealthPercentage();
    }

    public void SetRankSprite(Sprite newSprite)
    {
        if (newSprite == null)
        {
            return;
        }
        rankIcon.sprite = newSprite;
    }


}
