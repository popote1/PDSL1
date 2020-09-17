using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 1f;
    public float RotationSpeed = 10f;
    
    [Header("limite terrain")] 
    public Vector2 DroitHaut;
    public Vector2 GaucheBas;
    private CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawLine(transform.position, cursorPos);

        transform.up = (cursorPos-new Vector2(transform.position.x,transform.position.y));

    }
    public static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }
    public static Vector2 RadianToVector2(float radian, float length)
    {
        return RadianToVector2(radian) * length;
    }
    public static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }
    public static Vector2 DegreeToVector2(float degree, float length)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad) * length;
    }

    private void FixedUpdate()
    {
        Vector3 moveVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0) * Time.deltaTime;
        cc.Move(moveVector * MoveSpeed);

        /*float rotationAdd = Input.GetAxisRaw("Mouse X");
        transform.eulerAngles = transform.eulerAngles + new Vector3(0,0, rotationAdd * RotationSpeed * Time.deltaTime);
        transform.position = new Vector3( Mathf.Clamp(transform.position.x,GaucheBas.x, DroitHaut.x),Mathf.Clamp(transform.position.y,GaucheBas.y, DroitHaut.y),0);
    */}
}

