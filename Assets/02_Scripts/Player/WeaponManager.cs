using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static List<Weapon> armasExistentes;
    float axis;
    GameObject player;
    [SerializeField]
    GameObject[] armas;
 
    void Awake()
    {
        player = GameObject.Find("Player");
        armasExistentes = new List<Weapon>();
        for(int i = 0;i<armas.Length;i++)
        {
            armasExistentes.Add(new Weapon(armas[i],armas[i].name));
        }
    }
    void Update()
    {
        if((axis = Input.GetAxis("Mouse ScrollWheel")) != 0)
        {
            if(axis > 0f)
            {
                player.GetComponent<WeaponChanger>().ChangeWeapon(1);
            } else if(axis<0f)
            {
                player.GetComponent<WeaponChanger>().ChangeWeapon(-1);
            }
        }
    }
}

public class Weapon
{
    public Weapon(GameObject objeto, string nome)
    {
        Objeto = objeto;
        Nome = nome;
    }

    public GameObject Objeto {get;set;}
    public string Nome {get;set;}
}
