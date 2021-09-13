//using System.Numerics;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class playerGo : MonoBehaviour{

    public float speed = 110;
    public Vector2 normal;
    public LayerMask groundOnly;
    public float jumpForce = 500;
    public bool isGrounded;
    public bool isDead;
    public Transform GroundCheck;
    public Transform BodyCheck;
    public GameController gameController;

    // Start is called before the first frame update
    void Start(){
        normal = Vector2.up;
    }

    // Update is called once per frame
    void Update(){
        if(isGrounded){
            Move();

            if(Input.GetKeyDown(KeyCode.Space))
                Jump();
        }
    }

    private void FixedUpdate(){
        
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.3f, groundOnly);

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.5f), Vector2.down, 100f, groundOnly);

        //Debug.DrawRay(new Vector2(transform.position.x , transform.position.y - 0.5f), new Vector2(0, -16f), Color.blue);
        /*if(isGrounded)
            transform.up = hit.normal;
            */
        if(Input.GetKey(KeyCode.Space) && !isGrounded)
            FlipZ();              

        else if(!Input.GetKeyDown(KeyCode.Space))
            transform.up = hit.normal;
    }

    void Move(){

        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement*Time.deltaTime * speed;
        
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y-5);

    }

    void Jump(){
        transform.GetComponent<Rigidbody2D>().AddForce((transform.up + transform.forward) * jumpForce, ForceMode2D.Impulse);
        //transform.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;    
    }
    void FlipZ(){
        transform.Rotate(new Vector3(x:0, y:0, z:2f)); 
    }
/*
    void OnCollisionEnter2D(Collision2D collision){
        normal = collision.contacts[0].normal;
    }
*/
    void OnCollisionStay2D(Collision2D collision){
        normal = collision.contacts[0].normal;
        isDead = Physics2D.OverlapCircle(BodyCheck.position, 1f, groundOnly);
        if(isDead)
            gameController.GameOver();
    }

}
