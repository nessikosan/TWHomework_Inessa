using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractEnemyFactory
{
    public interface IEnemy
    {
        void Configure(EnemyData data);
        void SetDestination(Vector3 position);
        void TakeDamage(float dmg);
        bool IsActive { get; set; }

        Transform EnemyPosition { get; set; }
    }
}