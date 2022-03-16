using System;
using ActorComponents.Base;
using ActorComponents.Base.Units;
using UnityEngine;

namespace ActorComponents.Actors.Creatures
{
    [RequireComponent(typeof(Collider2D), typeof(CreatureHitBox))]
    public class Haystack : Creature
    {
        private CreatureHitBox _hitBox;

        private void Awake()
        {
            _hitBox = GetComponent<CreatureHitBox>();
        }
    }
}