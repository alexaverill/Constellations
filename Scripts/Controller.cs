using Godot;
using System;
using System.Collections.Generic;
public class Controller : Node2D
{
    [Export]
    public int leafNumber = 2;
    [Export]
    public float seperationDistance = 200; 
    
    private List<IndividualParticle> leaves = new List<IndividualParticle>();
    private List<Line2D> lines = new List<Line2D>();   
    public override void _Ready()
    {
        System.Random rand = new System.Random();
        //create our leaves
        var leafLoaded = (PackedScene)ResourceLoader.Load("res://Leaf.tscn");
        for(int x=0; x<leafNumber; x++){
            var leafInstance = (IndividualParticle)leafLoaded.Instance();
            AddChild(leafInstance);
            Vector2 newPosition = new Vector2((float)rand.NextDouble()*1000+10, (float)rand.NextDouble()*400+100);
            leafInstance.SetPosition(newPosition);
            leaves.Add(leafInstance);
        }
        
    }
 public override void _Process(float delta)
 {
     //clear old lines
     foreach(Line2D l in lines){
         l.ClearPoints();
         l.QueueFree();
     }
     lines.Clear();
     //calculate and draw all lines.
    for(int x = 0; x<leaves.Count; x++){
        for(int y=x; y<leaves.Count; y++){
            if(leaves[x].Position.DistanceTo(leaves[y].Position) < seperationDistance){
                //draw line
                Line2D newLine = new Line2D();
                newLine.AddPoint(leaves[x].Position);
                newLine.AddPoint(leaves[y].Position);
                newLine.SetWidth(2);
                AddChild(newLine);
                lines.Add(newLine);
            }
        }
    }
    //update all particles
    foreach(IndividualParticle i in leaves){
        i.update(delta);
    }
 }
}
