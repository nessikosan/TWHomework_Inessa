using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AbstractEnemyFactory
{
   public enum EnemyType
   {
        MrD,
        MrDSilver,
        DronRed,
        DronSilver,
        BigJoe,
        BigJoeSilver
   }
[CreateAssetMenu(fileName = "Enemy", menuName = "TD/EnemyData")]
   public class EnemyData : ScriptableObject
   {
       public GameObject Prefab;
       public EnemyType Type;     
       public float Health; 
   }
}
