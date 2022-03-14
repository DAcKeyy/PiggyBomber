using UnityEngine;
using UnityEngine.Events;

namespace ActorComponents.Base
{
    public class Creature : MonoBehaviour
    {
        public int Health => _health;
        [SerializeField] private int _health = 1;
        
        public UnityEvent<Creature> Died;
        public UnityEvent<int> Damaged;

        public void GetDamage(int amount)
        {
            _health -= amount;
            Damaged.Invoke(amount);
            if (_health < amount) Die();
        }
        
        private void Die()
        {
            Died.Invoke(this);
        }
    }
}