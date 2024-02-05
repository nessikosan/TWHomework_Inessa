using AbstractEnemyFactory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "EnemyData", menuName = "TD/CreateEnemies")]
public class EnemyFabric : ScriptableObject
{
    public List<WaveInfo> Enemies = new List<WaveInfo>();
    public WaveInfo GetNextWave(int index)
    {
        try
        {
            return Enemies[index];
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            return null;
        }
    }

    public Enemy SpawnEnemy(int index)
    {
        return Instantiate(Enemies[index].Enemy);
    }
   
}

[Serializable]
public class WaveInfo
{
    public Enemy Enemy;
    public float WaveDeley;
    public float EnemyCost;
    public int EnemyCount;
}