using System.Collections;
using UnityEngine;

public class CollectableAnimation : MonoBehaviour
{
    Collectable _collectable;
    Rigidbody2D rb;
    bool doNotRepeat = false;
    Collectables _collectables;
    CollectableSymbols _collectableSymbols;
    GameObject cookieUp;
    Vector3 startPosOfCollectable;
    ParticleSystem ps;
    GameObject effects;
    Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        _collectableSymbols = FindObjectOfType<CollectableSymbols>();
        startPosOfCollectable = transform.position;
        _collectable = GetComponent<Collectable>();
        rb = GetComponent<Rigidbody2D>();
        _collectables = FindObjectOfType<Collectables>();
        cookieUp = transform.Find("CookieUp").gameObject;
        effects = GameObject.Find("Particle System");
        ps = effects.GetComponent<ParticleSystem>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        StartAnimationOfCollectable();
    }

    void StartAnimationOfCollectable()
    {
        if (!_collectable.isCookieFounded) return;
        if (doNotRepeat) return;
        if (playerScript.dead) return;
        cookieUp.GetComponent<SpriteRenderer>().sortingOrder = 11;
        GetComponent<SpriteRenderer>().sortingOrder = 10;
        doNotRepeat = true;
        StartCoroutine(MakeCookieLargerAndSmaller());
    }
    
    IEnumerator RotateAndMoveCookie()
    {
        Vector3 aim = _collectableSymbols.SymbolsOfCollectable[0];
        _collectableSymbols.RemoveFirstCollectableFromList();
         Vector3 direction = aim - transform.position;
        direction.Normalize();

        while (transform.position != aim)
        {
            transform.Translate(direction * Time.deltaTime * 90);
            cookieUp.transform.Rotate(Vector3.forward * 450 * Time.deltaTime);
            CallibratePosition(aim);
            yield return new WaitForEndOfFrame();
        }
        StartParticleEffect();
    }

    void CallibratePosition(Vector3 aim)
    {
        if (startPosOfCollectable.x < aim.x)
        {
            if (transform.position.x > aim.x) transform.position = new Vector3(aim.x, transform.position.y);
        }
        if (startPosOfCollectable.x > aim.x)
        {
            if (transform.position.x < aim.x) transform.position = new Vector3(aim.x, transform.position.y);
        }
        if (startPosOfCollectable.y < aim.y)
        {
            if (transform.position.y > aim.y) transform.position = new Vector3(transform.position.x, aim.y);
        }
        if (startPosOfCollectable.y > aim.y)
        {
            if (transform.position.y < aim.y) transform.position = new Vector3(transform.position.x, aim.y);
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

    void StartParticleEffect()
    {
        effects.transform.position = transform.position;
        effects.GetComponent<Renderer>().sortingOrder = 12;
        ps.Play();
    }
}
