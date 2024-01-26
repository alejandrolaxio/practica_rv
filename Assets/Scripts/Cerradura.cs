using UnityEngine;
using UnityEngine.InputSystem;

public class Cerradura : MonoBehaviour
{
    public DoorController doorController;

    public void UsarLlave(Llave llave)
    {
        // Verifica si la llave es válida (puedes agregar más lógica aquí)
        if (llave != null)
        {
            // Llama al método OpenDoor de la puerta
            doorController.OpenDoor();
        }
    }
}