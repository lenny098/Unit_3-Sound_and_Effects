using UnityEngine;

[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(Animator)), RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    Rigidbody rigidbody;
    Animator animator;
    AudioSource audioSource;

    [SerializeField] ParticleSystem explosion;
    [SerializeField] ParticleSystem dirt;

    [SerializeField] AudioClip jumpAudio;
    [SerializeField] AudioClip crashAudio;

    [SerializeField] float jumpForce;
    [SerializeField] float gravityModifier;

    bool isOnGround;
    public bool isGameOver { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
    }

    void Jump()
    {
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        isOnGround = false;
        dirt.Stop();

        animator.SetTrigger("Jump_trig");
        audioSource.PlayOneShot(jumpAudio);
    }

    void Land()
    {
        isOnGround = true;
        dirt.Play();
    }

    void GameOver()
    {
        isGameOver = true;
        dirt.Stop();
        animator.SetBool("Death_b", true);

        explosion.Play();
        audioSource.PlayOneShot(crashAudio);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                Land();

                break;
            case "Obstacle":
                GameOver();

                break;
            default:
                break;
        }
    }
}
