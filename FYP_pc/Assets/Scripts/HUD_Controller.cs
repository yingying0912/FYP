using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Controller : MonoBehaviour
{
    [SerializeField] Image playerHealth;
    [SerializeField] Image playerCharge;
    [SerializeField] Image enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth.fillAmount = (float)PlayerBehaviour.currentHp / (float)PlayerBehaviour.maxHP;
        enemyHealth.fillAmount = (float)EnemyBehaviour.enemyCurrentHP / (float)EnemyBehaviour.enemyHP;
        playerCharge.fillAmount = (float)ChargeEnergy.currentCharge / (float)ChargeEnergy.maxCharge;
    }
}
