using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiger : MonoBehaviour
{
    public void Die()
    {
        gameObject.SetActive(false);
        // 애니메이션 설정도 여기서 한다.
    }
}
