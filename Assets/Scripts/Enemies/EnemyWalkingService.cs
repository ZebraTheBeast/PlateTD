using System.Collections.Generic;
using UnityEngine;

namespace PlateTD.Enemies
{
    public class EnemyWalkingService
    {
        private const string AnimatorWalkingParameter = "IsWalking";
        private const string AnimatorSpeedParameter = "Speed";

        private Queue<Transform> _path;
        private Vector3 _destinationPoint;
        private Transform _bodyTransform;
        private Animator _animator;

        public EnemyWalkingService(Transform bodyTransform, Animator animator)
        {
            _bodyTransform = bodyTransform;
            _animator = animator;
        }

        public void SetPath(GameObject pathParent)
        {
            _path = new Queue<Transform>();

            foreach(Transform child in pathParent.transform)
            {
                _path.Enqueue(child);
            }

            SetDestinationPointToNextPathPosition();
        }

        public void GoByPath(float speed, float slow)
        {
            if (Vector3.Distance(_bodyTransform.position, _destinationPoint) < 0.1)
            {
                SetDestinationPointToNextPathPosition();
            }
            else if (_destinationPoint != null)
            {
                _bodyTransform.position = Vector3.MoveTowards(_bodyTransform.position, _destinationPoint, speed * slow);
                _bodyTransform.LookAt(_destinationPoint);
                _animator.SetBool(AnimatorWalkingParameter, true);
            }
            _animator.SetFloat(AnimatorSpeedParameter, slow);
        }

        private void SetDestinationPointToNextPathPosition()
        {
            if (_path.Count > 0)
            {
                var pathPoint = _path.Dequeue();

                if (pathPoint != null)
                {
                    _destinationPoint = pathPoint.transform.position;
                }
            }
            else
            {
                _animator.SetBool(AnimatorWalkingParameter, false);
            }
        }

    }
}