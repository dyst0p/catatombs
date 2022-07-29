using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace CataTombs.Movement
{
    public class AvatarInputController : MonoBehaviour
    {
        protected StrafableMover moveProvider;
        [SerializeField] protected Animator rightHand;
        [SerializeField] protected Animator leftHand;

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

        public void GetWalkInput(CallbackContext context) => walkInput = context.ReadValue<float>();
        public void GetTurnInput(CallbackContext context) => turnInput = context.ReadValue<float>();
        public void GetStrafeInput(CallbackContext context) => strafeInput = context.ReadValue<float>();

        public void GetRightPunchInput(CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                rightHand.SetTrigger("Punch");
        }
        
        public void GetLeftPunchInput(CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                leftHand.SetTrigger("Punch");
        }
    }
}