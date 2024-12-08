using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;

        public bool PrimarySkill;
        public bool SecondarySkill;
        public bool UtilitySkill;
        public bool UltimateSkill;

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        public void OnLook(InputValue value)
        {
            LookInput(value.Get<Vector2>());
        }

        public void OnJump(InputValue value)
        {
            JumpInput(value.isPressed);
        }

        public void OnSprint(InputValue value)
        {
            SprintInput(value.isPressed);
        }

        public void OnPrimarySkill(InputValue value)
        {
            PrimarySkillInput(value.isPressed);
        }

        public void OnSecondarySkill(InputValue value)
        {
            SecondarySkillInput(value.isPressed);
        }

        public void OnUtilitySkill(InputValue value)
        {
            UtilitySkillInput(value.isPressed);
        }

        public void OnUltimateSkill(InputValue value)
        {
            UltimateSkillInput(value.isPressed);
        }
#endif

        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }

        public void PrimarySkillInput(bool newPrimarySkillState)
        {
            PrimarySkill = newPrimarySkillState;
        }

        public void SecondarySkillInput(bool newSecondarySkillState)
        {
            SecondarySkill = newSecondarySkillState;
        }

        public void UtilitySkillInput(bool newUtilitySkillState)
        {
            UtilitySkill = newUtilitySkillState;
        }

        public void UltimateSkillInput(bool newUltimateSkillState)
        {
            UltimateSkill = newUltimateSkillState;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}