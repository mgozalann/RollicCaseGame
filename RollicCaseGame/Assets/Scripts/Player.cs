using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    float speed = 6f;
    public bool isMoving;
    Rigidbody rb;
    [SerializeField]
    Vector3 wireCube;
    [SerializeField]
    GameObject powerLeft, powerRight;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartingEvents();
    }

    public void StartingEvents()
    {
        powerLeft.SetActive(false);
        powerRight.SetActive(false);
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (powerLeft.activeInHierarchy == true)
        {
            powerLeft.transform.Rotate(new Vector3(0, 0, -360) * 1.5f * Time.deltaTime);
            powerRight.transform.Rotate(new Vector3(0, 0, 360) * 1.5f * Time.deltaTime);
        }
        Movement();
    }

    void Movement()
    {
        if (isMoving)
        {
            rb.velocity = Vector3.forward * speed; //Vector3.forward * speed * 50f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, wireCube);
    }

    void ObjeleriFýrlat()
    {

        Collider[] hitColliders = Physics.OverlapBox(transform.position, wireCube);
        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject.tag.Equals("Obje"))
                collider.GetComponent<Rigidbody>().velocity += Vector3.forward * 5f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("CarpismaCollider"))
        {
            Debug.Log("A");
            powerLeft.SetActive(false);
            powerRight.SetActive(false);
            isMoving = false;
            ObjeleriFýrlat();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("PowerUp"))
        {
            powerLeft.SetActive(true);
            powerRight.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }

    public void SizeUp()
    {

        isMoving = true;
        transform.localScale = new Vector3(transform.localScale.x * 1.05f, transform.localScale.y, transform.localScale.z * 1.05f);
    }

    public void BackToTheCheckPoint(Transform checkTrans)
    {
        transform.position = checkTrans.position;
        //sahneyi yeniden baþlatçak ve gerisindeki her þeyi baþarýyla geçmiþ sayýlacak
    }
}
