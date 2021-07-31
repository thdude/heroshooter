using Sandbox;

namespace HeroShooter
{
    partial class healer : HeroBasePlayer
    {
       public override void Respawn()
       {
            HeroModel = "models/citizen_props/wheel02.vmdl";
            base.Respawn();
       }
       public override void Simulate( Client cl )
       {
           base.Simulate( cl );
           if ( IsServer && Input.Pressed( InputButton.Attack1 ) )
			{
				var ragdoll = new ModelEntity();
				ragdoll.SetModel( "models/citizen_props/wheel02.vmdl" );  
				ragdoll.Position = EyePos + EyeRot.Forward * 40;
				ragdoll.Rotation = Rotation.LookAt( Vector3.Random.Normal );
				ragdoll.SetupPhysicsFromModel( PhysicsMotionType.Dynamic, false );
				ragdoll.PhysicsGroup.Velocity = EyeRot.Forward * 1000;
			}
       }

    }
}