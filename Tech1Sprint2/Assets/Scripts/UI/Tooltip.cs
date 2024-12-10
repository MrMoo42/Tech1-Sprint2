using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]

public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    public Image headerImage;
    public TextMeshProUGUI descriptionField;

    public LayoutElement layoutElement;

    public int characterWrapLimit;

    public RectTransform rectTransform;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetText(string header, Sprite image, string description = "") {
        if (string.IsNullOrEmpty(header)) {
            headerField.gameObject.SetActive(false);
        } else { 
            headerField.gameObject.SetActive(true);
            headerField.text = header;
            headerImage.sprite = image;
        }

        descriptionField.text = description;

        int headerLength = headerField.text.Length;
        int descriptionLength = descriptionField.text.Length;

        layoutElement.enabled = (headerLength > characterWrapLimit || descriptionLength > characterWrapLimit) ? true : false;
    }

    private void Update() {
        if (Application.isEditor) {
            int headerLength = headerField.text.Length;
            int contentLength = descriptionField.text.Length;

            layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
        }

        Vector2 position = Input.mousePosition;

        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        rectTransform.pivot = new Vector2(pivotX, pivotY);
        transform.position = position;
        
    }
}
