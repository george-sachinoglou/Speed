using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float moveSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = GameManager.obstacleSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = GameManager.obstacleSpeed;
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.tag == "Despawn")
            {
                Destroy(this.gameObject);
            }
        }

    }




}
