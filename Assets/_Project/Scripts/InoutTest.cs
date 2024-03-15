using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InoutTest : MonoBehaviour
{
    public Player player;
    public ScorePanel scorePanel;
    public float speed = 10;

    private Vector3 position;
    private float width;
    private float height;

    public Vector3 pos;

    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;

        // Position used for the cube.
        position = new Vector3(0.0f, 0.0f, 0.0f);

        Physics2D.queriesHitTriggers = true;

        pos = player.transform.position;
        originPos = pos;
    }

    Vector3 originPos;
    //public float TotalDistance { get; private set; }

    //TODO: move into FixedUpdate
    private void Update()
    {
        //TODO: use IPointerClickHandler instead
        if (Input.GetMouseButtonDown(0))
        {

            var offset = 30;
            var pos1 = Input.mousePosition;
            pos1 = new Vector3(Mathf.Clamp(pos1.x, offset, Screen.width - offset), Mathf.Clamp(pos1.y, offset, Screen.height - offset), pos1.z);
            pos = Camera.main.ScreenToWorldPoint(pos1);
            pos.z = 0;

            originPos = player.transform.position;
        }

        player.transform.position = Vector3.Lerp(player.transform.position, pos, speed * Time.deltaTime);

        //TODO: sqrMagnitude
        var distance = Vector3.Distance(originPos, player.transform.position);
        scorePanel.model.AddDistance(distance);

        //TotalDistance += distance;
        originPos = player.transform.position;

        return;




        // Handle screen touches.
        if (Input.touchSupported && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                position = new Vector3(-pos.x, pos.y, 0.0f);

                // Position the cube.
                player.transform.position = position;
            }

            if (Input.touchCount == 2)
            {
                touch = Input.GetTouch(1);

                if (touch.phase == TouchPhase.Began)
                {
                    // Halve the size of the cube.
                    transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    // Restore the regular size of the cube.
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                }
            }
        }
    }
}
