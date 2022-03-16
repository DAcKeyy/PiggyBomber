using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ActorComponents.Base.AI
{
    public class AIVision2D : MonoBehaviour
    {
        public Action<Transform[]> TargetFounded = delegate { };
        public float ViewAngle => _viewAngle;
        public float ViewRadius => _viewRadius;
        public List<Transform> VisableTargets => _visableTargets;
        
        [SerializeField] [Range(0,360)] private float _viewAngle;
        [SerializeField] [Range(.5f,30)] private float _viewRadius;
        [SerializeField] [Range(.01f,1f)] private float _checkUpdateTime = .2f;
        [SerializeField] private LayerMask _targetMask;
        [SerializeField] private LayerMask _obstacleMask;
        [SerializeField] private List<Transform> _visableTargets = new List<Transform>();
        private int _prevAmountTargets;
        
        private void Start()
        {
            StartCoroutine(FindTargetsAfterDelay(_checkUpdateTime));
        }
        
        private IEnumerator FindTargetsAfterDelay(float delay)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                FindVisibleTargets();
            }
        }
        
        void FindVisibleTargets()
        {
            _visableTargets.Clear();
            
            var targetsInView = Physics2D.OverlapCircleAll(transform.position, _viewRadius, _targetMask);
            
            for(int i =0; i < targetsInView.Length; i++)
            {
                Transform target = targetsInView[i].transform;
                Vector2 directionToTarget = (target.position - transform.position).normalized;
                if(Vector2.Angle (transform.up, directionToTarget) < _viewAngle / 2)
                {
                    float distanseToTarget = Vector3.Distance(transform.position, target.position);

                    if(!Physics2D.Raycast(transform.position, directionToTarget, distanseToTarget, _obstacleMask))
                    {
                        _visableTargets.Add(target);
                    }
                }
            }

            if (_prevAmountTargets != _visableTargets.Count)
            {
                _prevAmountTargets = _visableTargets.Count;
                if(_visableTargets.Count != 0) TargetFounded(_visableTargets.ToArray());
                else TargetFounded(null);
            }
        }
        
        public static Transform GetClosestTarget(Transform[] targets, Transform origin)
        {
            if (targets == null) return null;
            
            var minDistanceToTarget = Mathf.Infinity;
            Transform closestTarget = null;
            foreach (var target in targets)
            {
                var distance = Vector2.Distance(target.position, origin.position);
                if (distance < minDistanceToTarget)
                {
                    minDistanceToTarget = distance;
                    closestTarget = target;
                }
            }

            return closestTarget;
        }
        
        public Vector3 DirectoryFromAngle(float angleInDeg, bool isAngleGlobal)
        {
            if(!isAngleGlobal)
            {
                angleInDeg += transform.eulerAngles.y;
            }
            return new Vector3(Mathf.Sin(angleInDeg * Mathf.Deg2Rad), Mathf.Cos(angleInDeg * Mathf.Deg2Rad), 0);
        }
    }
    
    #region Editor
    [CustomEditor(typeof(AIVision2D))]
    public class CharacterVisionEditor : Editor
    {
        private void OnSceneGUI()
        {
            AIVision2D fow = (AIVision2D) target;
            Handles.color = Color.white;
            Handles.DrawWireArc(fow.transform.position, Vector3.back, Vector3.right, 360, fow.ViewRadius);

            if (fow.ViewAngle != 360)
            {
                Vector3 viewAngleA = fow.DirectoryFromAngle(-fow.ViewAngle / 2, false);
                Vector3 viewAngleB = fow.DirectoryFromAngle(fow.ViewAngle / 2, false);

                if (fow.transform != null)
                {
                    var position = fow.transform.position;
                    Handles.DrawLine(position, position + viewAngleA * fow.ViewRadius);
                    Handles.DrawLine(position, position + viewAngleB * fow.ViewRadius);
                }
            }

            Handles.color = Color.red;
            foreach (Transform visableTarget in fow.VisableTargets)
            {
                Handles.DrawLine(fow.transform.position, visableTarget.position);
            }
        }
    }
    #endregion
}