using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialmanager : MonoBehaviour
{
    [SerializeField]
    public GameObject specialText;
    [SerializeField]
    public List<GameObject> specialchargeicons = new List<GameObject>();
    public int specialcharges;
    //singleton
    public static specialmanager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ChangeCharges(int change)
    {
        specialcharges += change;
        UpdateCharges(specialcharges);
    }

    public void UpdateCharges(int charges)
    {
        specialcharges = charges;
        if (specialcharges <= 0)
        {
            specialcharges = 0;
            specialText.SetActive(false);
            foreach (GameObject item in specialchargeicons)
            {
                item.SetActive(false);
            }

            //turn back into skeleton

            PlayerSuitManager.Instance.skeleton.transform.position = PlayerManager.playerObject.transform.position;
            PlayerSuitManager.Instance.skeleton.SetActive(true);
            PlayerSuitManager.Instance.skeleton.GetComponent<PlayerHitable>().SetHealth(PlayerManager.playerObject.GetComponent<PlayerHitable>().GetHealth());
            PlayerManager.virtualCamera.Follow = PlayerSuitManager.Instance.skeleton.transform;
            //PlayerSuitManager.Instance.ape.SetActive(false);
            PlayerSuitManager.Instance.alien.GetComponent<PlayerMovement>().AllowMove(true);
            PlayerSuitManager.Instance.alien.SetActive(false);


            return;
        }
        specialText.SetActive(true);
        if (specialcharges > 3)
        {
            specialcharges = 3;
        }

        foreach (GameObject item in specialchargeicons)
        {
            item.SetActive(false);
        }


        for (int i = 0; i < specialcharges; i++)
        {
            specialchargeicons[i].SetActive(true);
        }
    }
}
