using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuJuegoPrincipal : MonoBehaviour
{
    //METODOS PUBLICOS O NO FUNCIONA
    public void jugar()
    {
        SceneManager.LoadScene("Proyecto");
    }

    public void salir()
    {
        Application.Quit(); 
    }
}
