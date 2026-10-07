using UnityEngine;

public class CubeController : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "greenBullet" && this.gameObject.tag == "Green")
        {
            //destroy
        }
        else if (collision.gameObject.tag == "redBullet" && this.gameObject.tag == "Red")
        {
            //destroy me
        }
    }
}
