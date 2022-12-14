using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] private int LevelID;
    public Button LevelButton;

    private void Awake()
    {
        
        if (LevelsUnlocked.instance.Unlocked >= LevelID + 2)
        {

            LevelButton.interactable = true;

        }

    }

    public void NextLevel()
    {

        SceneManager.LoadScene(LevelID + 1);

    }

}
