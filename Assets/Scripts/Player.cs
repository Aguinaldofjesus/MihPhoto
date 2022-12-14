using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Components")]
    public GameObject PhotoObj;
    public GameObject DeadScreen;
    public GameObject Death;
    [SerializeField] private SpriteRenderer Spr;
    [HideInInspector] public Photo ThePhoto;
    public Rigidbody2D Rig;
    public BoxCollider2D Col;
    private Animator Anim;
    public bool IsGround;
    [SerializeField] private bool PlayDeath;
    [SerializeField] ThePlayerState PlayerState = new ThePlayerState();
    enum ThePlayerState
    {

        IsFalling,
        IsRotating,
        IsDead,

    }

    void Start()
    {
     
        Spr = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
        ThePhoto = PhotoObj.GetComponent<Photo>();

    }

    void Update()
    {

        if (ThePhoto.IsRotating)
        {

            PlayerState = ThePlayerState.IsRotating;
            Anim.SetBool("Rotating", true);

        }
        else if (!ThePhoto.IsRotating && Input.GetKeyDown(KeyCode.Space) && ThePhoto.Holding)
        {

            ThePhoto.Holding = false;
            Anim.SetBool("Collide", false);
            Anim.SetBool("Rotating", false);
            Anim.SetBool("Falling", true);
            PlayerState = ThePlayerState.IsFalling;

        }

        switch (PlayerState)
        {

            case ThePlayerState.IsFalling:

                Rig.gravityScale = 1;
                Col.enabled = true;

            break;

            case ThePlayerState.IsRotating:

                Rig.velocity = new Vector2(0, 0);
                Rig.gravityScale = 0;
                Col.enabled = false;

            break;

            case ThePlayerState.IsDead:

                DeadScreen.SetActive(true);
                Destroy(Spr);
                Destroy(Col);

                if (PlayDeath)
                {

                    Instantiate(Death, transform.position, transform.rotation);
                    PlayDeath = false;

                }

            break;

        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {

        Anim.SetBool("Falling", false);
        Anim.SetBool("Collide", true);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Spikes"))
        {

            Rig.gravityScale = 0;
            PlayDeath = true;
            Rig.velocity = new Vector2(0, 0);
            PlayerState = ThePlayerState.IsDead;

        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
        IsGround = false;

    }
    public void Collide()
    {

        IsGround = true;

    }

}
