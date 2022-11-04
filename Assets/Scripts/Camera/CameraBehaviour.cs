using UnityEngine;

namespace PlateTD.CameraTD
{
    public class CameraBehaviour : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Transform _topPoint;
        [SerializeField] private Transform _bottomPoint;
        [SerializeField] private CameraMovementArea _cameraMovementArea;

        private CameraMovement _cameraMovement;

        private void Awake()
        {
            _cameraMovement = new CameraMovement(_topPoint, _bottomPoint, _mainCamera);
        }

        private void Update()
        {
            if (_cameraMovementArea.IsDrag)
            {
                _cameraMovement.MoveCamera(_cameraMovementArea.Value);
            }
        }
    }
}