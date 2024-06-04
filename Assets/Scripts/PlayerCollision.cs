using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody rb; // Referenz zur Rigidbody-Komponente

    void Start()
    {
        // Rigidbody-Komponente beim Start des Spiels abrufen
        rb = GetComponent<Rigidbody>();
    }

    // Diese Methode wird aufgerufen, wenn der Spieler mit einem anderen Objekt kollidiert
    void OnCollisionEnter(Collision collision)
    {
        // Überprüfen, ob der Spieler mit einem Objekt mit dem Tag "Obstacle" kollidiert
        if (collision.gameObject.tag == "Obstacle")
        {
            // Hier können Sie definieren, was passieren soll, wenn der Spieler mit einem Hindernis kollidiert
            // Zum Beispiel könnten Sie den Spieler stoppen, eine Nachricht ausgeben, etc.
            Debug.Log("Kollision erkannt mit " + collision.gameObject.name);

            // Drehkraft auf den Spieler auf null setzen
            rb.angularVelocity = Vector3.zero;

            // Geschwindigkeit des Spielers auf null setzen, um ihn zu stoppen
            rb.velocity = Vector3.zero;
        }
    }
}