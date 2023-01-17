using System;
using Asteroids;
using DefaultNamespace.ScriptableEvents;
using RuntimeSets;
using UnityEngine;

namespace Ship
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Laser : MonoBehaviour
    {
        [Header("Project References:")] [SerializeField]
        private LaserRuntimeSet _lasers;

        [Header("Values:")]
        [SerializeField] private float _speed = 0.2f;

        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _lasers.Add(gameObject);
        }

        private void OnDestroy()
        {
            _lasers.Remove(gameObject);
        }

        private void FixedUpdate()
        {
            var trans = transform;
            _rigidbody.MovePosition(trans.position + trans.up * _speed);
        }
    }
}
