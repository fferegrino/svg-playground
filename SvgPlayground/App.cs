using NControl.Abstractions;
using NGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SvgPlayground
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            var content = new ContentPage
            {
                Title = "SvgPlayground",
                Content = new NControlView
                {
                    DrawingFunction = (canvas, rect) =>
                    {
                        var boxLength = Math.Min(rect.Size.Width, rect.Size.Height);
                        var newY = Math.Max(rect.Size.Height, rect.Size.Width) / 2 - boxLength / 2;
                        var box = new Rect(rect.X, newY, boxLength, boxLength);
                        var innerBorder = box.Resize(-35);
                        var rectInsideInnerBorder = innerBorder.RectInsideEllipse();
                        var innerInnerBorder = box.Resize(-200);

                        var point = box.GetCenter();

                        var amarillo = NGraphics.Color.FromRGB(16706817);
                        var azul = NGraphics.Color.FromRGB(665162);

                        var lineSize = 25;

                        canvas.FillEllipse(box, amarillo); // base
                        canvas.DrawEllipse(innerBorder, azul, lineSize);

                        canvas.DrawLine(innerInnerBorder.TopLeft, rectInsideInnerBorder.TopLeft, azul, lineSize);
                        canvas.DrawLine(innerInnerBorder.TopRight, rectInsideInnerBorder.TopRight, azul, lineSize);
                        canvas.DrawLine(innerInnerBorder.BottomLeft, rectInsideInnerBorder.BottomLeft, azul, lineSize);
                        canvas.DrawLine(innerInnerBorder.BottomRight, rectInsideInnerBorder.BottomRight, azul, lineSize);

                        
                        var sizeH = new NGraphics.Size(innerInnerBorder.Width, innerInnerBorder.Height / 2);
                        var sizeV = new NGraphics.Size(innerInnerBorder.Width / 2, innerInnerBorder.Height);
                        canvas.DrawPath(
                            new PathOp[]
                            {
                                new MoveTo(innerInnerBorder.TopLeft),
                                new ArcTo( sizeH ,false, true, innerInnerBorder.TopRight),

                                new MoveTo(innerInnerBorder.TopRight),
                                new ArcTo( sizeV ,false, false, innerInnerBorder.BottomRight),

                                new MoveTo(innerInnerBorder.BottomRight),
                                new ArcTo( sizeH ,false, true, innerInnerBorder.BottomLeft),

                                new MoveTo(innerInnerBorder.BottomLeft),
                                new ArcTo( sizeV ,false, false, innerInnerBorder.TopLeft),

                                new MoveTo(innerInnerBorder.TopLeft),
                                new ClosePath ()
                            },
                            new Pen(azul, lineSize));


                        var megaEllipse = box.Resize(1000);
                    }
                }
            };

            MainPage = new NavigationPage(content);
        }



        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
