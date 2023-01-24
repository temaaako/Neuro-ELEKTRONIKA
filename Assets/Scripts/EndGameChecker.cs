using UnityEngine;

public class EndGameChecker : MonoBehaviour
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
            _game.HP--;
            Destroy(collision.gameObject);
            if (_game.HP <= 0)
            {
                _game.GameOver();
            }
        }
    }
}
