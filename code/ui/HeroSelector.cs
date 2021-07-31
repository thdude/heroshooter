using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System.Threading.Tasks;

namespace HeroShooter
{
    class HeroSelector : Panel
    {
        private Panel canvas;
        private Button choice1;
        private Button choice2;
        private Button choice3;
        private Button choice4;
        public HeroSelector()
        {
            StyleSheet.Load( "/ui/HeroMenu.scss" );
            Log.Info("eyyesv EYEYYEYEAASAS");
            AddClass( "showCursor" );

            canvas = Add.Panel("container");
            //canvas.Add.Label("COCK HAAHAHA");
            choice1 = canvas.Add.Button("runner", "choice", SelectHero1);
            choice2 = canvas.Add.Button("healer", "choice", SelectHero2);
            choice3 = canvas.Add.Button("tank", "choice");
            choice4 = canvas.Add.Button("builder", "choice");
        }
        private void SelectHero1()
        {
            SpawnHero(0);
        }
        private void SelectHero2()
        {
            SpawnHero(1);
        }
        private void SpawnHero( int hero ) 
        {        
            (Local.Pawn as PreSpawnPlayer).Select(hero);
            
            AddClass("lockCursor");      
            var RootPanel = Local.Hud;

            RootPanel.DeleteChildren();
            RootPanel.AddChild<ChatBox>();
			RootPanel.AddChild<KillFeed>();
			RootPanel.AddChild<Scoreboard<ScoreboardEntry>>();
			RootPanel.AddChild<Health>();
            
        }
    }
}