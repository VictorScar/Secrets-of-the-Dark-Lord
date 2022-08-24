using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class Finding : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] int count = 0;
    [SerializeField] float speed = 0.5f;
    [SerializeField] GameObject icond;
    [SerializeField] TMP_Text description;
    StringBuilder stringBuilder = new StringBuilder();
    [SerializeField] Camera cameraPlayer;
    [SerializeField] Inventory inventory;


    private void Start()
    {
        icond.GetComponent<SpriteRenderer>().sprite = item.Icon;
        stringBuilder.AppendLine("Название: " + item.name);
        stringBuilder.AppendLine("Атака: " + item.damage);
        stringBuilder.AppendLine("Защита: " + item.defence);
        stringBuilder.AppendLine("Стоимость: " + item.price);
        description.text = stringBuilder.ToString();
    }
    public void CollectItem()
    {
        StartCoroutine(AnimationCollect());
    }

    IEnumerator AnimationCollect()
    {
        while (transform.position != cameraPlayer.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, cameraPlayer.transform.position, speed * Time.deltaTime);
            if (transform.rotation != Quaternion.Euler(0, 180, 0))
            {
                transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
            }

            yield return null;

        }
    }
}
