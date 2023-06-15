using UnityEngine;

namespace DataStructures.RuntimeSets
{
    public abstract class ReactiveRuntimeSetRegistrator<T> : MonoBehaviour
    {
        [SerializeField] private ReactiveRuntimeSet<T> runtimeSet;

        [Header("Registration")]
        [SerializeField] private bool registerOnAwake;
        [SerializeField] private bool registerOnStart;
        [SerializeField] private bool registerOnEnable;
    
        [Header("Removal")]
        [SerializeField] private bool unregisterOnDisable;
        [SerializeField] private bool unregisterOnDestroy;

        private T _topic;

        protected abstract T GetComponent();
    
        private void Awake()
        {
            _topic = GetComponent();
        
            if (registerOnAwake)
            {
                runtimeSet.Add(_topic);
            }
        }

        private void Start()
        {
            if (registerOnStart)
            {
                runtimeSet.Add(_topic);
            }
        }

        private void OnEnable()
        {
            if (registerOnEnable)
            {
                runtimeSet.Add(_topic);
            }
        }

        private void OnDisable()
        {
            if (unregisterOnDisable)
            {
                runtimeSet.Remove(_topic);
            }
        }

        private void OnDestroy()
        {
            if (unregisterOnDestroy)
            {
                runtimeSet.Remove(_topic);
            }
        }
    }
}
