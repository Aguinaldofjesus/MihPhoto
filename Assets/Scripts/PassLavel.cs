using UnityEngine.SceneManagement;
using UnityEngine;

public class PassLavel : MonoBehaviour
{
    private Animator Anim;
    //public GameObject[] Keys;
    public float KeyCount;
    [SerializeField] private bool Unlocked;
    [SerializeField] bool IsComplete;
    void Start()
    {

        if (LevelsUnlocked.instance.Unlocked >= SceneManager.GetActiveScene().buildIndex)
        {

            Unlocked = false;

        }

        Anim = GetComponent<Animator>();

    }

    void Update()
    {
        
        if (KeyCount == 0 && IsComplete == false)
        {

            Anim.SetBool("Complete", true);
            IsComplete = true;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (IsComplete)
        {

            if (!Unlocked)
            {

                LevelsUnlocked.instance.Unlocked += 1;
                Unlocked = true;

            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

    }
}
