using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractEnemyFactory
{
   public abstract class EnemyFactory
   {  
      public abstract MrD CreateMrDEnemy();
      public abstract Dron CreateDronEnemy();
      public abstract BigJoe CreateBigJoeEnemy();
   }

    public class EnemyFactory<T> where T : MonoBehaviour, IEnemy
    {
        public T CreateEnemy(EnemyData data)
        {
            GameObject instance = GameObject.Instantiate(data.Prefab);
            T enemy = instance.GetComponent<T>();
            enemy.Configure(data);
            return enemy;
        }
    }
}
