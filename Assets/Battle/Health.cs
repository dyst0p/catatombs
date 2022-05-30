using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CataTombs.Battle
{
    [RequireComponent(typeof(Hitbox))]
    public class Health : MonoBehaviour
    {
        [SerializeField] protected float currentHealth;
        [SerializeField] protected float maxHealth;
        protected bool isFullHealed = true;
        public float health
        {
            get => currentHealth;
            protected set
            {
                currentHealth = Mathf.Clamp(value, 0, maxHealth);
                if (currentHealth == 0)
                    OnHealthEmpty.Invoke();
                else if (currentHealth == maxHealth && !isFullHealed)
                {
                    isFullHealed = true;
                    OnRefullHealth.Invoke();
                }
            }
        }

        public UnityEvent<float> OnTakeDamage;
        public UnityEvent OnRefullHealth;
        public UnityEvent OnHealthEmpty;

        
        public List<Hitbox> hitboxes { get; protected set; }

        private void Awake()
        {
            hitboxes = new List<Hitbox>(GetComponentsInChildren<Hitbox>());
            foreach (Hitbox hitbox in hitboxes)
                hitbox.OnHitStart.AddListener(TakeDamageFromCollider);
        }

        private void TakeDamageFromCollider(Collider collider)
        {
            // TODO: take damage depending on damagebox' settings
            TakeDamage(1);
        }

        private void TakeDamage(float damage)
        {
            print($"{gameObject} take {damage} damage");
            health -= damage;
            OnTakeDamage.Invoke(damage);
        }
    }
}