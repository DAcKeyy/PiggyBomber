using UnityEngine;
using UnityEngine.Events;

namespace ActorComponents.Base
{
    [RequireComponent(typeof(Collider2D))]
    public class Creature : MonoBehaviour
    {
        public int Health => _health;
        
        [SerializeField] private int _health = 1;
        [SerializeField] private UnityEvent<Creature> Died;
        [SerializeField] private UnityEvent<int> Damaged;

        public void GetDamage(int amount)
        {
            _health -= amount;
            Damaged.Invoke(amount);
            if (_health <= 0) Die();
        }
        
        private void Die()
        {
            Died.Invoke(this);
            Destroy(gameObject);
        }
    }
}