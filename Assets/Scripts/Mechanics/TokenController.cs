using UnityEngine;

namespace Platformer.Mechanics
{

    public class TokenController : MonoBehaviour
    {
        [Tooltip("Frames per second at which tokens are animated.")]
        public float frameRate = 12;
        [Tooltip("Instances of tokens which are animated. If empty, token instances are found and loaded at runtime.")]
        public TokenInstance[] tokens;
        public int _TokenMax = 0;
        public int _TokenCurr = 0;
        float nextFrameTime = 0;
        public GameplayUIController _GameplayUIController;


        [ContextMenu("Find All Tokens")]
        void FindAllTokensInScene()
        {
            tokens = UnityEngine.Object.FindObjectsOfType<TokenInstance>();
        }

        void Awake()
        {

            if (tokens.Length == 0)
                FindAllTokensInScene();

            for (var i = 0; i < tokens.Length; i++)
            {
                tokens[i].tokenIndex = i;
                tokens[i].controller = this;
            }
            _TokenMax = tokens.Length;
            _GameplayUIController.SetTokens(_TokenMax, _TokenCurr);
        }

        void Update()
        {
            if (Time.time - nextFrameTime > (1f / frameRate))
            {

                for (var i = 0; i < tokens.Length; i++)
                {
                    var token = tokens[i];

                    if (token != null)
                    {
                        token._renderer.sprite = token.sprites[token.frame];
                        if (token.collected && token.frame == token.sprites.Length - 1)
                        {
                            token.gameObject.SetActive(false);
                            tokens[i] = null;
                        }
                        else
                        {
                            token.frame = (token.frame + 1) % token.sprites.Length;
                        }
                    }
                }
                nextFrameTime += 1f / frameRate;
            }
        }
        public void TokenCount(int diff)
        {
            _TokenCurr += diff;
            _GameplayUIController.SetTokens(_TokenMax, _TokenCurr);
        }
    }
}