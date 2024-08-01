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

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isOnGround = false;

            animator.SetTrigger("Jump_trig");
            dirt.Stop();
            audioSource.PlayOneShot(jumpAudio);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                isOnGround = true;

                dirt.Play();

                Debug.Log("On Ground");

                break;
            case "Obstacle":
                isGameOver = true;

                animator.SetBool("Death_b", true);
                dirt.Stop();
                explosion.Play();
                audioSource.PlayOneShot(crashAudio);

                Debug.Log("Game Over!");

                break;
            default:
                break;
        }
    }
}
