using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractEnemyFactory
{
    public class SilverEnemyFactory : EnemyFactory
    {
        public override BigJoe CreateBigJoeEnemy()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/BigJoeSilver");
            var go = GameObject.Instantiate(prefab);
            var BigJoe = go.GetComponent<BigJoe>();
            return BigJoe;
        }

        public override Dron CreateDronEnemy()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/DronSilver");
            var go = GameObject.Instantiate(prefab);
            var Dron = go.GetComponent<Dron>();
            return Dron;
        }

        public override MrD CreateMrDEnemy()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/MrDSilver");
            var go = GameObject.Instantiate(prefab);
            var MrD = go.GetComponent<MrD>();
            return MrD;
        }
    }
}

