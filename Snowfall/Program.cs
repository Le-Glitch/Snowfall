using System;
using System.Collections.Generic;
using Raylib_cs;

Raylib.InitWindow(800, 600, "Snowfall");
Raylib.SetTargetFPS(60);

List<Rectangle> snowflakes = new List<Rectangle>();
List<float> velocities = new List<float>();

Random gen = new Random();

for (int i = 0; i < 2000; i++)
{
    int x = gen.Next(Raylib.GetScreenWidth());
    int y = gen.Next(Raylib.GetScreenHeight());
    int size = gen.Next(2, 7);
    float speed = (float)(gen.NextDouble() + 0.5);

    velocities.Add(speed);
    snowflakes.Add(new Rectangle(x, y, size, size));
}

while (!Raylib.WindowShouldClose())
{

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.SKYBLUE);

    for (int i = 0; i < snowflakes.Count; i++)
    {
        Rectangle flake = snowflakes[i];
        flake.y += velocities[i];
        if (flake.y > 600)
        {
            flake.x = gen.Next(Raylib.GetScreenWidth());
            flake.y = -10;
        }

        snowflakes[i] = flake;


        Raylib.DrawRectangleRec(snowflakes[i], Color.WHITE);
    }

    Raylib.EndDrawing();

}