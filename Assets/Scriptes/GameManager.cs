
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text TxtScrore;
    public Text TxtMulti;
    public float RespawnDelay;
    public float warningTime;
    public GameObject GameOverPannel;

    public GameObject Ennemi;
    [Header("Musique")] public AudioClip MainTheme;
    public AudioClip EndTheme;

    [Header("spawnZones")] public GameObject Spawnzone1;
    public GameObject Spawnzone2;
    public GameObject Spawnzone3;
    public GameObject Spawnzone4;
    public Vector2 SpawnZonemilite1;
    public Vector2 SpawnZonemilite2;
    public Vector2 SpawnZonemilite3;
    public Vector2 SpawnZonemilite4;

    [Header("Animation")] public LeanTweenType easeType;
    private int _score = 0;
    private bool _bouncestrick;
    private int _multipieur;
    private float _respawntimer;
    private int zonespawn;
    private bool warned = false;

    void Start()
    {
        _score = 0;
        _multipieur = 0;
        UpdateScore();
        _respawntimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _respawntimer += Time.deltaTime;

        if (_respawntimer > RespawnDelay - warningTime && !warned)
        {
            zonespawn = Random.Range(1, 4);
            switch (zonespawn)
            {
                case 1:
                    Spawnzone1.SetActive(true);
                    break;
                case 2:
                    Spawnzone2.SetActive(true);
                    break;
                case 3:
                    Spawnzone3.SetActive(true);
                    break;
                case 4:
                    Spawnzone4.SetActive(true);
                    break;
            }

            warned = true;
        }

        if (_respawntimer >= RespawnDelay)
        {
            switch (zonespawn)
            {case 1 :
                    
                        Instantiate(Ennemi, SpawnPos(SpawnZonemilite1), Quaternion.identity);
                        Instantiate(Ennemi, SpawnPos(SpawnZonemilite1), Quaternion.identity);
                        Instantiate(Ennemi, SpawnPos(SpawnZonemilite1), Quaternion.identity);
                        Instantiate(Ennemi, SpawnPos(SpawnZonemilite1), Quaternion.identity);
                        Debug.Log("spawnZ1");
                    

                    break;

                case 2 :  
                    
                        Instantiate(Ennemi, SpawnPos(SpawnZonemilite2), Quaternion.identity);
                        Instantiate(Ennemi, SpawnPos(SpawnZonemilite2), Quaternion.identity);
                        Instantiate(Ennemi, SpawnPos(SpawnZonemilite2), Quaternion.identity);
                        Instantiate(Ennemi, SpawnPos(SpawnZonemilite2), Quaternion.identity);
                    
                    Debug.Log("spawnZ2");

                    break;
                case 3 :                   
                    
                        Instantiate(Ennemi, SpawnPos(SpawnZonemilite3), Quaternion.identity);
                        Instantiate(Ennemi, SpawnPos(SpawnZonemilite3), Quaternion.identity);
                        Instantiate(Ennemi, SpawnPos(SpawnZonemilite3), Quaternion.identity);
                        Instantiate(Ennemi, SpawnPos(SpawnZonemilite3), Quaternion.identity);
                    
                    Debug.Log("spawnZ3");

                    break;
                case 4 :                  
                    
                        Instantiate(Ennemi, SpawnPos(SpawnZonemilite4), Quaternion.identity);
                        Instantiate(Ennemi, SpawnPos(SpawnZonemilite4), Quaternion.identity);
                        Instantiate(Ennemi, SpawnPos(SpawnZonemilite4), Quaternion.identity);
                        Instantiate(Ennemi, SpawnPos(SpawnZonemilite4), Quaternion.identity);
                    
                    Debug.Log("spawnZ4");

                    break;
                
            }
            Spawnzone1.SetActive(false);
            Spawnzone2.SetActive(false);
            Spawnzone3.SetActive(false);
            Spawnzone4.SetActive(false);
            _respawntimer = 0;
            warned = false;

        }

    }

    public void EnnemieKillBounce()
    {
        if (!_bouncestrick)
        {
            _multipieur = 0;
        }

        _multipieur++;
        _score += 1 * _multipieur;
        _bouncestrick = true;
        UpdateScore();
    }

    public void EnnemieKillDirect()
    {
        if (_bouncestrick)
        {
            _multipieur = 0;
        }

        _multipieur++;
        _score += 1 * _multipieur;
        _bouncestrick = false;
        UpdateScore();
    }

    private void UpdateScore()
    {
        TxtScrore.text = "" + _score;
        TxtMulti.text = "X " + _multipieur;
        if (_bouncestrick)
        {
            TxtMulti.color = Color.cyan;
        }
        else if (!_bouncestrick)
        {
            TxtMulti.color = Color.yellow;
        }
    }

    private Vector2 SpawnPos(Vector2 limite)
    {
        float x1;
        float x2;
        float y1;
        float y2;
        if (limite.x > 0)
        {
            x1 = 0;
            x2 = limite.x;
        }
        else
        {
            x1 = limite.x;
            x2 = 0;
        }

        if (limite.y > 0)
        {
            y1 = 0;
            y2 = limite.y;
        }
        else
        {
            y1 = limite.y;
            y2 = 0;
        }
        Vector2 vec =new Vector2(Random.Range(x1, x2), Random.Range(y1, y2));
       // Debug.Log( "X1 ="+ x1 +"     x2 ="+x2+"      y1=" +y1 +"      y2 ="+y2+"              "+vec);
        return vec;
        

    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        GameOverPannel.SetActive(true);
        Camera.main.gameObject.GetComponent<AudioSource>().clip = EndTheme;
        Camera.main.gameObject.GetComponent<AudioSource>().Play();
    }
    
    public void UIRestartLVL()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void UIQuite()
    {
        Application.Quit();
    }
        

}
