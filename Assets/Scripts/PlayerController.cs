using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{

    public float speed = 0;

    public TextMeshProUGUI countText;
    public GameObject WinTextObject;
    public GameObject WinTextObjectSecret;
    public GameObject HiddenWall;
    public GameObject HiddenPickUp;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        WinTextObject.SetActive(false);
        WinTextObjectSecret.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 6)
        {
            WinTextObject.SetActive(true);
        }
        if (count >= 7)
        {
            WinTextObject.SetActive(false);
            WinTextObjectSecret.SetActive(true);
        }
    }
    void HideComponent()
    {
        HiddenWall.SetActive(false);
        HiddenPickUp.SetActive(false);
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false); 
            count++;
            SetCountText();
            if(count >=6)
            {
                HideComponent();
            }
        }

    }
}
