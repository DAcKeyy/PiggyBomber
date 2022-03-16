using System.Collections;
using ActorComponents.Actors.Creatures;
using ActorComponents.Base;
using UnityEngine;

namespace ActorComponents.Actors.Triggers
{
    [RequireComponent(typeof(Collider2D),typeof(Animator))]
    public class Explosion : MonoBehaviour
    {
        public float Damage => _bomb.Damage;
        
        private Collider2D _collider2D;
        private Animator _animator;
        //private IExplode explodeable;
        private Bomb _bomb;
        
        public void SetOrigin(Bomb bomb)
        {
            _bomb = bomb;
        }
        
        private void OnEnable()
        {
            _animator = GetComponent<Animator>();
            _collider2D = GetComponent<Collider2D>();
            _collider2D.isTrigger = true;

            StartCoroutine(Explode());
        }

        private IEnumerator Explode()
        {
            yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
            Destroy(gameObject);
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out IWeaponVisitor weaponVisitor))
            {
                Debug.Log(weaponVisitor);
                weaponVisitor?.Visit(this);
            }
        }
    }
}