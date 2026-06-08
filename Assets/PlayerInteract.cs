using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 3f;
    public KeyCode interactKey = KeyCode.E;
    public bool isUIOpen = false;
    
    private Transform holdPosition;
    private GameObject heldObject;
    private Rigidbody heldObjectRb;

    void Start()
    {
        // Create HoldPosition automatically as a child of the Camera
        GameObject holdPosObj = new GameObject("HoldPosition");
        holdPosObj.transform.SetParent(transform);
        holdPosObj.transform.localPosition = new Vector3(0, 0, 1.2f);
        holdPosObj.transform.localRotation = Quaternion.identity;
        holdPosition = holdPosObj.transform;
    }

    void Update()
    {
        if (isUIOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return;
        }

        if (Input.GetKeyDown(interactKey))
        {
            if (heldObject == null)
            {
                TryPickUp();
            }
            else
            {
                DropObject();
            }
        }
    }

    void TryPickUp()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.5f, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("Salter"))
            {
                GameManager gm = FindAnyObjectByType<GameManager>();
                if (gm != null)
                {
                    gm.isPowerOff = true;
                }

                TaskManager tm = FindAnyObjectByType<TaskManager>();
                if (tm != null)
                {
                    tm.CompleteTaskPower();
                }

                // EFSANE BAĞLANTI BURADA BAŞLIYOR
                // Şalter kutusunun içindeki SalterAnimasyonu scriptini buluyoruz
                SalterAnimasyonu animasyon = hit.collider.GetComponentInChildren<SalterAnimasyonu>();
                if (animasyon != null)
                {
                    animasyon.SalteriIndir(); // Animasyonu tetikliyoruz!
                }
                // EFSANE BAĞLANTI BURADA BİTİYOR

                Destroy(hit.collider);
                return;
            }

            if (hit.collider.CompareTag("Phone"))
            {
                PhoneSystem phone = hit.collider.GetComponent<PhoneSystem>();
                if (phone != null)
                {
                    phone.OpenPhoneUI();
                }
                return;
            }

            if (hit.collider.CompareTag("Interactable"))
            {
                heldObject = hit.collider.gameObject;
                heldObjectRb = heldObject.GetComponent<Rigidbody>();

                if (heldObjectRb != null)
                {
                    heldObjectRb.useGravity = false;
                    heldObjectRb.isKinematic = true;
                }

                heldObject.transform.SetParent(holdPosition);
                heldObject.transform.localPosition = Vector3.zero;
                heldObject.transform.localRotation = Quaternion.identity;
            }
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            heldObject.transform.SetParent(null);

            if (heldObjectRb != null)
            {
                heldObjectRb.useGravity = true;
                heldObjectRb.isKinematic = false;
            }

            heldObject = null;
            heldObjectRb = null;
        }
    }
}