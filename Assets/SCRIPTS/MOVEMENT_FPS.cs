using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MOVEMENT_FPS : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    [SerializeField] bool cursorLock = true;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float Speed = 6.0f;
    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] float gravity = -30f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] private TextMeshPro PressP;
    private bool GoPlay = false;
    [SerializeField] private AudioSource CoinSound;
    public float x, y, z;
    private bool OpenDoor = false; 
    [SerializeField] private TextMeshPro PressQ;
    [SerializeField] private TextMeshPro PressM;
    private bool JukeboxOk = false;
    [SerializeField] private AudioSource Bgmusic;
 
    public float jumpHeight = 6f;
    float velocityY;
    bool isGrounded;
 
    float cameraCap;
    Vector2 currentMouseDelta;
    Vector2 currentMouseDeltaVelocity;
    
    CharacterController controller;
    Vector2 currentDir;
    Vector2 currentDirVelocity;
    Vector3 velocity;
 
    void Start()
    {  LoadPosition();
        controller = GetComponent<CharacterController>();
 
        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
            
            
            PressP.gameObject.SetActive(false);
            PressQ.gameObject.SetActive(false);
            PressM.gameObject.SetActive(false);
        }
    }
 
    void Update()
    {
        UpdateMouse();
        UpdateMove();
        
        if (GoPlay && Input.GetKeyDown(KeyCode.P))
        {
            SavePosition();
            CoinSound.Play();
            StartCoroutine(WaitScene()); 
            
        }

        if (OpenDoor && Input.GetKeyDown((KeyCode.Q)))
        {
            Application.Quit();
            Debug.Log("quit");
        }

        if (JukeboxOk && Input.GetKeyDown((KeyCode.M)))
        {
            Bgmusic.Stop();
           
        }
        else if ((JukeboxOk && Input.GetKeyDown((KeyCode.P))))
        {
            Bgmusic.Play();
        }
    }
 
    void UpdateMouse()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
 
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);
 
        cameraCap -= currentMouseDelta.y * mouseSensitivity;
 
        cameraCap = Mathf.Clamp(cameraCap, -90.0f, 90.0f);
 
        playerCamera.localEulerAngles = Vector3.right * cameraCap;
 
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }
 
    void UpdateMove()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, ground);
 
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();
 
        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);
 
        velocityY += gravity * 2f * Time.deltaTime;
 
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * Speed + Vector3.up * velocityY;
 
        controller.Move(velocity * Time.deltaTime);
 
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
 
        if(isGrounded! && controller.velocity.y < -1f)
        {
            velocityY = -8f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayZone"))
        {
            PressP.gameObject.SetActive(true);
            GoPlay = true;
           
            
        }
        else if (other.gameObject.CompareTag("DoorZone"))
        {
            PressQ.gameObject.SetActive(true);
            OpenDoor = true;
        }
        else if (other.gameObject.CompareTag("JukeboxZone"))
        {
            PressM.gameObject.SetActive(true);
            JukeboxOk = true;
         
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayZone"))
        {
            PressP.gameObject.SetActive(false);
            GoPlay = false;
        }
        else if (other.gameObject.CompareTag("DoorZone"))
        {
            PressQ.gameObject.SetActive(false);
            OpenDoor = false;
        }
        else if (other.gameObject.CompareTag("JukeboxZone"))
        {
            PressM.gameObject.SetActive(false);
            JukeboxOk = false;
         
        }

        
    }
    
    IEnumerator WaitScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SavePosition()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        
        PlayerPrefs.SetFloat("x", x);
        PlayerPrefs.SetFloat("y", y);
        PlayerPrefs.SetFloat("z", z);
        
    }

    public void LoadPosition()
    {
        x = PlayerPrefs.GetFloat("x") ;
        y = PlayerPrefs.GetFloat("y") ;
        z = PlayerPrefs.GetFloat("z") ;

        Vector3 LoadPosition = new Vector3(x, y, z);
        transform.position = LoadPosition;
    }
    
    
    
    
    
}