using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class FindingCardEffect : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] SpriteRenderer iconSpriteRenderer;
    [SerializeField] int count = 0;
    [SerializeField] float speed = 0.5f;
    [SerializeField] TMP_Text descriptionText;
    StringBuilder stringBuilder = new StringBuilder();
    [SerializeField] Camera cameraPlayer;
    [SerializeField] Inventory inventory;


    private void Start()
    {
        iconSpriteRenderer.sprite = item.Icon;
        stringBuilder.Append("Название: ");
        stringBuilder.AppendLine(item.name);
        stringBuilder.Append("Атака: ");
        stringBuilder.AppendLine(item.damage.ToString());
        stringBuilder.Append("Защита: ");
        stringBuilder.AppendLine(item.defence.ToString());
        stringBuilder.Append("Стоимость: ");
        stringBuilder.AppendLine(item.price.ToString());
        descriptionText.text = stringBuilder.ToString();
    }
    public void CollectItem()
    {
        //StartCoroutine(AnimationCollect());
    }

    //IEnumerator AnimationCollect()
    //{
    //    while (transform.position != cameraPlayer.transform.position)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, cameraPlayer.transform.position, speed * Time.deltaTime);
    //        if (transform.rotation != Quaternion.Euler(0, 180, 0))
    //        {
    //            transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
    //        }

    //        yield return null;

    //    }
    //}
}
