using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;


public class MoveBySquare : MonoBehaviour
{
  public InputAction _pressAction;
  public int _DirectionFactor = 1; // -1 == goes to the left, 1 to the right
  private Rigidbody2D _RigidBody = null;
  
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    _RigidBody = GetComponent<Rigidbody2D>();
  }

  void OnEnable()
  {
    Debug.Log("Press action enabled\n");
    _pressAction.Enable();
  }

  void Update()
  {
    if (_pressAction.WasPerformedThisFrame())
    {
      // the arm goes to the left or right (space was pressed)
      Debug.Log("GO GO GO\n");
      _RigidBody.linearVelocity += new Vector2(400.0f*Time.deltaTime*(float)_DirectionFactor, 0);
    }
  }
}
