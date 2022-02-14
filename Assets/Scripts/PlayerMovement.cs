using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float playerspeed;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousepos;
    private PlayerStatus stat;
    public RectTransform canvas;
    private float offset;
    void Start(){
        stat = GetComponent<PlayerStatus>();
        playerspeed = stat.playerspeed;
        offset = stat.healthBarOffset;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        canvas.position = (rb.position) + new Vector2(0,-1*offset);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position+movement*playerspeed*Time.fixedDeltaTime);
        Vector2 lookDir = mousepos - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x)*Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
