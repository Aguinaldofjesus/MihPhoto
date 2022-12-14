using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour
{

    public void Resume()
    {

        Time.timeScale = 1;
        gameObject.SetActive(false);

    }

    public void retry()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Menu()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");

    }

    public void SelecLevel()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene("SelecLevel");

    }

    public void Quit()
    {

        Application.Quit();
        Debug.Log("Jogo fechou");

    }

    public void Play()
    {

        SceneManager.LoadScene(2);

    }
    public void Credits()
    {

        SceneManager.LoadScene("Credits");

    }

}
