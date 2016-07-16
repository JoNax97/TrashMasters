using UnityEngine;
using System.Collections;

public class UnitDropper : MonoBehaviour {

    Vector2 touchPos;
    public Camera mainCamera;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchPos = Input.GetTouch(0).rawPosition;
            transform.position = mainCamera.ScreenToWorldPoint(touchPos);
        }
    }
}
