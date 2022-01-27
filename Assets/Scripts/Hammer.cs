using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    private const float maxPos = 1.5f;
    public float offset = 0.2f;
    // Start is called before the first frame update
   private void HammerMovement()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x % maxPos, Input.mousePosition.y % maxPos);
        Vector2 hammerPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Debug.Log(Input.mousePosition.x % maxPos);
        transform.position = hammerPosition; // changing hammer's position
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HammerMovement();
        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float rotZ = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset); // changing hammer rotation
    }
}
