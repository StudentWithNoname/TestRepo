using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Geschwindigkeit der Spielfigur, anpassbar im Unity-Editor
   [SerializeField]
    public float rotationSpeed = 100f; // Geschwindigkeit der Drehung, anpassbar im Unity-Editor
    public float drag = 0f; // Luftwiderstand, anpassbar im Unity-Editor
    public float angularDrag = 3f; // Widerstand gegen Drehbewegung, anpassbar im Unity-Editor
    private Rigidbody rb; // Referenz zur Rigidbody-Komponente

    void Start()
    {
        // Rigidbody-Komponente beim Start des Spiels abrufen
        rb = GetComponent<Rigidbody>();

        // Rotation in den X- und Z-Achsen einfrieren
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        // Luftwiderstand einstellen
        rb.drag = drag;

        // Widerstand gegen Drehbewegung einstellen
        rb.angularDrag = angularDrag;

        // Kollisionsdetektionsmodus auf kontinuierlich setzen
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

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