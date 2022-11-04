using UnityEngine;

namespace PlateTD.CameraTD
{
    public class CameraMovement
    {
        private Transform _topPoint;
        private Transform _bottomPoint;
        private Camera _camera;
        private float _stepValue;

        public CameraMovement(
            Transform topPoint,
            Transform bottomPoint,
            Camera camera,
            float stepValue = 20)
        {
            _topPoint = topPoint;
            _bottomPoint = bottomPoint;
            _camera = camera;
            _stepValue = stepValue;
        }

        public void MoveCamera(float value)
        {
            if (((_camera.transform.position.y > _topPoint.transform.position.y) && value > 0) ||
                ((_camera.transform.position.y < _bottomPoint.transform.position.y) && value < 0))
            {
                return;
            }
            value = Mathf.Clamp(value, -_stepValue, _stepValue);
            _camera.transform.position += new Vector3(0, value, 0) * Time.deltaTime;
        }
    }
}
