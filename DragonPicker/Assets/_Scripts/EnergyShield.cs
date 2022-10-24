using Newtonsoft.Json.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnergyShield : MonoBehaviour
{
    public TextMeshProUGUI scoreGT;
    private int score;
    private void Start()
    {
        var scoreGO = GameObject.Find("Score");
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
        scoreGT.text = "0";
    }
    void Update()
    {
        var mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        var mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        var pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var collided = collision.gameObject;
        if (collided.tag == "Dragon Egg")
        {
            Destroy(collided);
            score++;
            scoreGT.text = score.ToString();
        }
    }
}
