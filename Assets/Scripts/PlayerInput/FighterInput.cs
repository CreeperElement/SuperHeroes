using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlayerInput
{
    class InputCompatability : MonoBehaviour
    {
        public String PlayerNumber;
        public enum InputMethod { Controller, Other }
        public InputMethod inputMethod;
        
        private bool grounded = true, colliding = false;
        private CharacterMoveController characterController;


        private void Start()
        {
            characterController = GetComponent<CharacterMoveController>();
            if (characterController == null)
                gameObject.AddComponent<CharacterMoveController>();
        }

        public void Update()
        {
            switch (inputMethod)
            {
                case InputMethod.Controller:
                    ProcessControllerInput();
                    return;
                default:
                    return;
            }
        }

        private void ProcessControllerInput()
        {
            ProcessDirectionInputs();
            if(characterController.Grounded)
            {
                // Do ground attacks
                if(Input.GetButton($"{PlayerNumber}:A"))
                {
                    // Do aerials
                    if()
                }
            } else
            {
                // Do Aerials
            }
            // Do Ground-Agnostic attacks

        }

        void ProcessDirectionInputs()
        {
            characterController.DirectionalInput = new Vector2(Input.GetAxis($"{PlayerNumber:Horizontal}"), Input.GetAxis($"{PlayerNumber}:Vertical"));
        }

    }
}
