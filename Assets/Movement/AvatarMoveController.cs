using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace CataTombs.Movement
{
    public class AvatarMoveController : MonoBehaviour
    {
        protected StrafableMover moveProvider;

        protected float walkInput;
        protected float turnInput;
        protected float strafeInput;

        private void Awake()
        {
            moveProvider = GetComponent<StrafableMover>();
        }

        protected void Update()
        {
            if (walkInput > 0)
                moveProvider.GoForward();
            if (walkInput < 0)
                moveProvider.GoBackward();
            if (turnInput < 0)
                moveProvider.TurnLeft();
            if (turnInput > 0)
                moveProvider.TurnRight();
            if (strafeInput < 0)
                moveProvider.StrafeLeft();
            if (strafeInput > 0)
                moveProvider.StrafeRight();
        }

        public void GetWalkInput(CallbackContext value) => walkInput = value.ReadValue<float>();
        public void GetTurnInput(CallbackContext value) => turnInput = value.ReadValue<float>();
        public void GetStrafeInput(CallbackContext value) => strafeInput = value.ReadValue<float>();
    }
}