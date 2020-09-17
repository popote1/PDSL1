
using UnityEngine;

public class EnnemiScripte : MonoBehaviour
{
    public Transform Canon;
    public float FireRate = 1;
    public float FirePower = 10;
    public GameObject Bullet;
    [Header("PowerUp")]
    public GameObject PowerUp;
    [Range(1,10)] public float PowerUpSpawnChance =3;
    public int ChargeValueAutoSpawn;

    [Header("movement")] 
    public float DistanceMax;
    public float DistanceMin;
    public float MoveSpeed;

    [Header("limite terrain")] 
    public Vector2 DroitHaut;
    public Vector2 GaucheBas;

    private float tempo = 0;
    private Transform player;
    private CharacterController _cc;
    void Start()
    {
        player = (GameObject.Find("player")).transform;
        _cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;
        transform.up = transform.position- player.position;
        if (tempo >= FireRate)
        {
            tempo = 0;
            GameObject _bullet = Instantiate(Bullet, Canon.position, Canon.rotation);
            _bullet.GetComponent<Rigidbody2D>().AddForce((Vector3.Normalize(Canon.position-transform.position))*FirePower,ForceMode2D.Impulse);
        }

       

    }

    private void FixedUpdate()
    {
        float distance = (transform.position - player.position).magnitude;
        if (distance > DistanceMax)
        {
            _cc.Move(transform.up * -MoveSpeed);
            Debug.Log("trop loin");
        }else if (distance < DistanceMin)
        {
            _cc.Move(transform.up * MoveSpeed);
            Debug.Log("trop PR7T");
        }
        transform.position = new Vector3( Mathf.Clamp(transform.position.x,GaucheBas.x, DroitHaut.x),Mathf.Clamp(transform.position.y,GaucheBas.y, DroitHaut.y),0);
    }

    private void OnDestroy()
    {
        if (player.GetComponentInChildren<ShealdScripte>()._shealdValue <ChargeValueAutoSpawn)
        {
            Instantiate(PowerUp, transform.position, Quaternion.identity);
            Debug.Log("autoSpawn");
        }
        else
        {
           if (Random.Range(0, 10)<PowerUpSpawnChance)
               Instantiate(PowerUp, transform.position, Quaternion.identity); 
        }
    }
}
