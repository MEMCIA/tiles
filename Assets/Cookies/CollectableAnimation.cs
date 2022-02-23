using System.Collections;
using UnityEngine;

public class CollectableAnimation : MonoBehaviour
{
    Collectable _collectable;
    Rigidbody2D rb;
    bool doNotRepeat = false;
    Collectables _collectables;
    CollectableSymbols _collectableSymbols;
    GameObject collectableUp;
    Vector3 startPosOfCollectable;
    ParticleSystem ps;
    GameObject effects;
    Player playerScript;
    float speed = 90;

    // Start is called before the first frame update
    void Start()
    {
        _collectableSymbols = FindObjectOfType<CollectableSymbols>();
        startPosOfCollectable = transform.position;
        _collectable = GetComponent<Collectable>();
        rb = GetComponent<Rigidbody2D>();
        _collectables = FindObjectOfType<Collectables>();
        collectableUp = transform.Find("CookieUp").gameObject;
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
        if (!_collectable.isCollectableFounded) return;
        if (doNotRepeat) return;
        if (playerScript.dead) return;
        collectableUp.GetComponent<SpriteRenderer>().sortingOrder = 11;
        GetComponent<SpriteRenderer>().sortingOrder = 10;
        doNotRepeat = true;
        StartCoroutine(AnimateCollectable());
    }
    
    IEnumerator RotateAndMoveCookie()
    {
        Vector3 aim = _collectableSymbols.SymbolsOfCollectable[0];
        _collectableSymbols.RemoveFirstCollectableFromList();
         Vector3 direction = aim - transform.position;
        direction.Normalize();

        while (transform.position != aim)
        {
            collectableUp.transform.Rotate(Vector3.forward * 450 * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, aim, Time.deltaTime * speed);
            yield return new WaitForEndOfFrame();
        }
        StartParticleEffect();
    }

    IEnumerator AnimateCollectable()
    {
        Vector3 startScale = transform.localScale;
        yield return AnimateScaleTo(new Vector3(transform.localScale.x+1,transform.localScale.y+1), 10);
        yield return AnimateScaleTo(startScale, -10);
        yield return StartCoroutine(RotateAndMoveCookie());
    }

    IEnumerator AnimateScaleTo(Vector3 targetScale, float speed)
    {
        while (transform.localScale != targetScale)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, 10 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    void StartParticleEffect()
    {
        effects.transform.position = transform.position;
        effects.GetComponent<Renderer>().sortingOrder = 12;
        ps.Play();
    }
}
