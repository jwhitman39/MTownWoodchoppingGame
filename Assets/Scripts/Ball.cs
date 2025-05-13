using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;

public class Ball : MonoBehaviour
{
    public float speed;
    public GameObject ball;
    public GameObject chopZone;
    public Rigidbody2D rb;
    public GameObject center;
    public GameObject woodAmount;
    public Vector3 centerPosition;
    public bool chopDetector;
    public bool checkPlacement = false;
    public bool resetDisable = false;
    public int wood = 0;
    Player PlayerLogic = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject tempObj = GameObject.Find("Player");
        PlayerLogic = tempObj.GetComponent<Player>();
        checkPlacement = false;
        resetDisable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            checkPlacement = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            checkPlacement = false;
        }
    }
    
    public void Launch()
    {
        StartCoroutine(DelayChop(5f));
        float x = Random.Range(0, 3) == 0 ? -1 : 1;
        float y = Random.Range(0, 3) == 0 ? -1 : 1;
        rb.linearVelocity = new Vector2(speed * x, speed * y);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        BoxCollider2D ballBox = ball.GetComponent<BoxCollider2D>();
        BoxCollider2D bullseye = chopZone.GetComponent<BoxCollider2D>();
        //Debug.Log(other.name);
        // IF the ball goes into ONLY the big chop zone
        if ((other.gameObject.name == "BigChopZone")
            && (ballBox.bounds.Intersects(bullseye.bounds) == false)
            && (checkPlacement == true) 
            && (resetDisable == false))
        {
            wood += 1;
            PlayerLogic.SetConcentration(-5f);
            woodAmount.GetComponent<TextMeshProUGUI>().text = wood.ToString();
            Debug.Log("chopped! you now have " + wood + " wood!");
            checkPlacement = false;
            Reset();
        }
        // IF the ball goes into the bullseye area
        if ((other.name == "ChopZone")
            && bullseye.bounds.Intersects(ballBox.bounds) 
            && (checkPlacement == true)
            && (resetDisable == false))
        {
            wood += 3;
            PlayerLogic.SetConcentration(-5f);
            woodAmount.GetComponent<TextMeshProUGUI>().text = wood.ToString();
            Debug.Log("Nice chop! you harvested 2 additional wood and now have " + wood + " wood!");
            checkPlacement = false;
            Reset();
        }
        // IF the player tries to cheat when the ball is resetting in the middle
        if ((other.gameObject.name == "ChopZone") && (checkPlacement == true) && (resetDisable == true))
        {
            Debug.Log("Nice try cheater :D");
            return;
        }
        // IF the player chops but ball is not in any of the scoring zones
    }
    public IEnumerator DelayLaunch(float delay)
    {
        resetDisable = true;
        yield return new WaitForSeconds(delay);
        Launch();
    }
    public IEnumerator DelayChop(float delay)
    {
        yield return new WaitForSeconds(delay);
        resetDisable = false;
    }
    public void Reset()
    {
        chopDetector = false;
        Debug.Log("ball is being reset");
        centerPosition = new Vector3(center.transform.position.x, center.transform.position.y, center.transform.position.z);
        rb.linearVelocity = Vector3.zero;
        transform.position = centerPosition;
        StartCoroutine(DelayLaunch(2f));
        return;
    }
}
