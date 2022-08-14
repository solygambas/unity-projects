using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float DistanceToGround = 0.1f;
    public LayerMask GroundLayer;
    private CapsuleCollider _col;

    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;

    private float _vInput;
    private float _hInput;

    private Rigidbody _rb;

    public float JumpVelocity = 5f;
    private bool _isJumping;

    public GameObject Bullet;
    public float BulletSpeed = 100f;
    private bool _isShooting;

    private GameBehavior _gameManager;

    public delegate void JumpingEvent();
    public event JumpingEvent playerJump;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        _isJumping |= Input.GetKeyDown(KeyCode.Space); 
        _isShooting |= Input.GetMouseButtonDown(0);
        // up, down, W, S
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        // left, right, A, D
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;
        // this = the GameObject the script is attached to
        // this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);
        // this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if(IsGrounded() && _isJumping)
        {
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
            playerJump();
        }
        _isJumping = false;

        if (_isShooting)
        {
            GameObject newBullet = Instantiate(Bullet, this.transform.position + new Vector3(1, 0, 0), this.transform.rotation);
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * BulletSpeed;
        }
        _isShooting = false;

        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, DistanceToGround, GroundLayer, 
        QueryTriggerInteraction.Ignore);
        return grounded;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Enemy")
        {
            _gameManager.HP -= 1;
        }
    }
}
