using UnityEngine;
namespace CodeBase.Services
{
    public class MobileInputService : InputService
    {
        public override Vector2 Axis => new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));

        public override bool IsAttackButtonUp()=>SimpleInput.GetButtonUp(Fire);
    }
}