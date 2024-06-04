using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Geschwindigkeit der Spielfigur, anpassbar im Unity-Editor
    public float rotationSpeed = 200f; // Geschwindigkeit der Drehung, anpassbar im Unity-Editor

    // Update wird einmal pro Frame aufgerufen
    void Update()
    {
        // Vektor für die Bewegungsrichtung initialisieren
        Vector3 direction = Vector3.zero;

        // Überprüfen, ob die W-Taste gedrückt wird, um die Spielfigur nach vorne zu bewegen
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }

        // Überprüfen, ob die S-Taste gedrückt wird, um die Spielfigur nach hinten zu bewegen
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }

        // Überprüfen, ob die A-Taste gedrückt wird, um die Spielfigur zu drehen
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }

        // Überprüfen, ob die D-Taste gedrückt wird, um die Spielfigur zu drehen
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

        // Normalisieren der Richtung, um gleichmäßige Geschwindigkeit in alle Richtungen zu gewährleisten
        direction.Normalize();

        // Bewegen der Spielfigur basierend auf der berechneten Bewegungsrichtung und Geschwindigkeit
        // Verwenden von transform.TransformDirection, um den Bewegungsvektor in den lokalen Raum der Spielfigur zu transformieren
        transform.Translate(transform.TransformDirection(direction) * speed * Time.deltaTime, Space.World);
    }
}