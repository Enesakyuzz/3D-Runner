using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public float runningSpeed;
    float touchXDelta = 0;
    float newX = 0;
    public float xSpeed;
    public float limitx;
    public float boostMultiplier; // Hızlandırma katsayısı
    private bool isBoosting; // Hızlandırma durumu
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwipeCheck();

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
    {
        isBoosting = true;
    }
    else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
    {
        isBoosting = false;
    }
    }

    private void SwipeCheck()
    {
        float currentSpeed = runningSpeed;
    if (isBoosting)
    {
        currentSpeed *= boostMultiplier;
    }


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //Debug.Log(Input.GetTouch(0).deltaPosition.x / Screen.width);
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }
        else
        {
            touchXDelta = 0;
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX,-limitx,limitx);
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + currentSpeed * Time.deltaTime);
        transform.position = newPosition;   
    }
}
