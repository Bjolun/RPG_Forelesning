using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Referanse til input actions for å ta i mot input
    private PlayerControls input;

    // Kontroll for movement speed
    [SerializeField] private float movementSpeed;

    // Kontroll for rotation speed
    [SerializeField] private float rotationSpeed;

    // Se om vi flytter oss eller ikke (brukes i animasjoner senere)
    private bool isRunning = false;

    // Deklarerer vi eget event.
    public event Action OnInteractAction;

    // Instanstiere og aktivere input actions
    private void Awake()
    {
        input = new PlayerControls();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Start()
    {
        input.Player.Interact.performed += Interact_performed; 
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke();
    }

    private void Update()
    {
        // Lagre inputen vår.
        Vector2 inputVector = input.Player.Move.ReadValue<Vector2>();

        // Lagre og oversette inputVector til en Vector3
        Vector3 movementVector = new Vector3(inputVector.x, 0f, inputVector.y);

        // Flytte karakteren vår basert på input og ønsket movementSpeed
        transform.position += movementVector * movementSpeed * Time.deltaTime;

        // Rotere karakteren vår basert på input og ønsket rotationSpeed.
        transform.forward = Vector3.Slerp(transform.forward, movementVector, rotationSpeed * Time.deltaTime);

        // Sjekk for å se om movementVector = 0,0,0
        if(movementVector == Vector3.zero)
        {
            // Hvis den er det, så sett isRUnning til false
            isRunning = false;
        }
        // Hvis ikke
        else
        {
            // Sett isRunnin til true
            isRunning = true;
        }
;    }

    public bool IsRunning()
    {
        return isRunning;
    }



}
