using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class mmbutton : MonoBehaviour
{
    public GameObject myPrefab;
    int i = 0;

    private void Start()
    {
        
    }
    void FixedUpdate()


    {



        if

         (Input.GetButtonDown("Fire3"))
        

        {



             GameObject instantiatedobj = Instantiate(myPrefab);//, new vector3(2.0f, 0, 0), quaternion.identity);
            instantiatedobj.name = "myPrefab" + instantiatedobj.ToString();
            i++;
          
        }

    }

  
    }

