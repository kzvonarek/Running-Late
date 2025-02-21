using UnityEngine;
using Unity.Cinemachine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] CinemachineCamera cinemachineCamera;
    [SerializeField] GameObject[] rooms;
    [SerializeField] GameObject[] doors;
    [SerializeField] float playerYAdjustment;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            // go from kitchen to bedroom
            if (this.gameObject.name == "Door (To Bedroom K)")
            {
                cinemachineCamera.Follow = rooms[0].transform;

                // transfer player
                other.transform.position = doors[2].transform.position;
                other.transform.position = new Vector2(other.transform.position.x, other.transform.position.y - playerYAdjustment);
            }

            // go from bathroom to bedroom
            else if (this.gameObject.name == "Door (To Bedroom B)")
            {
                cinemachineCamera.Follow = rooms[0].transform;

                // transfer player
                other.transform.position = doors[3].transform.position;
                other.transform.position = new Vector2(other.transform.position.x, other.transform.position.y - playerYAdjustment);
            }

            // go from bedroom to kitchen
            else if (this.gameObject.name == "Door (To Kitchen)")
            {
                cinemachineCamera.Follow = rooms[1].transform;

                // transfer player
                other.transform.position = doors[0].transform.position;
                other.transform.position = new Vector2(other.transform.position.x, other.transform.position.y - playerYAdjustment);
            }

            // go from bedroom to kitchen
            else if (this.gameObject.name == "Door (To Bathroom)")
            {
                cinemachineCamera.Follow = rooms[2].transform;

                // transfer player
                other.transform.position = doors[1].transform.position;
                other.transform.position = new Vector2(other.transform.position.x, other.transform.position.y - playerYAdjustment);
            }
        }
    }
}
