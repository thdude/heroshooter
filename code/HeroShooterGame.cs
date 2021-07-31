
using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Threading.Tasks;

//
// You don't need to put things in a namespace, but it doesn't hurt.
//
namespace HeroShooter
{

	/// <summary>
	/// This is your game class. This is an entity that is created serverside when
	/// the game starts, and is replicated to the client. 
	/// 
	/// You can use this to create things like HUDs and declare which player class
	/// to use for spawned players.
	/// 
	/// Your game needs to be registered (using [Library] here) with the same name 
	/// as your game addon. If it isn't then we won't be able to find it.
	/// </summary>
	[Library( "heroshooter" )]
	public partial class HeroShooterGame : Sandbox.Game
	{
		public HeroShooterGame()
		{
			if ( IsServer )
			{
				Log.Info( "My Gamemode Has Created Serverside!" );

				// Create a HUD entity. This entity is globally networked
				// and when it is created clientside it creates the actual
				// UI panels. You don't have to create your HUD via an entity,
				// this just feels like a nice neat way to do it.
				new HeroShooterHud();
			}

			if ( IsClient )
			{
				Log.Info( "My Gamemode Has Created Clientside!" );
			}
		}

		/// <summary>
		/// A client has joined the server. Make them a pawn to play with
		/// </summary>
		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			var player = new PreSpawnPlayer();
			//var player = new runner();
			client.Pawn = player;

			player.Respawn();
		}
		
		public void SpawnPlayer( Client client, int Hero )
		{
			var player = new Player();
			player.Delete();
			//if(IsClient){return;}
			switch (Hero)
			{
				case 0:
					player = new runner();
					break;
				case 1:
					player = new healer();
					break;
				default:
					player = new runner();
					break;
			}
			
			client.Pawn = player;
			player.Respawn();
		}
	}

}
