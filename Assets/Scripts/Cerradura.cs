using UnityEngine;
using UnityEngine.InputSystem;

public class Cerradura : MonoBehaviour
{
    public DoorController doorController;

    public void UsarLlave(Llave llave)
    {
        // Verifica si la llave es v�lida (puedes agregar m�s l�gica aqu�)
        if (llave != null)
        {
            // Llama al m�todo OpenDoor de la puerta
            doorController.OpenDoor();
        }
    }
}