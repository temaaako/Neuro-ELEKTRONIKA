using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _upRight;
    [SerializeField] private GameObject _upLeft;
    [SerializeField] private GameObject _downRight;
    [SerializeField] private GameObject _downLeft;

    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _hpText;
    [SerializeField] private GameObject _endGamePanel;

    private int _score=0;
    public int Score
    {
        get { return _score; }
        set { _score = value;
            _scoreText.text = _score.ToString();
        }
    }

    [SerializeField] private int _hp = 3;

    public int HP
    {
        get { return _hp; }
        set
        {
            if (_hp < 0) 
                _hp = 0; 
            
            _hp = value;
            _hpText.text = _hp.ToString();
        }
    }


    void Start()
    {
        _upRight.SetActive(false);
        _upLeft.SetActive(false);
        _downLeft.SetActive(false); 


        _endGamePanel.SetActive(false);
        HP = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
        if (Time.timeScale == 0)
            return;


        InputHandler();
    }

    private void InputHandler()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _upRight.SetActive(true);
            _upLeft.SetActive(false);
            _downRight.SetActive(false);
            _downLeft.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            _upRight.SetActive(false);
            _upLeft.SetActive(true);
            _downRight.SetActive(false);
            _downLeft.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _upRight.SetActive(false);
            _upLeft.SetActive(false);
            _downRight.SetActive(true);
            _downLeft.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _upRight.SetActive(false);
            _upLeft.SetActive(false);
            _downRight.SetActive(false);
            _downLeft.SetActive(true);
        }
    }
    public void ResetGame()
    {
        _endGamePanel.SetActive(false);
        Score = 0;
        HP = 3;
        Egg[] eggs = FindObjectsOfType<Egg>();
        foreach (Egg egg in eggs)
        {
            Destroy(egg.gameObject);
        }
        _endGamePanel.SetActive(false);

        Time.timeScale = 1;
    }

    public void GameOver()
    {
        _endGamePanel.SetActive(true);
        Time.timeScale = 0;
    }

    }
