using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChanger : MonoBehaviour
{
    List<Weapon> armasAdquiridas;
    Weapon armaAtual;
    [SerializeField]
    GameObject Canvas;

    void Start()
    {
        armasAdquiridas = new List<Weapon>();
        armaAtual = WeaponManager.armasExistentes[0];
        armasAdquiridas.Add(armaAtual);
        ActivateWeapon();
    }
    void ActivateWeapon()
    {
        Transform weaponHolder = this.transform.Find("WeaponHolder");
        Transform mainSlot = Canvas.transform.Find("MainSlot");
        for(int i = 0; i < weaponHolder.childCount;i++)
        {
            weaponHolder.GetChild(i).gameObject.SetActive(false);
            mainSlot.GetChild(i).gameObject.SetActive(false);
        }
        armaAtual.Objeto.SetActive(true);
        mainSlot.Find(armaAtual.Nome).gameObject.SetActive(true);
    }
    public void ChangeWeapon(int direction)
    {
        int index = 0;
        if(armaAtual == null && armasAdquiridas.Count > 0)
        armaAtual = armasAdquiridas[0];
        if(direction > 0)
        {
            if((index = armasAdquiridas.IndexOf(armaAtual))<(armasAdquiridas.Count-1))
            {
                armaAtual = armasAdquiridas[index+1];
            } else
            {
                armaAtual = armasAdquiridas[0];
            }
        } else if(direction<0)
        {
            if((index = armasAdquiridas.IndexOf(armaAtual))>0)
            {
                armaAtual = armasAdquiridas[index-1];
            } else
            {
                armaAtual = armasAdquiridas[armasAdquiridas.Count-1];
            }
        }
        ActivateWeapon();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Item":
                if(armasAdquiridas.Count == 0 || armasAdquiridas.Find(arma => arma.Nome == col.gameObject.name) == null)
                {
                    Weapon armaColidida = WeaponManager.armasExistentes.Find(x=> x.Nome == col.gameObject.name);
                    armasAdquiridas.Add(armaColidida);
                    ActivateWeapon();
                }
                Destroy(col.gameObject);
            break;
            default: return;
        }
        ActivateWeapon();
    }
}
