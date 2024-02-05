using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractEnemyFactory
{
   public class WaveManager : MonoBehaviour
   {
        [SerializeField] private List<WaveSettings> waveSettings = new List<WaveSettings>();
        private List<IEnemy> enemies = new List<IEnemy>();   
        [SerializeField] private Transform _destinationTarget;
        [SerializeField] private GameMenager _gameMenager;
        private int WaveIndex;
        private EnemyManager enemyManager;

        private void Start()
        {
            enemyManager = GetComponent<EnemyManager>();
        }
        private void OnEnable()
        {
            _gameMenager.OnGameStart += OnGameStart;
           
        }
        private void OnDisable()
        {
            _gameMenager.OnGameStart -= OnGameStart;
           
        }
        private void OnGameStart()
        {
            CreateWave(waveSettings[WaveIndex]);
            
        }
    
        public void CreateWave(List<WaveSettings> waveSettings)
        {
            foreach (WaveSettings data in waveSettings)
            {
                for (int i = 0; i < data.EnemyCount; i++)
                {
                    IEnemy enemy = CreateEnemy(data.EnemyData);
                    enemy.SetDestination(_destinationTarget.position);
                    //enemies.Add(enemy);
                    enemyManager.EnemyList.Add(enemy);
                }

                Debug.Log(data.EnemyCount == enemies.Count);

                if (data.EnemyCount == enemies.Count)
                {
                    WaveIndex++;
                }
            }

           
        }

        public void CreateWave(WaveSettings waveSettings)
        {
            for (int i = 0; i < waveSettings.EnemyCount; i++)
            {
                IEnemy enemy = CreateEnemy(waveSettings.EnemyData);
                enemy.SetDestination(_destinationTarget.position);
                enemies.Add(enemy);
            }
        }

        private IEnemy CreateEnemy(EnemyData data)
        {
            switch (data.Type)
            {
                case EnemyType.MrD:
                    EnemyFactory<MrD> MrDFactory = new EnemyFactory<MrD>();
                    return MrDFactory.CreateEnemy(data);
                case EnemyType.DronRed:
                    EnemyFactory<DronRed> DronRedFactory = new EnemyFactory<DronRed>();
                    return DronRedFactory.CreateEnemy(data);
                case EnemyType.BigJoe:
                    EnemyFactory<BigJoe> BigJoeFactory = new EnemyFactory<BigJoe>();
                    return BigJoeFactory.CreateEnemy(data);
                case EnemyType.MrDSilver:
                    EnemyFactory<MrDSilver> MrDSilverFactory = new EnemyFactory<MrDSilver>();
                    return MrDSilverFactory.CreateEnemy(data);
                case EnemyType.DronSilver:
                    EnemyFactory<DronSilver> DronSilverFactory = new EnemyFactory<DronSilver>();
                    return DronSilverFactory.CreateEnemy(data);
                case EnemyType.BigJoeSilver:
                    EnemyFactory<BigJoeSilver> BigJoeSilverFactory = new EnemyFactory<BigJoeSilver>();
                    return BigJoeSilverFactory.CreateEnemy(data);

                default:
                    return null;
            }
        }
   }
    [Serializable]

    public class WaveSettings
    {
        public EnemyData EnemyData;
        public int EnemyCount;
        public int WaveIndex;
        public float WaveDelay;
        public float EnemyCost;   
    }
   
}

  