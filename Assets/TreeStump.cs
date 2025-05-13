using UnityEngine;

public class TreeStump : MonoBehaviour
{
    public bool ballDetector = true;
    public GameObject ball;

    void OnTriggerExit2D(Collider2D other)
    {
        ballDetector = false;
    }
}
