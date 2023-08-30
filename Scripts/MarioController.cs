using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioController : MonoBehaviour
{
    
    [SerializeField]
    public float rotationSpeed;
    [SerializeField]
    public float jumpHeight;
    [SerializeField]
    private float gravityMultiplier;
    [SerializeField]
    private float jumpHorizontalSpeed;
    [SerializeField]
    public float jumpButtonGracePeriod;

    [SerializeField]
    private Transform cameraTransform;

    private AudioSource audioSource;
    private Animator animator;
    private CharacterController characterController;
    private float originalStepOffset;
    private float ySpeed;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;

    private bool isJumping;
    private bool isGrounded;

    //Skrypt do poruszania Mario
    void Start()
    {
        //Przypisane komponentów do zmiennych 
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        originalStepOffset = characterController.stepOffset;
        
        //ukrycie kursora myszy podczas gry
        Cursor.visible = false;
    }

    void Update()
    {
        //okreœlenie osi po których porusza siê Mario
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //skrêcanie podczas ruchu
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        //zwalnianie ruchu podczas trzymania Shift
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            inputMagnitude /= 2;
        }
        animator.SetFloat("InputMagnitude", inputMagnitude, 0.05f, Time.deltaTime);


        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        //obliczanie si³y grawitacji 
        float gravity = Physics.gravity.y * gravityMultiplier;


        //zachowanie Mario po klikniêciu Spacji 
        if(isJumping && ySpeed >0 && Input.GetButton("Jump")== false)
        {
            gravity *= 2;
        }
        ySpeed += gravity * Time.deltaTime;

        if(characterController.isGrounded)
        {
            lastGroundedTime = Time.time;
        }

        if(Input.GetButtonDown("Jump"))
        {
            jumpButtonPressedTime = Time.time;
            //dzwiêk skoku
            audioSource.Play();
        }

        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            //obs³uga animacji skoku
            animator.SetBool("IsGrounded", true);
            isGrounded = true;
            animator.SetBool("IsJumping", false);
            isJumping = false;
            animator.SetBool("IsFalling", false);
            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                ySpeed = Mathf.Sqrt(jumpHeight * -3*gravity);
                animator.SetBool("IsJumping", true);
                isJumping = true;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        }
        else
        {
            characterController.stepOffset = 0;
            animator.SetBool("IsGrounded", false);
            isGrounded = false;

            if((isJumping && ySpeed <0) || ySpeed<-2)
            {
                animator.SetBool("IsFalling", true);
            }
        }
        

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
        if(isGrounded==false)
        {
            Vector3 velocity = movementDirection * inputMagnitude * jumpHorizontalSpeed;
            velocity.y = ySpeed;
            characterController.Move(velocity * Time.deltaTime);
        }

        //Respawn po spadniêciu
        if(transform.position.y <= -5f)
        {
            SceneManager.LoadScene("Level 1");
        }
    }
    private void OnAnimatorMove()
    {
        if(isGrounded)
        {
            Vector3 velocity = animator.deltaPosition;
            velocity.y = ySpeed* Time.deltaTime;
            characterController.Move(velocity);
        }
        
    }
    private void OnApplicationFocus(bool focus)
    {
        if(focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;

        }
    }



}