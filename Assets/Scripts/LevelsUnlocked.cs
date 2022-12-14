using UnityEngine;

public class LevelsUnlocked : MonoBehaviour
{

    public float Unlocked = 2;
    public static LevelsUnlocked instance;

    private void Awake()
    {

        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {

            instance = this;

        }
        else
        {

            Destroy(gameObject);

        }

    }

}

