using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 데이터는 abstract로 구현, 결과물은 일반 클래스
/// </summary>

[CreateAssetMenu(fileName = "Potion", menuName = "Item/Item Data/Potion")]

public class PotionData : CountableData
{
    [SerializeField] private float _value; // 회복 수치

    public override Items Create()
    {
        //return new Potion(this);
        return null;
    }
}
