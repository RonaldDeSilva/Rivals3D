using UnityEngine;

public class CardBehavior : MonoBehaviour
{
    private bool FollowMouse = false;
    private GameObject Discard;
    private Rigidbody rb;
    public bool OverHand = true;

    void Start()
    {
        Discard = GameObject.Find("Discard");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (FollowMouse)
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z - 5));
            rb.position = mouseWorldPos;
        }
    }

    private void OnMouseDown()
    {
        if (transform.parent.name == "Position 1" || transform.parent.name == "Position 2" || transform.parent.name == "Position 3" || transform.parent.name == "Position 4" || transform.parent.name == "Position 5")
        {
            if (FollowMouse)
            {
                FollowMouse = false;
                if (!OverHand)
                {
                    //------------Do Card stuff here
                    //--
                    //--
                    //--
                    //--
                    //--------------------------------
                    transform.parent = Discard.transform; 
                    transform.localPosition = new Vector3(0, 0, 0);
                    transform.localRotation = new Quaternion(0, 0, 0, transform.rotation.w);
                }
                else
                {
                    transform.localPosition = new Vector3(0, 0, 0);
                    transform.localRotation = new Quaternion(0, 0, 0, transform.rotation.w);
                }
            }
            else
            {
                FollowMouse = true;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            OverHand = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            OverHand = true;
        }
    }
}
