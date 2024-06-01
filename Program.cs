using System.Security.Cryptography.X509Certificates;
using SplashKitSDK;

namespace SomethingAwesome
{
    
    public class Program
    {
        public static void Main()
        {
            //Initiate new window and load bitmap
            Window window= new Window("Animation", 600, 600);
            Bitmap sprite = new Bitmap("sprite", "spritesheet.png");
            // Define cells
            sprite.SetCellDetails(sprite.Width/4, sprite.Height/4, 4, 4, 16 );
            //Load animation script
            AnimationScript walkingScript = SplashKit.LoadAnimationScript("WalkingScript", "script.txt");
            //create new sprite and start animation
            Sprite character = SplashKit.CreateSprite(sprite, walkingScript);
            character.StartAnimation(0);
            //Event loop
            while(!window.CloseRequested)
            {
                window.Clear(Color.White);
                character.Draw();
                window.Refresh();
                character.UpdateAnimation();
                SplashKit.ProcessEvents();
                if (SplashKit.KeyTyped(KeyCode.UpKey))
                {
                    character.StartAnimation("walkbackward");
                }
                else if (SplashKit.KeyTyped(KeyCode.DownKey))
                {
                    character.StartAnimation("walkforward");
                }
                else if (SplashKit.KeyTyped(KeyCode.LeftKey))
                {
                    character.StartAnimation("walkleft");
                }
                else if (SplashKit.KeyTyped(KeyCode.RightKey))
                {
                    character.StartAnimation("walkright");
                }
                const int SPEED = 1;
                 if (SplashKit.KeyDown(KeyCode.UpKey))
                {
                    character.Y -= SPEED;
                }
                else if (SplashKit.KeyDown(KeyCode.DownKey))
                {
                    character.Y += SPEED;
                }
                else if (SplashKit.KeyDown(KeyCode.LeftKey))
                {
                    character.X -= SPEED;
                }
                else if (SplashKit.KeyDown(KeyCode.RightKey))
                {
                    character.X += SPEED;
                }
            StayOnWindow(window, character);
            }        
        }
        public static void StayOnWindow (Window window, Sprite character)
        {
            if (character.X <0) {character.X = 0;}
            if (character.Y <0) {character.Y = 0;}
            if (character.X > window.Width - character.Width) {character.X = window.Width - character.Width;}
            if (character.Y > window.Height- character.Height) {character.Y = window.Height - character.Height;}
        }
    }
}
