using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PaddleController : MonoBehaviour
{
    [Range(1.0f, 10.0f)]
    [SerializeField] float m_fSpeed = 2.0f;

    public static Vector3 dirVelocity { get; set; }

    private Rigidbody2D rigidbody2D;
    private PaddleMode lastedPaddle = PaddleMode.Limited;

    [SerializeField] bool isTouch = false;

    [SerializeField] Toggle toggle = null;

    public void onChangeedValue(bool state)
    {
        Debug.Log("실행이 되나");
        isTouch = state;
    }

    private void OnEnable()
    {
        Debug.Assert(toggle != null, "NullRef");
        rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(Loop());
    }
    IEnumerator Loop()
    {
        while (gameObject.activeInHierarchy)
        {
            isTouch = toggle.isOn;
            if (PaddleChanger.Instance.paddleMode != lastedPaddle)
            {
                PaddleChanger.OnChangePaddle(PaddleChanger.Instance.paddleMode);

                lastedPaddle = PaddleChanger.Instance.paddleMode;
            }

            switch (PaddleChanger.Instance.paddleMode)
            {
                case PaddleMode.Limited:
                    if (isTouch)
                    {
                        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        transform.localPosition = new Vector2(mousePos.x, transform.localPosition.y);
                    }
                    else
                    {
                        dirVelocity = Vector3.right * Input.GetAxisRaw("Horizontal") * m_fSpeed;
                        rigidbody2D.velocity = dirVelocity;
                    }
                    break;
                case PaddleMode.Freedom:
                    if (isTouch)
                    {
                        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        Debug.Log(mousePos);
                        transform.localPosition = new Vector2(mousePos.x, mousePos.y);
                    }
                    else
                    {
                        dirVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * m_fSpeed;
                        rigidbody2D.velocity = dirVelocity;

                        Debug.Log($"Width : {Screen.width * 2}, Height : {Screen.height * 2}");
                        transform.position =
                            new Vector2(
                                Mathf.Clamp(transform.position.x, -2.5f, 2.5f)
                                , Mathf.Clamp(transform.position.y, -5f, 5f));
                    }
                    break;
                default:
                    break;
            }
            yield return null;
        }
        yield return null;
    }
}
