using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    Vector3 _initialPosition;
    private float _lauchPower = 350;
    private bool _hasBirdLaunched;
    private float _timeSittingAround;

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
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);

        if(_hasBirdLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.15){
            _timeSittingAround += Time.deltaTime;
        }

        if(transform.position.y < -20 || transform.position.y > 20 || transform.position.x < -20 || transform.position.x > 20 || _timeSittingAround > 3)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    private void OnMouseDown() {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;

    }


    private void OnMouseUp() {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 direction = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(direction * _lauchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;

        _hasBirdLaunched = true;
        GetComponent<LineRenderer>().enabled = false;

    }

    private void OnMouseDrag(){
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // if(newPosition.y < -4 || newPosition.y > 5.6 || newPosition.x < -7.8 || newPosition.x > 7.5) return;

        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }
}
