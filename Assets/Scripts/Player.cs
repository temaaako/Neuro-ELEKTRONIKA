using UnityEngine;

public class Player : MonoBehaviour
{
    private Game _game;
    private void Start()
    {
        _game = FindObjectOfType<Game>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Egg>())
        {
            _game.Score++;
            Debug.Log(_game.Score);
            Destroy(collision.gameObject);
        }
    }
}
