using Sandbox;
using System;
using System.Linq;

namespace HeroShooter
{
    public partial class PreSpawnPlayer : Player
    {
        public override void Respawn()
		{

			//SetModel( HeroModel );
			
			Controller = new UIController();
			Animator = new StandardPlayerAnimator();
			Camera = new FixedCamera();

			EnableAllCollisions = false;
			EnableDrawing = false;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = false;

			base.Respawn();
			/*
			Client client = Local.Pawn.GetClientOwner();
			var game = Game.Current as HeroShooterGame;
			game.SpawnPlayer(client, 1);
			Log.Info("myballs");
			*/
		}
        public override void Simulate( Client cl )
		{
			base.Simulate( cl );
			SimulateActiveChild( cl, ActiveChild );

			if ( IsServer && Input.Pressed( InputButton.Attack1 ) )
			{
				
			}
		}
		//REMOVED UNTIL I FIGURe OUT WHY I CANT SPAWN PLAYERS nvm keeping it so i can figure this out properly
		public void Select(int hero)
		{
			if(IsServer)
			{
				Client client = Local.Pawn.GetClientOwner();
				var game = Game.Current as HeroShooterGame;
				game.SpawnPlayer(client, hero);
			}
			
		}
		
    }
}