using System;
using System.Collections.Generic;
using Core.Extensions;
using DataStructures.Events;
using DataStructures.ReactiveVariable;
using UniRx;
using UnityEngine;

namespace TowerDefense.Level
{
	/// <summary>
	/// WaveManager - handles wave initialisation and completion
	/// </summary>
	public class WaveManager : MonoBehaviour
	{
		/// <summary>
		/// Current wave being used
		/// </summary>
		protected ReactiveProperty<int> m_CurrentIndex;

		/// <summary>
		/// Whether the WaveManager starts waves on Awake - defaulted to null since the LevelManager should call this function
		/// </summary>
		public bool startWavesOnAwake;

		/// <summary>
		/// The waves to run in order
		/// </summary>
		[Tooltip("Specify this list in order")]
		public List<Wave> waves = new List<Wave>();

		[SerializeField] private GameEvent onFinalEnemyDeath;
		[SerializeField] private IntReactiveVariable currentStage;
		[SerializeField] private IntReactiveVariable totalStages;

		/// <summary>
		/// The current wave number
		/// </summary>
		public int waveNumber
		{
			get { return m_CurrentIndex.Value + 1; }
		}

		/// <summary>
		/// The total number of waves
		/// </summary>
		public int totalWaves
		{
			get { return waves.Count; }
		}

		public float waveProgress
		{
			get
			{
				if (waves == null || waves.Count <= m_CurrentIndex.Value)
				{
					return 0;
				}
				return waves[m_CurrentIndex.Value].progress;
			}
		}

		/// <summary>
		/// Called when a wave begins
		/// </summary>
		public event Action waveChanged;

		/// <summary>
		/// Called when all waves are finished
		/// </summary>
		public event Action spawningCompleted;

		/// <summary>
		/// Starts the waves
		/// </summary>
		public virtual void StartWaves()
		{
			if (waves.Count > 0)
			{
				InitCurrentWave();
			}
			else
			{
				Debug.LogWarning("[LEVEL] No Waves on wave manager. Calling spawningCompleted");
				SafelyCallSpawningCompleted();
			}
		}

		/// <summary>
		/// Inits the first wave
		/// </summary>
		protected virtual void Awake()
		{
			m_CurrentIndex = new ReactiveProperty<int>();
			currentStage.SetProperty(m_CurrentIndex);
			waves.ObserveEveryValueChanged(x => x.Count).Subscribe(x => totalStages.Set(waves.Count));
			
			if (startWavesOnAwake)
			{
				StartWaves();
			}
		}

		/// <summary>
		/// Sets up the next wave
		/// </summary>
		protected virtual void NextWave()
		{
			waves[m_CurrentIndex.Value].onWaveCompleted -= NextWave;
			if (waves.Next(m_CurrentIndex))
			{
				//m_CurrentIndex.Value = m_CurrentIndex.Value + 1;
				InitCurrentWave();
			}
			else
			{
				SafelyCallSpawningCompleted();
				waves[^1].allWaveEnemiesDead += onFinalEnemyDeath.Raise;
			}
		}

		/// <summary>
		/// Initialize the current wave
		/// </summary>
		protected virtual void InitCurrentWave()
		{
			Wave wave = waves[m_CurrentIndex.Value];
			wave.allWaveEnemiesDead += NextWave;
			wave.Init();
			if (waveChanged != null)
			{
				waveChanged();
			}
		}

		/// <summary>
		/// Calls spawningCompleted event
		/// </summary>
		protected virtual void SafelyCallSpawningCompleted()
		{
			if (spawningCompleted != null)
			{
				spawningCompleted();
			}
		}
	}
}