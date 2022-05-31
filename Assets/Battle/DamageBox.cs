using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CataTombs.Battle
{
    public class DamageBox : MonoBehaviour
    {
        [SerializeField] protected float baseDamage;
        public float damage
        {
            get => baseDamage;
            protected set => baseDamage = value;
        }

        public List<Collider> colliders { get; protected set; }

        public UnityEvent<Collider> OnHitStart;
        public UnityEvent<Collider> OnHitEnd;

        void Awake()
        {
            colliders = new List<Collider>(GetComponents<Collider>());
        }

        private void OnTriggerEnter(Collider other)
        {
            OnHitStart.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnHitEnd.Invoke(other);
        }
    }
}