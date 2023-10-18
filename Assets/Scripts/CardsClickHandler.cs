using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardsClickHandler : MonoBehaviour
{
    private Animator playerAnim;
    public Button SwordA1;

    public Button ArrowA1;

    public Image CardSlot1;
    void Start()
    {
        SwordA1.onClick.AddListener(swordAttack1Listener);
        playerAnim = GetComponent<Animator>();
    }


    public void swordAttack1Listener()
    {
        CardSlot1.sprite = SwordA1.image.sprite;
        //Input girilebilir
            swordAttack1();
        
    }

    public void swordAttack1()
    {
        playerAnim.SetBool("swordAtt1", true);
        StartCoroutine(endSwordAttack());
    }

    IEnumerator endSwordAttack()
    {
        yield return new WaitForSeconds(0.4f);
        playerAnim.SetBool("swordAtt1", false);

    }
}
