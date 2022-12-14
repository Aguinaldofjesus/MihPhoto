using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject FotoInstance;
    private PassLavel Foto;
    private bool Hit;

    private void Start()
    {
        
        Foto = FotoInstance.GetComponent<PassLavel>();

    }
    private void Update()
    {
        
        if (Hit)
        {

            Foto.KeyCount--;
            Destroy(this.gameObject);

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Hit = true;

    }

}
