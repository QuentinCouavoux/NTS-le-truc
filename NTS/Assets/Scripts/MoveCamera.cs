using UnityEngine;
public class MoveCamera : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private Vector3 velocity = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(new Vector3(transform.position.x,transform.position.y,-10), new Vector3(player.transform.position.x,player.transform.position.y,-10),ref velocity, speed);
    }
}
