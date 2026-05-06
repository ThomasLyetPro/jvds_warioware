using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;


public class MoveBySquare : MonoBehaviour
{
  public InputAction _pressAction;
  [SerializeField] int _DirectionFactor = 1; // -1 == goes to the left, 1 to the right
  private Rigidbody2D _RigidBody = null;

  private bool _IsMovingStarted = false;
  
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
    if (_IsMovingStarted || _pressAction.WasPerformedThisFrame())
    {
      // the arm goes to the left or right (space was pressed)
      _RigidBody.linearVelocity = new Vector2(5.0f*(float)_DirectionFactor, 0);
      _IsMovingStarted = true;
    }
  }
}
