using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inv : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public Sprite[] GunIcons;
    public GameObject[] Weapons;
    public Vector3 scaleChangeMain;
    public Vector3 scaleChangeSec;
    public Transform Player;
    
    public Transform weaponHolder;

    private void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (isFull[i] == false)
                {

                    if (other.gameObject.name == "NerfItem" && isFull[0] == false)
                    {
                        Instantiate(Weapons[0], GameObject.Find("WeaponHolder").transform.position, Quaternion.identity, weaponHolder);
                        GameObject.Find("Gun1").GetComponent<Image>().sprite = GunIcons[1];
                    }

                    else if (other.gameObject.name == "NerfItem" && isFull[0] == true)
                    {
                        GameObject.Find("Gun2").GetComponent<Image>().sprite = GunIcons[1];
                    }

                    if (other.gameObject.name == "PistolItem" && isFull[0] == false)
                    {
                        Instantiate(Weapons[1], GameObject.Find("WeaponHolder").transform.position, Quaternion.identity, weaponHolder);
                        GameObject.Find("Gun1").GetComponent<Image>().sprite = GunIcons[2];
                    }

                    else if (other.gameObject.name == "PistolItem" && isFull[0] == true)
                    {
                        GameObject.Find("Gun2").GetComponent<Image>().sprite = GunIcons[2];
                    }

                    if (other.gameObject.name == "SwordItem" && isFull[0] == false)
                    {
                        Instantiate(Weapons[2], GameObject.Find("WeaponHolder").transform.position, Quaternion.identity, weaponHolder) ;
                        GameObject.Find("Gun1").GetComponent<Image>().sprite = GunIcons[3];
                    }

                    else if (other.gameObject.name == "SwordItem" && isFull[0] == true)
                    {
                        GameObject.Find("Gun2").GetComponent<Image>().sprite = GunIcons[3];
                    }
                    Destroy(other.gameObject);
                    isFull[i] = true;
                    break;
                }           
                

            }
        }


    }

}
