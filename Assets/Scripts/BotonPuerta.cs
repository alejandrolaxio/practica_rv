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
            // El jugador está cerca del botón
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // El jugador dejó de estar cerca del botón
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

                // Imprime mensajes de depuración
                Debug.Log("Se presionó la tecla E para interactuar con la puerta.");
            }
        }
    }
}