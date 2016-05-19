using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Tutorial
{
    public class GameScreen
    {
        protected ContentManager content;
        [XmlIgnore]
        public Type Type;

        public string XmlPath;

        public GameScreen()
        {
            Type = this.GetType();
            XmlPath = "Load/" + Type.ToString().Replace("Tutorial.", "") + ".xml";
        }

        public virtual void Update(GameTime gameTime)
        {

        } 
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        } 
        public virtual void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
        } 
        public virtual void UnloadContent()
        {
            content.Unload();
        }
    }
}
