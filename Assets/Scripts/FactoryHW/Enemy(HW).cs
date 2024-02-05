using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace AbstractEnemyFactory
{
    public abstract class Enemy : MonoBehaviour, IEnemy
    {
        public event Action<float> OnEnemyKilled;

        [SerializeField] protected EnemyData _data;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Transform _moveTarget;
        [SerializeField] private float _health;
        [SerializeField] private Image _healthBar;
        private float _maxHealth;
        public float WaveCost { get; internal set; }
        public bool IsActive { get; set; }
        public Transform EnemyPosition { get; set; }

        private void OnEnable()
        {
            _maxHealth = _health;
            IsActive = true;
        }
        public virtual void Configure(EnemyData data)
        {
            this._data = data;
        }
        public void SetDestination(Vector3 targetPosition)
        {
            _agent.SetDestination(targetPosition);
        }

        public void TakeDamage(float dmg)
        {
            _health -= dmg;

            _healthBar.fillAmount = _health / _maxHealth;

            if (_health <= 0)
            {
                gameObject.SetActive(false);
                OnEnemyKilled?.Invoke(WaveCost);
                IsActive = false;
            }
        }

        private void Update()
        {
            EnemyPosition = transform;
            Vector3 dir = Camera.main.transform.position - _healthBar.GetComponentInParent<Canvas>().transform.position;
            dir.x = 0;
            dir.y = 0;
            dir.z = 0;
            _healthBar.GetComponentInParent<Canvas>().transform.rotation = Quaternion.LookRotation(dir);
        }
    }
}

