using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlayerInput
{
    class FighterInput : MonoBehaviour
    {
        public String PlayerNumber;
        public enum InputMethod { Controller, Other }
        public InputMethod inputMethod;

        private Rigidbody rbody;
        private bool grounded = true, colliding = false;
        
        private void Start()
        {
            rbody = GetComponent<Rigidbody>();
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
            HandleInput();

            if (Input.GetButtonDown($"{PlayerNumber}:A"))
                doPrimaryAttack();
            if (Input.GetButtonDown($"{PlayerNumber}:B"))
                doSecondaryAttack();
        }

        private void OnCollisionEnter(Collision collision)
        {
            colliding = true;
            grounded = false;
            foreach(ContactPoint contact in collision.contacts)
                if(contact.normal.y > 0)
                    grounded = true;
        }

        private void OnCollisionStay(Collision collision)
        {
            colliding = true;
            grounded = false;
            foreach (ContactPoint contact in collision.contacts)
                if (contact.normal.y > 0)
                    grounded = true;
        }

        private void OnCollisionExit(Collision collision)
        {
            colliding = false;
        }

        private void doPrimaryAttack()
        {
            float verticalDirection = Input.GetAxis($"{PlayerNumber}:Vertical");
            if (grounded && verticalDirection > 0)
            {
                Debug.Log("Jump");
                rbody.AddForce(new Vector3(0, verticalDirection * 10, 0), ForceMode.Impulse);
                grounded = false;
            }
        }
        private void doSecondaryAttack()
        {

        }

        private void HandleInput()
        {
            float verticalDirection = Input.GetAxis($"{PlayerNumber}:Vertical");
            float horizontalDirection = Input.GetAxis($"{PlayerNumber}:Horizontal");
            Vector2 movementDirection = new Vector3(verticalDirection, horizontalDirection, 0);

            if(!colliding || grounded)
                rbody.AddForce(new Vector3(horizontalDirection, 0, 0), ForceMode.Impulse);
        }

    }
}
