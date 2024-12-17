using UnityEngine;

namespace CodeBase.Services
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 Axis => new Vector2(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));

        public override bool IsAttackButtonUp() => Input.GetButtonDown(Fire);

    }
}
