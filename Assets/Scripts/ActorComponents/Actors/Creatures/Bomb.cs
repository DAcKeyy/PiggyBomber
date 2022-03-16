using System;
using System.Collections;
using ActorComponents.Actors.Triggers;
using Unity.Mathematics;
using UnityEngine;

namespace ActorComponents.Actors.Creatures
{
    public class Bomb : MonoBehaviour// : Weapon
    {
        public float Damage => _damage;
        [SerializeField] private float _damage;
        [SerializeField] private float _explosionDelay;
        [SerializeField] private Explosion _explosionPrefub;

        public void OnEnable()
        {
            StartCoroutine(Exploid());
        }

        private IEnumerator Exploid()
        {
            yield return new WaitForSeconds(_explosionDelay);
            Explosion();
        }

        private void Explosion()
        {
            Destroy(gameObject);
            var explosion = Instantiate(_explosionPrefub, transform.position, quaternion.identity);
            explosion.GetComponent<Explosion>().SetOrigin(this);
        }
    }
}