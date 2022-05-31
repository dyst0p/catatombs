using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CataTombs.Battle
{
    public class BlockBox : MonoBehaviour
    {
        public List<Collider> colliders { get; protected set; }

        public UnityEvent<Collider> OnBlockStart;
        public UnityEvent<Collider> OnBlockEnd;

        void Awake()
        {
            colliders = new List<Collider>(GetComponents<Collider>());
        }

        private void OnTriggerEnter(Collider other)
        {
            OnBlockStart.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnBlockEnd.Invoke(other);
        }
    }
}