using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private float move;
    private Vector3 initialPos;

    private void Start()
    {
        initialPos = transform.position;
    }

    private void Update()
    {
        if (!UIController.Instance.IsRunning) return;
        if(UIController.Instance.currentState == GameState.Over) transform.position = initialPos;
        StartGame();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Circle"))
        {
            UIController.Instance.AddScore(-3);
        }
        else if (collision.gameObject.name.Contains("Capsule"))
        {
            UIController.Instance.AddScore(-2);
        }
        else
        {
            UIController.Instance.AddScore(+5);
            Debug.Log("+5");
        }
        UIController.Instance.UpdateLevel();
        Destroy(collision.gameObject);
    }

    void StartGame()
    {
        move = Input.GetAxis("Horizontal");
        float moveByFactor = move * speed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + moveByFactor, -7f, 7f), transform.position.y, transform.position.z);
    }
}






