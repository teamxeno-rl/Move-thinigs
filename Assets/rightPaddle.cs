using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightPaddle : MonoBehaviour
{
    [SerializeField] private float speed = 7.5f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = 0f;	
    private Vector3 velocity = Vector3.zero;
    private Rigidbody2D m_Rigidbody2D;
    bool up = false;
    bool down = false;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("down")) {
            Vector3 targetVelocity = new Vector2(0, (speed * -1));
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);
		}

		else if (Input.GetKey("up")) {
			Vector3 targetVelocity = new Vector2(0, speed);
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);
		}

        else {
            Vector3 targetVelocity = new Vector2(0, 0);
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);
        }

    }
}
