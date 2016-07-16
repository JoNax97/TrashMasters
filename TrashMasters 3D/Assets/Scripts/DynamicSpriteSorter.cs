using UnityEngine;
using System.Collections;

public class DynamicSpriteSorter : MonoBehaviour {

    SpriteRenderer renderer;

    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sortingOrder = -1 * (int)transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        renderer.sortingOrder = -1 * (int)transform.position.z;
    }
}
