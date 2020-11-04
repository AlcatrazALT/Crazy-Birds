using UnityEngine;
using UnityEngine.SceneManagement;

public class GreenBird : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _isBirdLaunched;
    private float _timeSittingAround;

    [SerializeField]
    private float _launchPower = 500;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (_isBirdLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }

        if (transform.position.y < -10 || transform.position.y > 10
            || transform.position.x < -10 || transform.position.x > 10 || _timeSittingAround > 3)
        {
            var currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _isBirdLaunched = true;
    }

    private void OnMouseDrag()
    {
        var newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}