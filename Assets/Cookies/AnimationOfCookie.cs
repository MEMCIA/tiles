using System.Collections;
using UnityEngine;

public class AnimationOfCookie : MonoBehaviour
{
    Collectable _collectable;
    Rigidbody2D rb;
    bool doNotRepeat = false;
    Cookies cookiesScript;
    GameObject cookieUp;
    Vector3 startPosOfCookie;
    ParticleSystem ps;
    GameObject effects;
    Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        startPosOfCookie = transform.position;
        _collectable = GetComponent<Collectable>();
        rb = GetComponent<Rigidbody2D>();
        cookiesScript = GameObject.FindObjectOfType<Cookies>();
        cookieUp = transform.Find("CookieUp").gameObject;
        effects = GameObject.Find("Particle System");
        ps = effects.GetComponent<ParticleSystem>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();

    }

    void AnimateCookie()
    {
        if (!_collectable.isCookieFounded) return;
        if (doNotRepeat) return;
        if (playerScript.dead) return;
        cookieUp.GetComponent<SpriteRenderer>().sortingOrder = 11;
        GetComponent<SpriteRenderer>().sortingOrder = 10;
        doNotRepeat = true;
        StartCoroutine(MakeCookieLargerAndSmaller());
    }
    // Update is called once per frame
    void Update()
    {
        AnimateCookie();
    }
    IEnumerator RotateAndMoveCookie()
    {
        Vector3 aim = cookiesScript.shadowsOfCookieList[0];
        cookiesScript.shadowsOfCookieList.Remove(cookiesScript.shadowsOfCookieList[0]);
        Vector3 direction = aim - transform.position;
        direction.Normalize();
        effects.GetComponent<Renderer>().sortingOrder = 6;
        ps.Play();

        while ((transform.position.x != aim.x) && (transform.position.y != aim.y))
        {
            if (cookiesScript.shadowsOfCookieList.Count == 0)
            {
                playerScript.WinGame();
            }

            effects.transform.position = transform.position;
            transform.Translate(direction * Time.deltaTime * 90);
            cookieUp.transform.Rotate(Vector3.forward * 450 * Time.deltaTime);

            if (startPosOfCookie.x < aim.x)
            {
                if (transform.position.x > aim.x) transform.position = new Vector3(aim.x, transform.position.y);
            }
            if (startPosOfCookie.x > aim.x)
            {
                if (transform.position.x < aim.x) transform.position = new Vector3(aim.x, transform.position.y);
            }
            if (startPosOfCookie.y < aim.y)
            {
                if (transform.position.y > aim.y) transform.position = new Vector3(transform.position.x, aim.y);
            }
            if (startPosOfCookie.y > aim.y)
            {
                if (transform.position.y < aim.y) transform.position = new Vector3(transform.position.x, aim.y);
            }
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator MakeCookieLargerAndSmaller()
    {
        Vector3 startScale = transform.localScale;
        while (transform.localScale.x < startScale.x + 1)
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f, transform.localScale.z);
            yield return new WaitForSeconds(0.01f);
        }
        while (transform.localScale.x > startScale.x)
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f, transform.localScale.z);
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(RotateAndMoveCookie());
    }
}
