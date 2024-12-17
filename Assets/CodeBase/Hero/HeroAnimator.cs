using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroAnimator : MonoBehaviour
    {
        private static readonly int MoveHash = Animator.StringToHash("Walking");
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController _characterController;
        private readonly float _dampTime = 0.1f;

        private void Update()
        {
            _animator.SetFloat(MoveHash, _characterController.velocity.magnitude, _dampTime, Time.deltaTime);
        }
    }
}