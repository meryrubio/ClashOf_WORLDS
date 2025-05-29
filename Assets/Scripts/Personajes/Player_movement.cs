using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



    public class Player_movement : MonoBehaviour
    {
        public float walkingSpeed, mouseSens, gravityScale, jumpForce, runningSpeed, acceleration;
        private float yvelocity = 0, currentSpeed;
        private CharacterController characterController;

        // Variables de entrada
        private InputActionAsset inputAsset;
        private InputActionMap player;
        private InputAction moveAction;
        private InputAction jumpAction;
        private InputAction joinAction;
        private Vector2 moveInput;

    public Characters characterType;
    public Canvas myCanvas;


    public GameObject playerPrefab;

    // Start is called before the first frame update

        void Awake()
        {
            characterController = GetComponent<CharacterController>();
            gravityScale = Mathf.Abs(gravityScale);

            // Inicializar el sistema de entrada
            inputAsset = GetComponent<PlayerInput>().actions;
            player = inputAsset.FindActionMap("Player");
        moveAction = player.FindAction("Move");
        jumpAction = player.FindAction("Jump");
        joinAction = player.FindAction("Join");
         
        }   

        void Start()
        {
        // Asignar el canvas a la cámara del jugador
            if (myCanvas != null)
            {
                myCanvas.worldCamera = GetComponentInChildren<Camera>();
            }
        //characterController = GetComponent<CharacterController>();
        //gravityScale = Mathf.Abs(gravityScale);

    }


        private void OnEnable()
        {
            moveAction.Enable();
            jumpAction.Enable();
        }

        private void OnDisable()
        {
            moveAction.Disable();
            jumpAction.Disable();
        }

        // Update is called once per frame

        void Update()
        {
            if (characterController.isGrounded)
            {

                yvelocity = 0;

            }

            // Leer la entrada de movimiento
            moveInput = moveAction.ReadValue<Vector2>();
            bool jumpPressed = jumpAction.triggered; // Verificar si se ha presionado el salto
            bool joinpressed = joinAction.triggered;
            bool shiftPressed = Keyboard.current.leftShiftKey.isPressed;

            //float x = Input.GetAxis("Horizontal");
            //float z = Input.GetAxis("Vertical");
            //float mouseX = Input.GetAxis("Mouse X");
            //bool jumpPressed = Input.GetKeyDown(KeyCode.Space);
            //bool shiftPressed = Input.GetKey(KeyCode.LeftShift);

            // Salto
            if (jumpPressed /*&& characterController.isGrounded*/)
            {
                yvelocity += jumpForce;
            }

        if (joinpressed)
        {
             Instantiate(playerPrefab, transform.position, Quaternion.identity);
        }
        //// salto
        //Jump(jumpPressed);

        // Movimiento
        InterpolateSpeed(shiftPressed, moveInput.x, moveInput.y);
            Movement(moveInput.x, moveInput.y, shiftPressed);

            //InterpolateSpeed(shiftPressed, x, z);
            //    Movement(x, z, shiftPressed);
            //Rotation(mouseX);
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

