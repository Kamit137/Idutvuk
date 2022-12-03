using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Camera _fpcCamera;
    private Ray _ray;
    private RaycastHit _hit;
    public bool player_key = false;

    [SerializeField] private float _maxDistanceRay;

     void Update()
    {
        Ray();
        DrawRay();


        if (_hit.transform.GetComponent<Item_Key>())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _hit.transform.GetComponent<Item_Key>().Item();
                player_key = true;
                
            }
        }
        //---------------------------------------------
        if (_hit.transform.GetComponent<Door>())
        {
            if (Input.GetKeyDown(KeyCode.E)& (player_key == true))
            {
                _hit.transform.GetComponent<Door>().Open();
            }
        }
    }
    
    private void Ray()
    {
        _ray = _fpcCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }

    private void DrawRay()
    {
        if (Physics.Raycast(_ray, out _hit, _maxDistanceRay))
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.blue);
        }

        if (_hit.transform == null)
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.red);
        }
    }

    
}