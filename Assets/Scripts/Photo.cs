using UnityEngine;

public class Photo : MonoBehaviour
{
    [Header("Components")]
    public GameObject PlayerObj;
    [HideInInspector] public Player ThePlayer;
    [Space]
    [Header("Check List")]
    [SerializeField] private float Spd;
    [SerializeField] private float Dir;
    [SerializeField] private bool CanRotate;
    public bool Holding;
    public bool IsRotating;

    private void Start()
    {
        
        ThePlayer = PlayerObj.GetComponent<Player>();

    }

    private void Update()
    {

        CanRotate = transform.rotation == Quaternion.Euler(0, 0, 0f) || transform.rotation == Quaternion.Euler(0, 0, 90f) ||
                    transform.rotation == Quaternion.Euler(0, 0, -90f) || transform.rotation == Quaternion.Euler(0, 0, 180f) ||
                    transform.rotation == Quaternion.Euler(0, 0, -180f);

        if (CanRotate)
        {

            IsRotating = false;

            transform.Rotate(new Vector3(0, 0, 0f));

            if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.rotation != Quaternion.Euler(0, 0, -180f) && ThePlayer.IsGround ||
                Input.GetKeyDown(KeyCode.LeftArrow) && transform.rotation != Quaternion.Euler(0, 0, -180f) && Holding)
            {

                Dir = -1;
                Holding = true;
                IsRotating = true;

            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && transform.rotation != Quaternion.Euler(0, 0, 180f) && ThePlayer.IsGround ||
                Input.GetKeyDown(KeyCode.RightArrow) && transform.rotation != Quaternion.Euler(0, 0, 180f) && Holding)
            {

                Dir = 1;
                Holding = true;
                IsRotating = true;

            }

        }

        if (IsRotating && Time.timeScale != 0)
        {

            PlayerObj.transform.Rotate(new Vector3(0, 0, Spd * -Dir));
            transform.Rotate(new Vector3(0, 0, Spd * Dir));

        }

    }

}
