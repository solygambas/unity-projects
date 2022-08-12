using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;

    private float _vInput;
    private float _hInput;

    // Update is called once per frame
    void Update()
    {
        // up, down, W, S
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        // left, right, A, D
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;
        // this = the GameObject the script is attached to
        this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);
    }
}
