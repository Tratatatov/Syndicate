using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(CharacterController))]
    public class HeroMove : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float _moveSpeed;
        private Camera _camera;
        private CharacterController _charecterController;

        private IInputService _input;

        private void Awake()
        {
            _input = AllServices.Container.Single<IInputService>();
            _camera = Camera.main;
            _charecterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            var moveDirection = Vector3.zero;

            if (_input.Axis.sqrMagnitude > Constants.Epsilon)
            {
                moveDirection = _camera.transform.TransformDirection(_input.Axis);
                moveDirection.y = 0;
                moveDirection.Normalize();

                transform.forward = moveDirection;
            }

            moveDirection += Physics.gravity;

            _controller.Move(moveDirection * _moveSpeed * Time.deltaTime);
        }

        public void LoadProgress(PlayerProgress progress)
        {
            if (CurrentLevel() == progress.WorldData.PositiononLevel.LevelName)
            {
                var savedPosition = progress.WorldData.PositiononLevel.Position;
                if (savedPosition != null)
                    Warp(savedPosition);
            }
        }

        public void SaveProgress(PlayerProgress progress)
        {
            progress.WorldData.PositiononLevel = new PositionOnLevel(CurrentLevel(), transform.position.AsVectorData());
        }

        private void Warp(Vector3Data savedPosition)
        {
            _charecterController.enabled = false;
            transform.position = savedPosition.AsUnityVector();
            _charecterController.enabled = true;
        }

        private string CurrentLevel()
        {
            return SceneManager.GetActiveScene().name;
        }
    }
}