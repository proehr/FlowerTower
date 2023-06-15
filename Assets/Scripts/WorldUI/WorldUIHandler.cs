using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Combat;
[DefaultExecutionOrder(-1)]
public class WorldUIHandler : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private UnityEngine.Object TowerUI;
    [SerializeField]
    private UnityEngine.Object EnemyUI;
    [SerializeField]
    private UnityEngine.Object FlowerUI;
    [SerializeField]
    private Dictionary<Combatant,GameObject> enemyUIs;
    [SerializeField]
    private Dictionary<Combatant,GameObject> towerUIs;
    [SerializeField]
    private GameObject flowerUIInstance;
    [SerializeField]
    private Sprite[] rankSprites;
    public static WorldUIHandler instance;
    [SerializeField]
    private Camera referenceCamera;
    private void Awake()
    {
        towerUIs = new Dictionary<Combatant, GameObject>();
        enemyUIs = new Dictionary<Combatant, GameObject>();
        referenceCamera = Camera.main;
        if (instance == null)
        {
            instance = this;
        }       
    }

    public void RegisterEnemy(TowerDefense.Combat.Enemy.Enemy enemy)
    {
        GameObject newUI = (GameObject)Instantiate(EnemyUI, this.transform);
        newUI.GetComponent<EnemyWorldUI>().Initialize(enemy, referenceCamera);
        enemyUIs.Add(enemy,newUI);
    }

    public void RegisterTower(TowerDefense.Combat.Tower.TowerBehaviour tower)
    {
        GameObject newUI = (GameObject)Instantiate(TowerUI, this.transform);
        newUI.GetComponent<TowerWorldUI>().Initialize(tower, referenceCamera);
        towerUIs.Add(tower,newUI);
    }
    public void RegisterFlower(TowerDefense.Combat.FlowerTower flower)
    {
        GameObject newUI = (GameObject)Instantiate(FlowerUI, this.transform);
        newUI.GetComponent<FlowerWorldUI>().Initialize(flower, referenceCamera);
        flowerUIInstance = newUI;
    }

    public void setLevel (TowerDefense.Combat.Tower.TowerBehaviour tower, int levelIndex)
    {
        if (!towerUIs.ContainsKey(tower))
        {
            return;
        }
        towerUIs[tower].GetComponent<TowerWorldUI>().SetRankSprite(rankSprites[levelIndex]);
    }


}
