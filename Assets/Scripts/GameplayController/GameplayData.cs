using LevelSelection;
using UnityEngine;

namespace GameplayController
{
    [CreateAssetMenu(fileName = "gameplayData", menuName = "Data/FlowerTower/GameplayData", order = 0)]
    public class GameplayData : ScriptableObject
    {
        [SerializeField] private ResultType resultType;

        public ResultType ResultType
        {
            get => resultType;
            set => resultType = value;
        }
    }
}