using UnityEngine;

public class GameManager : MonoBehaviour
{
  float x_arm1;
  float width_arm1;
  float x_arm2;
  float width_arm2;

  Vector2 _bulletSpawnPoint;

  public GameObject bulletPrefab;

  bool bidon = false;
  
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    var arm_1 = GameObject.Find("Arm_1");
    var arm_2 = GameObject.Find("Arm_2");

    var transform_1 = arm_1.GetComponent<Transform>();
    var transform_2 = arm_2.GetComponent<Transform>();

    x_arm1 = transform_1.position.x;
    x_arm2 = transform_2.position.x;

    width_arm1 = transform_1.localScale.x;
    width_arm2 = transform_2.localScale.x;

    Debug.Log($"width_arm1={width_arm1} / width_arm2={width_arm2}");

    var cam = GameObject.Find("Main Camera");
    var compCam = cam.GetComponent<Camera>();
    Rect posCam = compCam.pixelRect;
    
    _bulletSpawnPoint = new Vector2(posCam.x + 0.5f*posCam.width, posCam.y);
    Debug.Log($"_bulletSpawnPoint pos={_bulletSpawnPoint}");
  }

  // Update is called once per frame
  void Update()
  {
    // fire a bullet:
    if (!bidon) {
      Instantiate(bulletPrefab);
      bidon = true;
    }
  }
}


// onbecamevisible et onbecameinvisible
