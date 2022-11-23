using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class dragclick : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private InputAction mouseClick;
    [SerializeField]
    private float mouseDragPhysicsSpeed = 10;
    [SerializeField]
    private float mouseDragSpeed = .1f;

    //private GameObject clickedObject;

    int i = 0;

    private Camera mainCamera;
    private Vector3 velocity = Vector3.zero;
    private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();


    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        mouseClick.Enable();
        mouseClick.performed += MousePressed;
    }

    private void OnDisable()
    {
        mouseClick.performed -= MousePressed;
        mouseClick.Disable();
    }

    private void MousePressed(InputAction.CallbackContext context)
    {

        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && (hit.collider.gameObject.CompareTag("Draggable")))
            {
                

                StartCoroutine(DragUpdate(hit.collider.gameObject));
                
                
            }
        }

    }

    private IEnumerator DragUpdate(GameObject clickedObject)
    {
        RaycastHit hit;
        float initialDistance = Vector3.Distance(clickedObject.transform.position, mainCamera.transform.position);
        clickedObject.TryGetComponent<Rigidbody>(out var rb);
        while (mouseClick.ReadValue<float>() != 0)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (rb != null)
            {
                

                Vector3 direction = ray.GetPoint(initialDistance) - clickedObject.transform.position;
                rb.velocity = direction * mouseDragPhysicsSpeed;
                yield return waitForFixedUpdate;

            }
            else
            {
                clickedObject.transform.position = Vector3.SmoothDamp(clickedObject.transform.position, ray.GetPoint
                    (initialDistance), ref velocity, mouseDragSpeed);

                yield return null;

                
            }

           // if (Physics.Raycast(ray, out hit))
            {

               // GameObject instantiatedobj = Instantiate(clickedObject);//, new vector3(2.0f, 0, 0), quaternion.identity);
                                                                   //    instantiatedobj.name = "myPrefab" + instantiatedobj.ToString();
                                                                   //   i++;

            }

            {
                //Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

            }
        }


    }
}
