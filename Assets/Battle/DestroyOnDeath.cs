using UnityEngine;

namespace CataTombs.Battle
{
    [RequireComponent(typeof(Health))]
    public class DestroyOnDeath : MonoBehaviour
    {
        void Start()
        {
            GetComponent<Health>().OnHealthEmpty.AddListener(() => Destroy(gameObject));
        }
    }
}
