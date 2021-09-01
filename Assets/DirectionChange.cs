using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionChange : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	

    private bool m_contact;
    [SerializeField] private float x_speed = 35f;
    [SerializeField] private float y_speed = 35f;
    private Rigidbody2D m_Rigidbody2D;
    const float k_ContactRadius = .2f;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        Vector3 initialVelocity = new Vector2(x_speed, y_speed);
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, initialVelocity, ref velocity, m_MovementSmoothing);
    }

    // Update is called once per frame
    void Update()
    {
		void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("x_wall"))
            {
                Vector3 targetVelocity = new Vector2((x_speed * -1), y_speed);
                m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);
            }
            else if (other.gameObject.CompareTag("y_wall"))
            {
                Vector3 targetVelocity = new Vector2(x_speed, (y_speed * -1));
                m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);
            }
        }
	}
}
