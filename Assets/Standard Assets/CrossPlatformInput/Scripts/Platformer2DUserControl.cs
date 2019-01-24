using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;

        //Mobile
        public bool mobileJump;
        public float mobileHorizontal;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        #region MobileInputs

        public void MobileMove(float direction)
        {
            mobileHorizontal = direction;
        }

        public void MobileJump()
        {
            if (!mobileJump)
            {
                // Read the jump input in Update so button presses aren't missed.
                mobileJump =true;
            }
        }



        #endregion

        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Character.Move(mobileHorizontal, crouch, mobileJump);
            m_Jump = false;
            mobileJump = false;
        }
    }
}
