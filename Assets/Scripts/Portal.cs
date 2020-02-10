using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject otherPortal;

    IEnumerator Wait(int n)
    {
        yield return new WaitForSeconds(n);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "basketball") return;

        teleport(collision.gameObject);
    }

    void teleport(GameObject ball)
    {
        ball.transform.position = otherPortal.transform.position;
        ball.GetComponent<CircleCollider2D>().enabled = false;
    }
}
