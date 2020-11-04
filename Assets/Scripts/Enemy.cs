using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var bird = collision.collider.GetComponent<GreenBird>();
        if (bird != null)
        {
            Destroy(gameObject);
            return;
        }

        var enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            return;
        }

        if (collision.contacts[0].normal.y < -0.5)
        {
            Destroy(gameObject);
        } 
    }
}