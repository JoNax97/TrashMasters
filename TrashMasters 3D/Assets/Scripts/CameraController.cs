using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float speed;
    float currentSpeed;
    public float bounds;
    GameObject theCamera;

    // Use this for initialization
    void Start () {
        Application.targetFrameRate = 30;
        theCamera = GameObject.FindGameObjectsWithTag("MainCamera")[0];
        Camera.main.transparencySortMode = TransparencySortMode.Orthographic;
    }

    void FixedUpdate()
    {
        if ( currentSpeed != 0 && (gameObject.transform.position.x - speed) >= -(bounds) && (gameObject.transform.position.x + speed) <= bounds)
        {
            theCamera.transform.Translate(currentSpeed, 0, 0);
        }
        
    }


    public void MoveLeft()
    {
        currentSpeed = speed * -1;
    }

    public void MoveRight()
    {
        currentSpeed = speed;
    }

    public void Stop()
    {
        currentSpeed = 0;
    }
}
