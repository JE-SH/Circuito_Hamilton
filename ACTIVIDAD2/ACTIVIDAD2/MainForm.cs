/*
 * Creado por SharpDevelop.
 * Usuario: JESH
 * Fecha: 06/03/2020
 * Hora: 07:59 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
//using System.Threading;


namespace ACTIVIDAD2
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		Bitmap bitm;
		List <Circle>LP;
		Graph g;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Agregar_imaenClick(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
			Image img = Image.FromFile(openFileDialog1.FileName);
			pictureBox1.Image = img;
			textBox1.Text="";
			textBoxH.Text="";
			
		}
		void AnalizarClick(object sender, EventArgs e)
		{
			Bitmap btm = new Bitmap(openFileDialog1.FileName);
			bitm = new Bitmap(openFileDialog1.FileName);
			LP = new List<Circle>();
			int cont=0;
			
			for(int y=0; y<bitm.Height;y++){
				for(int x=0; x<bitm.Width; x++)
				{
					Color c= btm.GetPixel(x,y);
					if(c.R!=255)
						if(c.G !=255)
							if(c.B !=255)
								if(c.R != 100)
									if(c.G != 100)
										if(c.B != 200)
							{
								Circle p = findCenter(x,y,btm);
								if(p.getX() != -1)
								{
									LP.Add(p);
									cont++;
								}
							}
				}
			}
			pictureBox1.Image =  btm;
/**/		g = new Graph(bitm,LP, pictureBox1);
			g.findConection();
			g.printVertexBox(textBox1);
			pictureBox1.Image = bitm;
		}
		
		Circle findCenter(int x,int y,Bitmap btm)
		{
			//Circle cir = new Circle();
			int xx,yy;
//centro
				for(xx = x;xx<btm.Width;xx++)
				{
					Color c = btm.GetPixel(xx,y);
					//c = btm.GetPixel(xx,y);
					if(c.R ==255)
						if(c.G ==255)
							if(c.B ==255)
								break;
				}
				xx--;
				float x_ar = (xx - x)/2;
				float xc = x+x_ar;
				for(yy =y;yy<btm.Height;yy++)
				{
					Color c = btm.GetPixel((int)Math.Round(xc),yy);
					if(c.R ==255)
						if(c.G ==255)
							if(c.B ==255)
								break;
				}
				yy--;
				float ym = (yy - y)/2;
				float yc = y+ym;
				
				int x_ce = (int)Math.Round(xc);
				int y_ce = (int)Math.Round(yc);
				Color co = btm.GetPixel(x_ce,y_ce);
				
				if(co.R ==0)
					if(co.G ==0)
						if(co.B==0)
//radio
				{
				int x1,x2;
		//-x
				for(x1=(int)Math.Round(xc);x1<btm.Width;x1--)
				{
					if(x1<0)
						break;
					Color c = btm.GetPixel(x1,(int)Math.Round(yc));
					if(c.R ==255)
						if(c.G ==255)
							if(c.B ==255)
								break;
				}
				x1++;
		//+x
				for(x2=(int)Math.Round(xc);x2<btm.Width;x2++)
				{
					Color c = btm.GetPixel(x2,(int)Math.Round(yc));
					if(c.R ==255)
						if(c.G ==255)
							if(c.B ==255)
								break;
				}
				x2--;
				float xt = xc-x1;
				float xtt = x2-xc;
				
				int xd = (int)Math.Round(xt+xtt);
				int yd = yy-y;	
				
				float r;
				ym = (int)Math.Round(ym);
				r = xt;
				if(xtt>xt)
					r=xtt;
				if(ym>r)
					r = ym;
				
				int rad = (int)Math.Round(r);
				
				if(xd-yd<11 && xd-yd >-11)
				{
					paintCircle(x_ce,y_ce,btm);
					return new Circle(x_ce,y_ce,rad+3);
				}
				//else
				return new Circle(-1,-1,-1);
				
				}
				//else
					//paintCircle(x_ce,y_ce,btm,Color.White);
					return new Circle(-1,-1,-1);
				
			}
		void paintCircle(int x, int y,Bitmap btm)
		{
				Color c1 = btm.GetPixel(x,y);

				for(int y1=y;y1<btm.Height;y1++)
				{
					if(y1<0)
						break;
					c1 = btm.GetPixel(x,y1);
					int x1,x2;
					
					if(c1.R ==255)
						if(c1.G ==255)
							if(c1.B ==255)
								break;
					//while(true)
					for(x1=x;x1<btm.Width;x1++)
					{
						
						/*if(x1<=0)
							break;
						if(x1>=btm.Width)
							break;*/
						c1 = btm.GetPixel(x1,y1);
						if(c1.R ==255)
							if(c1.G ==255)
								if(c1.B ==255)
									break;
						btm.SetPixel(x1,y1,Color.FromArgb(100,100,200));
					}
					//while(true)
					for(x2=x-1;x2<btm.Width;x2--)
					{
						if(x2<0)
							break;
						/*if(x2>=btm.Width)
						break;*/
						c1 = btm.GetPixel(x2,y1);
						if(c1.R ==255)
							if(c1.G ==255)
								if(c1.B ==255)
									break;
						btm.SetPixel(x2,y1,Color.FromArgb(100,100,200));
						
					}
				}
				//while(true)   y-
				for(int y2=y-1;y2<btm.Height;y2--)
				{
					if(y2<0)
						break;
					/*if(y2>=btm.Height)
						break;*/
					c1 = btm.GetPixel(x,y2);
					int x1=x-1,x2=x;
					if(c1.R ==255)
						if(c1.G ==255)
							if(c1.B ==255)
								break;
					//while(true)
					for(x1=x;x1<btm.Width;x1++)
					{
						/*if(x1<=0)
							break;
						if(x1>=btm.Width)
						break;*/
						c1 = btm.GetPixel(x1,y2);
						if(c1.R ==255)
							break;
						if(c1.G ==255)
							break;
						if(c1.B ==255)
							break;
						btm.SetPixel(x1,y2,Color.FromArgb(100,100,200));
					}
					//while(true)
					for(x2=x-1;x2<btm.Width;x2--)
					{
						if(x2<0)
							break;
						/*if(x2>=btm.Height)
						break;*/
						c1 = btm.GetPixel(x2,y2);
						if(c1.R ==255)
							break;
						if(c1.G ==255)
							break;
						if(c1.B ==255)
							break;
						btm.SetPixel(x2,y2,Color.FromArgb(100,100,200));
					}
				}
				pictureBox1.Image = btm;
			}
		void PictureBox1MouseClick(object sender, MouseEventArgs e)
		{
			double px = e.X;
			double py = e.Y;
			
				float k = (float)pictureBox1.Width / (float)bitm.Width ;
			float k2= (float)pictureBox1.Height/(float)bitm.Height ;
			
			if(k2<k)
				k=k2;
			
			double dx = (pictureBox1.Width - (k*bitm.Width))/2;
			double dy = (pictureBox1.Height- (k*bitm.Height))/2;
			int bx = (int)Math.Round((px - dx)/k);
			int by = (int)Math.Round((py - dy)/k);//
			
			Vertex ver = (g.belongs(bx,by));
			if(ver != null)
			{
				Graphics gr = Graphics.FromImage(bitm);
				Brush br = new SolidBrush(Color.Aqua);
				List<Vertex> v = new List<Vertex>();
				pictureBox1.Image = bitm;
				
				Hamilton ha = g.ffffindHa(ver);
				textBoxH.Text = "CIRCUITO HAMILTONIANO\r\n";
				
				if(ha != null)
				{
					v=ha.getHamilton();
					
					Circle O;
					Circle F;
					textBoxH.Text +="PESO: "+ ha.getW() + "\r\n["+v[0].getID()+"], ";
					for(int i=0; i<v.Count;i++)
						{
						string tt;
						O = v[i].getCircle();
						
						if(i+1 == v.Count){
							F = v[0].getCircle();
							tt=v[0].getID().ToString();
						}
						else{
						F = v[i+1].getCircle();
						tt=v[i+1].getID().ToString();
						
						}
						textBoxH.Text += "["+tt+"], ";
						
			float m;
			m = ((float)(F.getY()-O.getY())/(float)(F.getX()-O.getX()));
			float b = (O.getY()-m*O.getX());
			if(m>=-1 && m<=1)
			{
				if(O.getX()<F.getX())
				{
					for(int x_k = O.getX();x_k<F.getX();x_k++)
					{
						float y_k;
						if(O.getY() == F.getY())
							y_k = O.getY();
						else
							y_k = ( m*x_k +b);
						Bitmap B = new Bitmap(bitm);
						
						Graphics gs = Graphics.FromImage(B);
						Brush bru = new SolidBrush(Color.Red);
						gs.FillEllipse(bru, x_k-10,y_k-10,20,20);
						
						Thread.Sleep(1);
        				pictureBox1.Image=B;
						pictureBox1.Refresh();
						B.Dispose();
						
						x_k+=29;
					}
					//break;
				}
				else
				{
					for(int x_k = O.getX();x_k>F.getX();x_k--)
					{
						float y_k;
						if(O.getY() == F.getY())
							y_k = O.getY();
						else
							y_k = ( m*x_k +b);
						
						Bitmap B = new Bitmap(bitm);
						
						Graphics gs = Graphics.FromImage(B);
						Brush bru = new SolidBrush(Color.Red);
						gs.FillEllipse(bru, x_k-10,y_k-10,20,20);
						
						Thread.Sleep(1);
        				pictureBox1.Image=B;
						pictureBox1.Refresh();
						B.Dispose();
						
						x_k-=29;
					}
				}
			}
			else
			{
				if(O.getY()<F.getY())
				{
					for(int y_k = O.getY();y_k<=F.getY();y_k++)
					{
						float x_k;
						if(O.getX() == F.getX())
							x_k = O.getX();
						else
							x_k = ( y_k-b)/m;
						Bitmap B = new Bitmap(bitm);

						Graphics gs = Graphics.FromImage(B);
						Brush bru = new SolidBrush(Color.Red);
						gs.FillEllipse(bru, x_k-10,y_k-10,20,20);
						
						Thread.Sleep(1);
        				pictureBox1.Image=B;
						pictureBox1.Refresh();
						B.Dispose();
						
						y_k+=29;	
						}
				}
				else
				{
					for(int y_k = O.getY();y_k>F.getY();y_k--)
				{
					float x_k;
					if(O.getX() == F.getX())
						x_k = O.getX();
					else
						x_k = ( y_k-b)/m;
					
						Bitmap B = new Bitmap(bitm);
					
						Graphics gs = Graphics.FromImage(B);
						Brush bru = new SolidBrush(Color.Red);
						gs.FillEllipse(bru, x_k-10,y_k-10,20,20);
						
						Thread.Sleep(1);
        				pictureBox1.Image=B;
						pictureBox1.Refresh();
						B.Dispose();
						
						y_k-=29;	
					}
				}
			}
					}
				}
				else
					textBoxH.Text += "NO HAY CIRCUITO\r\n";
					
			}
		}
		
	public class Circle
	{
		int r;
		int x;
		int y;
		//int id;
		public Circle(int x, int y, int r/*,int id*/)
		{
			this.r = r;
			this.x = x;
			this.y = y;
			//this.id=id;
		}
		public int getX()
		{
			return x;
		}
		public int getY()
		{
			return y;
		}
		public int getR()
		{
			return r;
		}
		public bool pixelInCircle(int x, int y,Circle cir)
		{
			int a,b;
			//if (x<cir.x)
			a = Math.Abs(cir.x - x)+1;
			b = Math.Abs(cir.y - y)+2;
			int c = (cir.r)+4;
			if ((a*a)+(b*b)-(c*c)<=0)
				return true;
			return false;
		}
	}
		
	public class Graph
	{
		List<Vertex>VL;
		Bitmap bitgra;
		PictureBox pictureBox1;
		public Graph(Bitmap bitgra,List<Circle>CL, PictureBox pictureBox1)
		{
			this.bitgra = bitgra;
			this.pictureBox1 = pictureBox1;
			VL = new List<Vertex>();
			
			foreach (Circle ci in CL){
				Vertex v = new Vertex(ci,VL.Count+1);
				VL.Add(v);
			}
		}
		public void findConection()
		{
			float w =0;
			Vertex v1 = new Vertex(null,0);
			Vertex v2 = new Vertex(null,0);
			Graphics gra = Graphics.FromImage(bitgra);
			Pen pluma = new Pen(Color.FromArgb(100,100,200));
			Brush brush = new SolidBrush(Color.Aqua);
			//6
			for(int i=0; i<VL.Count; i++)//2+
			{				
				for(int j = i+1;j<VL.Count;j++)
				{
					Circle cir = VL[i].getCircle();
					Circle circl = VL[j].getCircle();
					float prp = inGraphConection(cir,circl);
					if(prp>=0)
						{
							gra.DrawLine(pluma,cir.getX(),cir.getY(),circl.getX(),circl.getY());
							Vertex v= new Vertex(cir,i);
							Edge ed = new Edge(VL[j],prp,VL[i]);
							Edge edg = new Edge(VL[i],prp,VL[j]);
							VL[i].addEdge(ed);
							VL[j].addEdge(edg);
							pictureBox1.Image = bitgra;				
					}
					//find pair vertex
					if(prp<=0)
					{
						float z1 = (circl.getX()-cir.getX());
						float z2 = (circl.getY()-cir.getY());
						prp=((float)Math.Sqrt((z1*z1)+(z2*z2)));
					}
					if(w<=0)
					{
						w=prp;
						v1=VL[i];
						v2=VL[j];
						
					}
					else 
						if(prp<w)
						{
							w=prp;
							v1=VL[i];
							v2=VL[j];
						}
				}//32
			}
			gra.FillEllipse(brush,v1.getCircle().getX(),v1.getCircle().getY(),
			                v1.getCircle().getR(),v1.getCircle().getR());
			gra.FillEllipse(brush,v2.getCircle().getX(),v2.getCircle().getY(),
			                v2.getCircle().getR(),v2.getCircle().getR());
			
			
		}
		float inGraphConection(Circle O, Circle F)
		{
			float m;
			int q;
			m = ((float)(F.getY()-O.getY())/(float)(F.getX()-O.getX()));//10
			float b = (O.getY()-m*O.getX());//5
			if(m>=-1 && m<=1)//4
			{
				if(O.getX()<F.getX())//3
				{
					q=O.getX();//2
					for(int x_k = O.getX();x_k<F.getX();x_k++)//2+
					{
						float y_k;
						if(O.getY() == F.getY())
							y_k = O.getY();
						else
							y_k = ( m*x_k +b);
						if(q!=x_k)
						{
							q=x_k;
							x_k-=1;
						}
						
						Color c = bitgra.GetPixel((x_k),(int)Math.Round(y_k));
						
					if(c.R == 255 && c.G == 255 && c.B == 255){
						}
						else if(c.R != 100)
							if(c.G != 100)
								if(c.B != 200)
									if(!O.pixelInCircle(x_k,(int)y_k,O))
										if(!O.pixelInCircle(x_k,(int)y_k,F))
																		return -1;
					}
					float z1 = (F.getX()-O.getX());
					float z2 = (F.getY()-O.getY());
					return((float)Math.Sqrt((z1*z1)+(z2*z2)));
				}
				else
				{
					q=O.getX();
					for(int x_k = F.getX();x_k<O.getX();x_k++)
					{
						float y_k;
						if(O.getY() == F.getY())
							y_k = O.getY();
						else
							y_k = ( m*x_k +b);
						
						if(q!=x_k)
						{
							q=x_k;
							x_k-=1;
						}
						
						Color c = bitgra.GetPixel((x_k),(int)Math.Round(y_k));
						if(c.R == 255 && c.G == 255 && c.B == 255){
						}
						else if(c.R != 100)
							if(c.G != 100)
								if(c.B != 200)
									if(!O.pixelInCircle(x_k,(int)y_k,F))
														if(!O.pixelInCircle(x_k,(int)y_k,O))
															return -1;
						
					}
					float z1 = (F.getX()-O.getX());
					float z2 = (F.getY()-O.getY());
					return((float)Math.Sqrt((z1*z1)+(z2*z2)));
				}
			}
			else
			{
				if(O.getY()<F.getY())
				{
					q=O.getY();
					
					for(int y_k = O.getY();y_k<=F.getY();y_k++)
					{
						float x_k;
						if(O.getX() == F.getX())
							x_k = O.getX();
						else
							x_k = ( y_k-b)/m;
						
						if(q!=y_k)
						{
							q=y_k;
							y_k-=1;
						}
							
						
						Color c = bitgra.GetPixel((int)Math.Round(x_k),(y_k));
						if(c.R == 255 && c.G == 255 && c.B == 255){
						}
						else if(c.R != 100)
							if(c.G != 100)
								if(c.B != 200)
									if(!O.pixelInCircle((int)x_k,y_k,F))
										if(!O.pixelInCircle((int)x_k,y_k,O))
										
														return -1;
						}
					float z1 = (F.getX()-O.getX());
					float z2 = (F.getY()-O.getY());
					return((float)Math.Sqrt((z1*z1)+(z2*z2)));
				}
				else
				{
					q=O.getY();
					
					for(int y_k = F.getY();y_k<=O.getY();y_k++)
				{
					float x_k;
					if(O.getX() == F.getX())
						x_k = O.getX();
					else
						x_k = ( y_k-b)/m;
					
					if(q!=y_k){
						q=y_k;
						y_k-=1;
					}
					
					Color c = bitgra.GetPixel((int)Math.Round(x_k),(y_k));
					if(c.R == 255 && c.G == 255 && c.B == 255){
						}
						else if(c.R != 100)
							if(c.G != 100)
								if(c.B != 200)
									if(!O.pixelInCircle((int)x_k,y_k,O))				
										if(!O.pixelInCircle((int)x_k,y_k,F))
											return -1;
						
					}
					float z1 = (F.getX()-O.getX());
					float z2 = (F.getY()-O.getY());
					return((float)Math.Sqrt((z1*z1)+(z2*z2)));
				}
			}
		}
		
		public void printVertexBox(TextBox vertexbox)
		{
			Graphics gra = Graphics.FromImage(bitgra);
			
			Brush bru = new SolidBrush(Color.Orange);
			vertexbox.Text = "**CLOSEST PAIR POITS COLOR AQUA**\r\nCONECCIONES\r\n";
			for(int i = 0;i<VL.Count;i++)
			{
				Font font = new Font(FontFamily.GenericSansSerif,VL[i].getCircle().getR(),FontStyle.Bold,GraphicsUnit.Pixel);
				VL[i].printEdge(vertexbox,VL[i]);
				vertexbox.Text +="\r\n";
				gra.DrawString((i+1).ToString(),font,bru,VL[i].getCircle().getX(),VL[i].getCircle().getY());
			}
		}
		
		
		public Vertex belongs(int x, int y)/**/
		{
			for(int i = 0; i<VL.Count;i++)
			{
				if ((y - VL[i].getCircle().getY())*(y - VL[i].getCircle().getY())+ 
				    (x - VL[i].getCircle().getX())*(x - VL[i].getCircle().getX())-
				    (VL[i].getCircle().getR())*(VL[i].getCircle().getR()) <=0  )
					return VL[i];
			}
			return null;
		}
		public Hamilton ffffindHa(Vertex v)
		{
			return v.findHamilton(v,VL);
			
		}
		}
		
	public class Vertex
	{
		Circle data;
		int id;
		List<Edge>EL;
		
		public Vertex(Circle data,int id)
		{
			EL = new List<Edge>();
			this.data=data;
			this.id=id;
		}
		public void addEdge(Edge ed)
		{
			//Edge ed = new Edge(destino,weigth);
			EL.Add(ed);
		}
		public Circle getCircle()
		{
			return data;
		}
		public int getID()
		{
			return id;
		}
		
		public void printEdge(TextBox text, Vertex v)
		{
			text.Text += "["+v.getID()+"] => ";
			for(int i = 0;i<EL.Count;i++)
				{
				text.Text += "["+EL[i].getVertex().getID()+", ("+EL[i].getW()+")]";
				}	
		}
		
		public Hamilton findHamilton(Vertex v, List<Vertex>vl)
		{
			
			List<Hamilton>hl = new List<Hamilton>();
			Hamilton ha;
			//float W=0;
			List<Vertex>vis= new List<Vertex>();
			int kk=0;
			Stack<int>capa=new Stack<int>();
			List<Vertex>vert=new List<Vertex>();//vertices a partir de un punto (vertices totales a partir de v)
			
			vert.Add(v);
			Vertex act = v;
			//int ccc=0;
			//7
				while(true)
				{
					//ccc++;
					if (act == v)
					{
						if(capa.Count>0)
							if(vis.Count == vl.Count)//vl.Count)//vert.Count)
							{
								ha = new Hamilton(new List<Vertex>(vis),capa);
								hl.Add(ha);
								act = vis[vis.Count-1];//count -1
								//W = W-act.EL[capa.Peek()].getW();
								vis.RemoveAt(vis.Count-1);
								
								kk = capa.Peek();
								capa.Pop();
								kk++;
							}
							else 
							{
								act = vis[vis.Count-1];//count -1
								//W = W-act.EL[capa.Peek()].getW();
								kk = capa.Peek();
								capa.Pop();
								vis.RemoveAt(vis.Count-1);
								kk++;
							}
					}
				//} SALIR DEL WHILE
				if(act.EL.Count <= 1)
				{
					hl = null;
					break;
				}
				//------------------
				int ban = 0, sa = 0;
				//.....
				while(true)
				{
				if(kk >= act.EL.Count)
					
				{
					if(capa.Count==0)
					{
						ban=3;
						break;
					}
					else 
						act=vis[vis.Count-1];
					
					//W = W-act.EL[capa.Peek()].getW();
					
					kk = capa.Peek();
					capa.Pop();
					if(act == null)
						if(capa.Count == 0)
							break;
					vis.RemoveAt(vis.Count-1);
					kk++;
				}
				else 
					break;
				}
				//.....
				if(ban==3)
					break;
				
				if(vis.Count!=0)
					if(vis[vis.Count-1] == act)
					{
						ban=2;
					}
					else{
						for(int i =0;i<vert.Count;i++)
						{
							if(vert[i] == act)
								sa = 1;
						}
						if(sa!=1)
							vert.Add(act);
						for (int i=0; i<vis.Count;i++)
						{
							if(act == vis[i])
							{
								ban = 1;
								break;//------
							}
						}
					}
				if(ban ==  0)
				{
					capa.Push(kk); //fin capa/inicia nueva
					vis.Add(act);
					//^- antes del cambio
					act = act.EL[kk].getVertex();
					kk=0;
				}
				else//ban1
				{
					act = vis[vis.Count-1];
					kk = capa.Peek();
					capa.Pop();
					vis.RemoveAt(vis.Count-1);
					kk++;
				}
			}
				if(hl == null)
					return null;
				if (hl.Count == 0)
					return null;
				
				ha = null;
				float weight=0;
				
				for (int i = 0; i<hl.Count;i++)
				{
					if(hl[i].getCount() == vl.Count)
					{
						float w=0;
						Stack<int>nevo = new Stack<int>(hl[i].getHilo());
						List<Vertex>hamilt = new List<Vertex> (hl[i].getHamilton());
						for(int j=nevo.Count-1;j>=0;j--)
						{
							w+= hamilt[j].EL[nevo.Peek()].getW();
							nevo.Pop();
						}
						if(ha == null)
						{
							ha=hl[i];
							weight = w;
						}
							
						if(w<weight)
						{
							ha=hl[i];
							weight = w;
						}
					}
				}
				ha.setW(weight);
				hl.Clear();
				return ha;
		}
	}
	
	public class Edge
	{
		Vertex d;
		float w;
		Vertex o;
		public Edge(Vertex d, float w,Vertex o)
		{
			this.d=d;
			this.w=w;
			this.o = o;
		}
		public Vertex getVertex()
		{
			return d;
		}
		public float getW()
		{
			return w;
		}
	}
	public class Hamilton
	{
		List<Vertex>HL;
		Stack<int> hilo;
		float W;

		
		public Hamilton(List<Vertex>HL, Stack<int> hilo)
		{
			this.HL = HL;
			this.hilo = new Stack<int>(hilo);
		}
		public List<Vertex> getHamilton()
		{
			return HL;
		}
		public int getCount()
		{
			return HL.Count;
		}
		public Stack<int> getHilo()
		{
			return hilo;
		}
		public void setW(float value)
		{
			W=value;
		}
		public float getW()
		{
			return W;
		}
	}
	}
}
