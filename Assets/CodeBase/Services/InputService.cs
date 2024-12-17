using UnityEngine;

namespace CodeBase.Services
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        protected const string Fire = "Fire";

        public abstract Vector2 Axis { get; }

        public abstract bool IsAttackButtonUp();
    }
}

