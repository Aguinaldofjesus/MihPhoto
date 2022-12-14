using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{

    public GameObject Paused;
    public GameObject Photo;
    public GameObject RigthArrow;
    public GameObject LeftArrow; 

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Paused.SetActive(true);
            Time.timeScale = 0;

        }

        if (Photo.transform.rotation == Quaternion.Euler(0, 0, 180))
        {

            RigthArrow.SetActive(false);

        }
        else
        {

            RigthArrow.SetActive(true);

        }

        if (Photo.transform.rotation == Quaternion.Euler(0, 0, -180))
        {

            LeftArrow.SetActive(false);

        }
        else
        {

            LeftArrow.SetActive(true);

        }

    }

}
