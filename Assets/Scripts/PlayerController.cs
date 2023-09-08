using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{ 

    public float moveSpeed;
    private Vector3 mousePosition;
    private Vector2 direction;
    private Rigidbody2D rb;
    private Vector3 position;
    private bool pressed;
    float angle;
    Quaternion rot;
    float maxSpeed1 = 3.5f;
    float maxSpeed2 = 3.5f;
    public string DeathSceneName;
    



    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButton(0))
        {
            pressed = true;
        }
    }

    private void FixedUpdate()
    {

        
        


            position = Camera.main.WorldToViewportPoint(transform.position);
            if (pressed)
            {
                mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                mousePosition.y += 0.4f;
                //if (mousePosition.y < 0.2)
                // {
                //   mousePosition.y = 0.2f + (0.2f - mousePosition.y);
                // }

                direction = (mousePosition - position).normalized;
                angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
                rot = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, 100);
                rb.velocity = new Vector2(direction.x * moveSpeed, 0);




            }
            else
            {
                angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
                rot = Quaternion.AngleAxis(angle, Vector3.forward);
                rb.velocity = Vector2.zero;
                mousePosition.y += 0.4f;
                if (transform.rotation.z != 0)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), 10 * Time.deltaTime);
                }

            }
            pressed = false;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Goal")
        {
            if (GameManager.obstacleSpeed < maxSpeed1)
            {
                GameManager.obstacleSpeed = GameManager.obstacleSpeed + (GameManager.obstacleSpeed * 0.04f);
            }
            
            if (ScoreManager.scoreCount > 50 && GameManager.obstacleSpeed < maxSpeed2)
            {
                GameManager.obstacleSpeed = GameManager.obstacleSpeed + (GameManager.obstacleSpeed * 0.04f);
            }
            ScoreManager.instance.AddPoint();
            
        }

        if (other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene(DeathSceneName);
        }

    }
    



}



