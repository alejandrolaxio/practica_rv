using UnityEngine;
using UnityEngine.InputSystem;

public class BotonPuerta : MonoBehaviour
{
    public DoorController puerta; // Asigna la puerta desde el Inspector
    private bool isPlayerNear;
    private bool isDoorOpen;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // El jugador est� cerca del bot�n
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // El jugador dej� de estar cerca del bot�n
            isPlayerNear = false;
        }
    }

    void Update()
    {
        // Verifica si se presiona la tecla E para abrir o cerrar la puerta
        if (isPlayerNear && Keyboard.current != null && Keyboard.current.eKey.isPressed)
        {
            // Cambia el estado de la puerta (abre o cierra)
            if (puerta != null)
            {
                if (isDoorOpen)
                {
                    puerta.CloseDoor();
                }
                else
                {
                    puerta.OpenDoor();
                }

                // Actualiza el estado de la puerta
                isDoorOpen = !isDoorOpen;

                // Imprime mensajes de depuraci�n
                Debug.Log("Se presion� la tecla E para interactuar con la puerta.");
            }
        }
    }
}