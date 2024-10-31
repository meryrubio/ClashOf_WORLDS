using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class Player_movement : MonoBehaviour
    {
        public float walkingSpeed, mouseSens, gravityScale, jumpForce, runningSpeed, acceleration;
        private float yvelocity = 0, currentSpeed;
        private CharacterController characterController;
        // Start is called before the first frame update
        void Start()
        {
            characterController = GetComponent<CharacterController>();
            gravityScale = Mathf.Abs(gravityScale);
        }

        // Update is called once per frame
        void Update()
        {
            if (characterController.isGrounded)
            {

                yvelocity = 0;

            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            float mouseX = Input.GetAxis("Mouse X");
            bool jumpPressed = Input.GetKeyDown(KeyCode.Space);
            bool shiftPressed = Input.GetKey(KeyCode.LeftShift);


            // salto
            Jump(jumpPressed);
            InterpolateSpeed(shiftPressed, x, z);
            Movement(x, z, shiftPressed);
            Rotation(mouseX);
        }
        private void FixedUpdate()
        {

        }
        void Rotation(float mouseX) // para juegos en tercera persona
        {

            //rotation
            Vector3 rotation = new Vector3(0, mouseX, 0) * mouseSens * Time.deltaTime; // PARA HACER UNA ROTACION AUTOMATICA QUITO EL MOUSEX Y LE DOY UNA VARIABLES, TAMBIEN QUITO EL MOUSESENSE
            transform.Rotate(rotation);
        }
        void Jump(bool jumpPressed)
        {
            if (jumpPressed && characterController.isGrounded)
            {
                yvelocity += jumpForce;
            }
        }

        void Movement(float x, float z, bool shiftPressed)
        {
            Vector3 movementVector = transform.forward * currentSpeed * z + transform.right * currentSpeed * x;
            yvelocity -= gravityScale;
            movementVector.y = yvelocity;

            movementVector *= Time.deltaTime; // para que se mueva igual en diferentes pc 


            characterController.Move(movementVector);// el metodo que tiene el character controller para mover el objeto 

        }
        public float GetCurrentSpeed()
        {
            return currentSpeed;
        }
        void InterpolateSpeed(bool shiftPressed, float x, float z)
        {
            if (shiftPressed && (x != 0 || z != 0))
            {
                currentSpeed = Mathf.Lerp(currentSpeed, runningSpeed, acceleration * Time.deltaTime);
            }
            else if (x != 0 || z != 0)
            {
                currentSpeed = Mathf.Lerp(currentSpeed, walkingSpeed, acceleration * Time.deltaTime);
            }
            else
            {
                currentSpeed = Mathf.Lerp(currentSpeed, 0, acceleration * Time.deltaTime);
            }
        }
    }

