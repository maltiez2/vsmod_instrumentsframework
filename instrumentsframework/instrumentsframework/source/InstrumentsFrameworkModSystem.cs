using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextPlayer;
using TextPlayer.ABC;
using Vintagestory.API.Common;

namespace InstrumentsFramework;

public class InstrumentsFrameworkModSystem : ModSystem
{
    private ICoreAPI? mApi;
    private Player? mPlayer;

    public override void Start(ICoreAPI api)
    {
        mApi = api;

        string filePath = "C:\\Users\\user\\Desktop\\abc\\ACDC - Highway to Hell.abc";

        mPlayer = new();

        using (StreamReader reader = new StreamReader(filePath))
        {
            mPlayer.Load(reader);
        }

        mPlayer.Play();

        if (api.Side == EnumAppSide.Server) api.World.RegisterGameTickListener(_ => mPlayer?.Update(), 0);
    }
}

public class Player : ABCPlayer
{
    public Player() : base(strict: false)
    {
        Settings.MaxSize = (int)1e5;
    }
    
    protected override void PlayNote(Note note, int channel, TimeSpan time)
    {
        Console.WriteLine($"{channel} - {note} - {time}");

        if (channel <= 1)
        {
            // length is halved because Console.Beep messes up using full length on consecutive notes
            Console.Beep((int)note.GetFrequency(), (int)(note.Length.TotalMilliseconds * 0.5));
        }
    }
}
