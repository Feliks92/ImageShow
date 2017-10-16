using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace ImageShow
{
    public class Helper
    {
        public static int MaxImageHeight { get; set; }
        public static int MaxImageWidth { get; set; }
        public static int SlideTime { get; set; }
        
        // METODA DO KONWERSJI OBRAZKA DO BYTE
        public byte[] ImageToByte(Image myimage)
        {
            MemoryStream ms = new MemoryStream();
            myimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        
        // METODA DO WYŚWIETLENIA POKAZU SLAJDÓW
        public void ShowImages(List<int> IDlist, int time = 2000, int width = 800, int height = 600)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            Form imageform = new Form();
            imageform.StartPosition = FormStartPosition.CenterScreen;
            imageform.BackColor = Color.Black;
            imageform.FormBorderStyle = FormBorderStyle.None;
            imageform.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            imageform.KeyDown += new KeyEventHandler(esc_pushed);
            imageform.KeyDown += new KeyEventHandler(space_pushed);
            imageform.Shown += new EventHandler(image_shown);
            worker.DoWork += new DoWorkEventHandler(worker_show);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_completed);
            imageform.ShowDialog();

            bool nextimage = false;

            void image_shown(object sender, EventArgs e)
            {
                worker.RunWorkerAsync();
            }

            void worker_show(object sender, DoWorkEventArgs e)
            {
                nextimage = false;
                foreach (var ID in IDlist)
                {
                    

                    if (worker.CancellationPending == true)
                    {
                        break;
                    }
                    
                    using (var context = new ImageDBEntities())
                    {
                        var DBimage = context.Database.SqlQuery<byte[]>($"SELECT image FROM imagetable WHERE id={ID}").FirstOrDefault();

                        Image imagefromdb = Image.FromStream(new MemoryStream(DBimage));
                        
                        PictureBox pb = new PictureBox();
                        pb.SizeMode = PictureBoxSizeMode.Zoom;
                        pb.MaximumSize = new Size(width, height);
                        pb.Size = imagefromdb.Size;
                        pb.Image = imagefromdb;

                        DateTime dthen = DateTime.Now;
                        
                        imageform.Invoke((MethodInvoker)delegate
                        {
                            pb.Location = new Point((Screen.PrimaryScreen.Bounds.Width / 2) - (pb.ClientSize.Width / 2),
                                                    (Screen.PrimaryScreen.Bounds.Height / 2) - (pb.ClientSize.Height / 2));
                            
                            imageform.Controls.Add(pb);

                            while (dthen.AddMilliseconds(time) > DateTime.Now)
                            {
                                if (worker.CancellationPending||nextimage == true)
                                {
                                    
                                    break;
                                }
                                else
                                {
                                    Application.DoEvents();
                                }
                            }

                            nextimage = false;
                            pb.Dispose();
                        });
                    }
                }
            }

            void esc_pushed(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    worker.CancelAsync();
                }
            }

            void space_pushed(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Space)
                {
                    nextimage = true;
                }
            }

            void worker_completed(object sender, RunWorkerCompletedEventArgs e)
            {
                imageform.Dispose();
            }
            
        }


        // METODA PRZESZUKANIE I DODANIE DO BAZY DANYCH
        public void BrowseAndAdd()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                var imagelist = Directory.EnumerateFiles(fbd.SelectedPath, "*.jpg");

                ProgressBarForm bar = new ProgressBarForm(imagelist.Count());
                bar.Show();
                int i = 0;
                var worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(worker_addimages);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_completed);
                bar.FormClosing += new FormClosingEventHandler(progressbar_closing);
                worker.WorkerSupportsCancellation = true;
                worker.RunWorkerAsync();

                void progressbar_closing(object sender, FormClosingEventArgs e)
                {
                    e.Cancel = true;
                    worker.CancelAsync();
                    
                }
                
                void worker_addimages(object sender, DoWorkEventArgs e)
                {
                    
                    using (var context = new ImageDBEntities())
                    {

                        foreach (var imagename in imagelist)
                        {
                            if (worker.CancellationPending == true)
                            {
                                break;
                            }

                            Imagetable table = new Imagetable();
                            var image = Image.FromFile(imagename);

                            if ((image.Size.Width > MaxImageWidth) && (image.Size.Height > MaxImageHeight))
                            {
                                image = new Bitmap(image, MaxImageWidth, MaxImageHeight);
                            }

                            table.ID = i;
                            table.Name = "obrazek";
                            table.Image = ImageToByte(image);
                            context.Imagetables.Add(table);
                            context.SaveChanges();

                            bar.Invoke((MethodInvoker)delegate
                            {
                                bar.increment();
                                bar.progress(imagelist.Count(), ++i);
                            });

                        }

                    }

                }
                void worker_completed(object sender, RunWorkerCompletedEventArgs e)
                {
                    bar.Dispose();
                    if (i == imagelist.Count())
                    {
                        MessageBox.Show("All images loaded");
                    }
                    else
                    {
                        MessageBox.Show(i + "/" + imagelist.Count() + " images loaded");
                    }
                    
                }
            }

            else MessageBox.Show("Canceled");
        }
    }

}