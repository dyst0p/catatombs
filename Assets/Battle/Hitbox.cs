using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CataTombs.Battle
{
    public class Hitbox : MonoBehaviour
    {
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