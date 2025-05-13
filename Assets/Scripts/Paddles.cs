using UnityEngine;
using UnityEngine.Animations;
using static UnityEngine.GraphicsBuffer;

public class Paddles : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject center;
    public bool clockwise;
    public bool counterclockwise;
    private float movement;
    [SerializeField]
    public float speed;


    void Start()
    {
        
        speed = 50;
        clockwise = true;
        counterclockwise = false;
    }

    void Update()
    {
        foreach (Transform eachPaddle in transform)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                clockwise = true;
                counterclockwise = false;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                clockwise = false;
                counterclockwise = true;
            }
            if (clockwise == true) 
            {
                Vector3 centerPosition = new Vector3 (center.transform.position.x, center.transform.position.y, center.transform.position.z);
                transform.RotateAround(centerPosition, Vector3.forward, speed * Time.deltaTime);
            }
            if (counterclockwise == true)
            {
                Vector3 centerPosition = new Vector3(center.transform.position.x, center.transform.position.y, center.transform.position.z);
                transform.RotateAround(centerPosition, Vector3.back, speed * Time.deltaTime);
            }
        }
    }
}
