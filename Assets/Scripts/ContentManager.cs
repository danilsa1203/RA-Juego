using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ContentManager : MonoBehaviour
{
    public Toggle ButterflyToggle;
    public GameObject small;
    public GameObject big;
    private GameObject spawned;
    public Camera ARCamera;

    private List<RaycastResult> raycastResults = new List<RaycastResult>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = ARCamera.ScreenPointToRay(Input.mousePosition);

            if (IsPointerOverUI(Input.mousePosition))
            {

            }
            else
            {
                spawned = Instantiate(WhichButterfly(), ray.origin, Quaternion.identity);
                spawned.GetComponent<Rigidbody>().AddForce(ray.direction * 100);
            }

            
        }
        
    }

    public GameObject WhichButterfly()
    {
        if (ButterflyToggle.isOn)
        {
            return big;

        }
        else
            return small;
    }

    private bool IsPointerOverUI(Vector2 fingerPosition)
    {
        PointerEventData eventDataPosition = new PointerEventData(EventSystem.current);
        eventDataPosition.position = fingerPosition;
        EventSystem.current.RaycastAll(eventDataPosition, raycastResults);
        return raycastResults.Count > 0;
    }
}
