using Laby.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Laby.Renderer
{
    public class Display : FrameworkElement
    {
        IGameModel model;
        Size size;

        public void Resize(Size size)
        {
            this.size = size;
        }

        public void SetupModel(IGameModel model)
        {
            this.model = model;
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (model != null && size.Width > 50 && size.Height > 50)
            {
                double rectWidth = size.Width / model.GameMatrix.GetLength(1);
                double rectHeight = size.Height / model.GameMatrix.GetLength(0);

                drawingContext.DrawRectangle(Brushes.White, new Pen(Brushes.White, 0),
                    new Rect(0, 0, size.Width, size.Height));

                for (int i = 0; i < model.GameMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < model.GameMatrix.GetLength(1); j++)
                    {
                        ImageBrush brush = new ImageBrush();
                        switch (model.GameMatrix[i, j])
                        {
                            case LabyLogic.LabyItem.player:                           
                                brush = new ImageBrush
                           (new BitmapImage(new Uri(Path.Combine("Images", "newRunner_01.gif"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.player2:
                                brush = new ImageBrush
                           (new BitmapImage(new Uri(Path.Combine("Images", "newRunner_02.gif"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.player3:
                                brush = new ImageBrush
                           (new BitmapImage(new Uri(Path.Combine("Images", "newRunner_03.gif"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.player4:
                                brush = new ImageBrush
                           (new BitmapImage(new Uri(Path.Combine("Images", "newRunner_04.gif"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.player5:
                                brush = new ImageBrush
                           (new BitmapImage(new Uri(Path.Combine("Images", "newRunner_05.gif"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.player6:
                                brush = new ImageBrush
                           (new BitmapImage(new Uri(Path.Combine("Images", "newRunner_06.gif"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.player7:
                                brush = new ImageBrush
                           (new BitmapImage(new Uri(Path.Combine("Images", "newRunner_07.gif"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.player8:
                                brush = new ImageBrush
                           (new BitmapImage(new Uri(Path.Combine("Images", "newRunner_07.gif"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.playerL:
                                brush = new ImageBrush
                           (new BitmapImage(new Uri(Path.Combine("Images", "newRunner_01L.gif"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.player2L:
                                brush = new ImageBrush
                           (new BitmapImage(new Uri(Path.Combine("Images", "newRunner_02L.gif"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.player3L:
                                brush = new ImageBrush
                           (new BitmapImage(new Uri(Path.Combine("Images", "newRunner_03L.gif"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.player4L:
                                brush = new ImageBrush
                           (new BitmapImage(new Uri(Path.Combine("Images", "newRunner_04L.gif"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.player5L:
                                brush = new ImageBrush
                           (new BitmapImage(new Uri(Path.Combine("Images", "newRunner_05L.gif"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.player6L:
                                brush = new ImageBrush
                           (new BitmapImage(new Uri(Path.Combine("Images", "newRunner_06L.gif"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.player7L:
                                brush = new ImageBrush
                           (new BitmapImage(new Uri(Path.Combine("Images", "newRunner_07L.gif"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.player8L:
                                brush = new ImageBrush
                           (new BitmapImage(new Uri(Path.Combine("Images", "newRunner_08L.gif"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.wall:
                                brush = new ImageBrush
                                    (new BitmapImage(new Uri(Path.Combine("Images", "wall.jpg"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.floor:
                                break;
                            case LabyLogic.LabyItem.door:
                                brush = new ImageBrush
                                    (new BitmapImage(new Uri(Path.Combine("Images", "exit.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.tank:
                                brush = new ImageBrush
                           (new BitmapImage(new Uri(Path.Combine("Images", "tank.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.tankR:
                                brush = new ImageBrush
                           (new BitmapImage(new Uri(Path.Combine("Images", "tankon.gif"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.tankL:
                                brush = new ImageBrush
                           (new BitmapImage(new Uri(Path.Combine("Images", "tankonL.gif"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.shield:
                                brush = new ImageBrush
                                    (new BitmapImage(new Uri(Path.Combine("Images", "shield.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.crater:
                                brush = new ImageBrush
                                    (new BitmapImage(new Uri(Path.Combine("Images", "crater.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.award:
                                brush = new ImageBrush
                                    (new BitmapImage(new Uri(Path.Combine("Images", "award.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.ammunition:
                                brush = new ImageBrush
                           (new BitmapImage(new Uri(Path.Combine("Images", "tankonL.gif"), UriKind.RelativeOrAbsolute)));
                                break;
                            default:
                                break;
                        }
                        drawingContext.DrawRectangle(brush
                                    , new Pen(Brushes.LightGreen, 0),
                                    new Rect(j * rectWidth, i * rectHeight, rectWidth, rectHeight)
                                    );                       
                    }
                }
                DrawAmmo(drawingContext);
                DrawShild(drawingContext);
            }
        }
        protected void DrawAmmo(DrawingContext drawingContext)
        {
            double poz = 0;
            ImageBrush brush = new ImageBrush();
            for (int i = 0; i < model.ammo; i++)
            {
                brush = new ImageBrush
               (new BitmapImage(new Uri(Path.Combine("Images", "ammo.png"), UriKind.RelativeOrAbsolute)));
                drawingContext.DrawRectangle(brush, new Pen(),
                                       new Rect(poz, 5, 70, 70)
                                       );
                poz += 40;
                
            }


        }
        protected void DrawShild(DrawingContext drawingContext)
        {
            if (model.shield)
            {
                ImageBrush brush = new ImageBrush();
                brush = new ImageBrush
                               (new BitmapImage(new Uri(Path.Combine("Images", "shieldON.png"), UriKind.RelativeOrAbsolute)));
                drawingContext.DrawRectangle(brush, new Pen(),
                                       new Rect(200, 10, 70, 70)
                                       );
            }

        }
    }
}
