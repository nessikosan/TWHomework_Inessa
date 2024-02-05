using AbstractEnemyFactory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public event Action OnStartNewWawe;
  
    public static EnemyManager Instance;

    [SerializeField] private GameMenager _gameMenager;
    [SerializeField] private EnemyFabric _fabric;
    [SerializeField] private int _waveIndex;
    [SerializeField] private Transform _destinationTarget;

    [SerializeField] private bool _started = false;

    public List<IEnemy> EnemyList = new List<IEnemy>();
   

    public int Wawe { get { return _waveIndex; } set { _waveIndex = value; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        //_gameMenager.OnGameStart += OnGameStart;
       // OnStartNewWawe += EnemyManagerOnStartNewWawe;
    }

    private void OnDisable()
    {
       // _gameMenager.OnGameStart -= OnGameStart;
       // OnStartNewWawe -= EnemyManagerOnStartNewWawe;
    }

    private void OnGameStart()
    {
        StartCoroutine(CreateWawe(_fabric.GetNextWave(0).WaveDeley));
    }

    private void EnemyManagerOnStartNewWawe()
    {
        _started = true;
        StartCoroutine(CreateWawe(_fabric.GetNextWave(_waveIndex).WaveDeley));
    }

    //private void Update()
    //{
    //  if (EnemyList.Count > 0 && EnemyList.All(x => x.gameObject.activeSelf == false) && !_started)
    //    {
    //       OnStartNewWawe?.Invoke();
    //    }
    //}

    public IEnumerator CreateWawe(float waweDelay = 0)
    {
        _waveIndex++;
  
        yield return new WaitForSeconds(waweDelay);

        if (EnemyList.Count > 0)
        {
            foreach (Enemy enemy in EnemyList)
            {
                Destroy(enemy.gameObject);
            }
        }

        EnemyList = new List<IEnemy>();
        var wave = _fabric.GetNextWave(_waveIndex);

        for (int i = 0; i < wave.EnemyCount; i++)
        {
            var enemy = Instantiate(wave.Enemy);
            enemy.WaveCost = wave.EnemyCost;
            enemy.SetDestination(_destinationTarget.position);
            enemy.OnEnemyKilled += OnEnemyKilled;
            EnemyList.Add(enemy);
            yield return new WaitForSeconds(2f);
        }

        _started = false;
    }

    public void OnEnemyKilled(float money)
    {
        _gameMenager.PlayerMoney += money;
        _gameMenager.UpdatePlayerMoney();    
    }
}