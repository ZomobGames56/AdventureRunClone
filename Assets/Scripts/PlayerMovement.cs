using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public int coins = 0;
    public float leftrightSpeed;
    private bool canJump = true;
    public bool isDead = false;
    public TextMeshProUGUI coinsText;

    private void Start()
    {
        coinsText.text = $"Coins : {coins}";
    }

    void Update()
    {
        if(transform.position.y < -5f)
        {
            isDead = true;
        }

        float moveX = Input.GetAxis("Horizontal");

        if(moveX > 0)
        {
            MoveTo(2.5f);
        }
        else if(moveX < 0)
        {
            MoveTo(-2.5f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            GetComponent<Rigidbody>().AddForce(transform.up * 8f, ForceMode.Impulse);
        //    GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
        }

        if(transform.position.y < -0.913f || transform.position.y > -0.911f)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }

        MoveForward();

        coinsText.text = $"Coins : {coins}";
    }

    void MoveTo(float start)
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(start, transform.position.y, transform.position.z), leftrightSpeed * Time.deltaTime);
    }

    void MoveForward()
    {
        transform.position += speed * Time.deltaTime * Vector3.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            coins++;
        }
    }
}
