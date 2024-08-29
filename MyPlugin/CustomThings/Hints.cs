/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;
using NotAnAPI;
using NotAnAPI.Features.UI.API.Elements;
using NotAnAPI.Features.UI.API.Enums;
using NotAnAPI.Features.UI.API.Abstract;
using NorthwoodLib.Pools;
using MapEditorReborn.Commands.ModifyingCommands.Position;
using MEC;

namespace MyPlugin.CustomThings
{
    public class HelloWorldElement : Element
    {
        public override string Name { get; set; } = "Hello World";
        public override string Text { get; set; } = "This will be overwroted";
        public override Vector2 Position { get; set; } = new Vector2(-500, 300);

        public override TextSettings Settings { get; set; } = new()
        {
            Size = 60,
        };

        public override UIScreenZone Zone { get; set; } = UIScreenZone.Center;
        public override UIType UI { get; set; } = UIType.Both;

        public override string OnRender()
        {
            //Position = new Vector2(UnityEngine.Random.Range(0, 301), UnityEngine.Random.Range(0, 301));
            Text = MyPlugin.Instance.SomeElement["MyEpicKey"];

            return base.OnRender();
        }
    }

    public class PersonalElementDisplay : GameElementDisplay
    {
        private readonly StringBuilder _builder;

        public PersonalElementDisplay(StringBuilder builder) : base(builder)
        {
            _builder = builder;
        }

        ~PersonalElementDisplay() => StringBuilderPool.Shared.Return(_builder);

        public override List<Element> Elements { get; set; } = new()
        {
            //Alive Elements
            new HelloWorldElement(),
        }; 
        
    }

    
}
*/