using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    Vector3 _initialPosition;
    private Float _lauchPower = 500;

    private void Awake(){
        _initialPosition = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(transform.position.y < -4.3 || transform.position.y > 5.6 || transform.position.x < -7.8 || transform.position.x > 7.5)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    private void OnMouseDown() {
        GetComponent<SpriteRenderer>().color = Color.red;
    }


    private void OnMouseUp() {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 direction = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(direction * _lauchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private void OnMouseDrag(){
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // if(newPosition.y < -4 || newPosition.y > 5.6 || newPosition.x < -7.8 || newPosition.x > 7.5) return;

        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }
}
