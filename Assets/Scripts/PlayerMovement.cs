using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed = 5f;
    private float playerInput = 0f;
    [SerializeField] private bool isPlayer1;
    private float yBound = 3.91f;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (isPlayer1)
        {
            playerInput = Input.GetAxisRaw("Vertical");
        }
        else
        {
            playerInput = Input.GetAxisRaw("Vertical2");
        }
        //player.MovePosition(player.position + new Vector2(0f, playerInput) * speed * Time.deltaTime);
        Vector2 playerPosition = transform.position;
        playerPosition.y = Mathf.Clamp(playerPosition.y + playerInput * speed * Time.deltaTime, -yBound, yBound);
        transform.position = playerPosition;
    }
}
