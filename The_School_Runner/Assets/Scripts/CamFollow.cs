using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;


    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
         transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z - 24f);
    }
}
