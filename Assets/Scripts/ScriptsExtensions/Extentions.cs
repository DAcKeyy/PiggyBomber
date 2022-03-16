using UnityEngine;
using UnityEngine.EventSystems;

namespace ScriptsExtensions
{
    public static class Extensions
    {
        public static bool IsPlaying(this Animator animator)
        {
            return animator.GetCurrentAnimatorStateInfo(0).length >
                   animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        }
        
        public static MoveDirection Vector2ToMoveDirection(this Vector2 vector2)
        {
            if (vector2.x > 0)
            {
                if (vector2.x > Mathf.Abs(vector2.y)) return MoveDirection.Right;
            }
            
            if (vector2.x < 0)
            {
                if (Mathf.Abs(vector2.x) > Mathf.Abs(vector2.y)) return MoveDirection.Left;
            }

            if (vector2.y > 0)
            {
                return MoveDirection.Up;
            }
            
            if(vector2.y < 0)
            {
                return MoveDirection.Down;
            }

            return MoveDirection.None;
        }
    }
}