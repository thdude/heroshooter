using Sandbox;
using System;
using System.Linq;

namespace HeroShooter
{
	partial class HeroBasePlayer : Player
	{
		public string HeroModel = "models/citizen/citizen.vmdl";
		public override void Respawn()
		{
			SetModel( "models/citizen/citizen.vmdl" );
			//SetModel( HeroModel );
			
			if(Controller == null) {Controller = new HeroController();}
			Animator = new StandardPlayerAnimator();
			Camera = new FirstPersonCamera();
			//var ViewModelEntity = new BaseViewModel();
			//ViewModelEntity.SetParent(this);

			

			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;

			base.Respawn();
		}

		/// <summary>
		/// Called every tick, clientside and serverside.
		/// </summary>
		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			//
			// If you have active children (like a weapon etc) you should call this to 
			// simulate those too.
			//
			SimulateActiveChild( cl, ActiveChild );

		}

		public override void OnKilled()
		{
			base.OnKilled();

			EnableDrawing = false;
		}
	}
}
