
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AudioSource winSoundEffect;
    public GameManager gameManager;
    public Puppy_Script controller;
    public Animator animator;
    // Start is called before the first frame update
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    [SerializeField] private AudioSource jumpSoundEffect;
    
    bool jump = false;
    bool crouch = false;

    private Vector3 respawnPoint;
    public GameObject fallDetector;
    void Start()
    {
        animator.SetBool("JumpSword", false);
        animator.SetBool("JumpShoot", false);
        respawnPoint = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            jumpSoundEffect.Play();

        }
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("JumpShoot", true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("JumpSword", true);
        }


        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FallDetector")
        {
            SceneManager.LoadScene("Level1");
           // transform.position = respawnPoint;
        }
        if (collision.tag == "Win")
        {
            winSoundEffect.Play();
           // Debug.Log("reached the win space");
            gameManager.CompleteLevel();
        }
    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("JumpShoot", false);
        animator.SetBool("JumpSword", false);
    }
    public void OnCrouching(bool IsCrouching)
    {
        animator.SetBool("IsCrouching", IsCrouching);
    }
    void FixedUpdate()
    {
        //controls character move
        controller.Move(horizontalMove * Time.fixedDeltaTime,crouch,jump);
        jump = false;
    }

}
