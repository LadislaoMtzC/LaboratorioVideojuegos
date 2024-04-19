using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PLAYGROUND
{
    public class VElement
    {

        public List<VPoint> VPoints;
        public List<VPole> VPoles;
        public float xMin,xMax,yMin,yMax;
        public float width,height;
        public int headCenterId;
        public int bodyCenterId;
        public bool knocked;
        public float maxTimeKnocked;
        public float timeKnocked;
        public bool defeated;
        List<Vec2> bodyPoints;
        Bitmap sumoNormalHead, sumoSleepHead;
        Brush brush;

        public VElement(Vec2 center, float height, float width, Brush brush) 
        {
            VPoints = new List<VPoint>();
            VPoles = new List<VPole>();
            xMin = center.X - width;
            xMax = center.X + width;
            yMin = center.Y + height;
            yMax = center.Y - height;
            this.width = width;
            this.height = height;
            headCenterId = 0;
            bodyCenterId = 0;
            knocked = false;
            timeKnocked = 0;
            maxTimeKnocked = 70;
            defeated = false;
            bodyPoints = new List<Vec2>();
            this.brush = brush;
            sumoNormalHead = Resource1.sumoNormal;
            sumoSleepHead = Resource1.sumoSleep;
        }

        public void addPoint(float x,float y,int id, bool pin, int sizeOfRadius,float mass, Vec2 gravity)
        {
            VPoints.Add(new VPoint(x, y, id, pin, sizeOfRadius,mass,gravity));
        }

        public void addPole(int i1, int i2, float length,float stiffness, Pen brush)
        {
            VPoles.Add(new VPole(VPoints[i1], VPoints[i2],length,stiffness,brush));

        }
        public void Render(System.Drawing.Graphics g, int Canvasw, int Canvash)
        {
            bodyPoints = new List<Vec2>();
            //render points
            for(int i = 0; i < VPoints.Count; i++)
            {
                //TEMPORAL PARA CAMBIAR EL COLOR CUANDO KNOCKEADO
                if (knocked && i <= headCenterId)
                {
                    VPoints[i].brush = new SolidBrush(Color.White);
                }
                else 
                {
                    VPoints[i].brush = new SolidBrush(Color.Orange);
                }
                VPoints[i].Render(Canvasw, Canvash, g, VPoints);
                if (VPoints[i].inFloor)
                {
                    defeated = true;
                }
                //Posicion cabeza con respecto a punto del centro
                xMin = VPoints[0].pos.X - width;
                xMax = VPoints[0].pos.X + width;
                yMin = VPoints[0].pos.Y + height;
                yMax = VPoints[0].pos.Y - height;


                if (i>bodyCenterId && i<headCenterId)
                {
                    bodyPoints.Add(VPoints[i].pos);
                }


            }
            Point[] points = bodyPoints.Select(p => new Point((int)p.X, (int)p.Y)).ToArray();
            g.FillPolygon(brush, points);

            //render poles
            for (int i = 0; i < VPoles.Count; i++)
            {
                VPoles[i].Render(g,Canvasw, Canvash);

            }

            //if knocked check if it can be not knocked
            if (knocked)
            {
                VPoints[headCenterId].pos.X = VPoints[bodyCenterId].pos.X;
                VPoints[headCenterId].pos.Y = VPoints[bodyCenterId].pos.Y - VPoints[bodyCenterId].radius - 30;
                timeKnocked++;
                if (timeKnocked >= maxTimeKnocked)
                {
                    knocked = false;
                    timeKnocked = 0;
                }
                g.DrawImage(sumoSleepHead, VPoints[headCenterId].pos.X-30, VPoints[headCenterId].pos.Y - 30, 60, 60);
            }
            else 
            {
                VPoints[headCenterId].pos.X = VPoints[bodyCenterId].pos.X;
                VPoints[headCenterId].pos.Y = VPoints[bodyCenterId].pos.Y - VPoints[bodyCenterId].radius - 40;
                g.DrawImage(sumoNormalHead, VPoints[headCenterId].pos.X-30, VPoints[headCenterId].pos.Y-30, 60, 60);
            }


        }
    }
}
