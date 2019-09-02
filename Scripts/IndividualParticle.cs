using Godot;
using System;

public class IndividualParticle : Sprite
{
    [Export]
    public Vector2 speed = new Vector2(100,100);
    [Export] 
    public Vector2 Bounds = new Vector2(800,600);
    System.Random randGenerator = new System.Random();
    private float SpeedScale = 50;
    public override void _Ready(){
        //randomize starting direction and speed;
        speed.x += (float)(randGenerator.NextDouble()*SpeedScale)-SpeedScale/2;
        speed.y += (float)(randGenerator.NextDouble()*SpeedScale)-SpeedScale/2;
    }
    public void update(float delta){
        if(Position.x -10 <0  || Position.x+10 > Bounds.x){
            speed.x *= -1;
        }
        if(Position.y-10 < 0 || Position.y+10 > Bounds.y){
            speed.y *=  -1;
        }
        Vector2 newPos = Position + (speed * delta);
        
        SetPosition(newPos);
    }
}
