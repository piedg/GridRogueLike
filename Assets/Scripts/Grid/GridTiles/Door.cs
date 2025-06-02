using UnityEngine;

public class Door : Teleport
{
   [SerializeField] private Sprite doorOpen;
   [SerializeField] private Sprite doorClose;
   [SerializeField] SpriteRenderer _spriteRenderer;
   private bool _isOpen;

   public bool IsOpen => _isOpen;

   private void Start()
   {
      _spriteRenderer.sprite = doorClose;
   }

   public override void Use(Player player)
   {
      if (_isOpen)
      {
         base.Use(player);
      }
   }

   public void Open()
   {
      _isOpen = true;
      _spriteRenderer.sprite = doorOpen;
   }
}
