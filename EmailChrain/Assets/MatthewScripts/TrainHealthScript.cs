using UnityEngine;
using UnityEngine.UI;

public class TrainHealthScript : MonoBehaviour
{

    [SerializeField] Slider prefab;
    Canvas canvasObject;
    Slider hpBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasObject = (Canvas) FindFirstObjectByType(typeof(Canvas));

        hpBar = (Slider) Instantiate(prefab, new Vector3(0,0,0), Quaternion.Euler(0, 0, 0));
        hpBar.value = 1;
        hpBar.transform.SetParent(canvasObject.transform, false);

        Vector2 ViewportPosition=Camera.main.WorldToViewportPoint(this.transform.position);
        Vector2 WorldObject_ScreenPosition=new Vector2(
            ((ViewportPosition.x*canvasObject.GetComponent<RectTransform>().sizeDelta.x)-(canvasObject.GetComponent<RectTransform>().sizeDelta.x*0.5f)),
            ((ViewportPosition.y*canvasObject.GetComponent<RectTransform>().sizeDelta.y)-(canvasObject.GetComponent<RectTransform>().sizeDelta.y*0.5f)));

        hpBar.GetComponent<RectTransform>().anchoredPosition = WorldObject_ScreenPosition;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateHealth(float currHp, float maxHp) {
        print("yeouch");
        hpBar.value = currHp / maxHp;
    }
}
