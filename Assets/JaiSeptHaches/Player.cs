using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] 
    private uint health=0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health=3;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void TakeDamage(uint damage)
    {
        if(damage!=0)
            health-=damage;
    }
}
