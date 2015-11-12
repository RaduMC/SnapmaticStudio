using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web.UI;
using System.Web.Script.Serialization;

namespace SnapmaticStudio
{
    public partial class Form1 : Form
    {
        public class Snap
        {
            public string filePath;
            public string title;
            public string fileName;
            public DateTime date;
            public bool chekd;
            public bool sel;
            public string imageFormat;
            public string rawJSON;
            public string description;
            public snapJSON deserializedJSON;
        }

        public class snapJSON
        {
            public snapLocation loc { get; set; }
            public string area { get; set; }
            public long street { get; set; }
            public string nm { get; set; }
            public string rds { get; set; }
            public string scr { get; set; }
            public string sid { get; set; }
            public long crewid { get; set; }
            public string mid { get; set; }
            public string mode { get; set; }
            public bool meme { get; set; }
            public bool mug { get; set; }
            public long uid { get; set; }
            public snapTime time { get; set; }
            public long creat { get; set; }
            public bool slf { get; set; }
            public bool drctr { get; set; }
        }

        public class snapLocation
        {
            public float x { get; set; }
            public float y { get; set; }
            public float z { get; set; }
        }

        public class snapTime
        {
            public int hour { get; set; }
            public int minute { get; set; }
            public int second { get; set; }
            public int day { get; set; }
            public int month { get; set; }
            public int year { get; set; }
        }


        private List<Snap> snapList = new List<Snap>();
        private bool isTitleSorted = false;
        private bool isFileSorted = false;
        private bool isDateSorted = false;
        private bool sortingNow = false;


        public Form1()
        {
            InitializeComponent();

            titleAsFilenameMenuItem.Checked = (bool)Properties.Settings.Default["titleAsFilename"];
            metadataExportMenuItem.Checked = (bool)Properties.Settings.Default["metadataExport"];
            fitImageMenuItem.Checked = (bool)Properties.Settings.Default["fitImage"];
            metadataOverlayMenuItem.Checked = (bool)Properties.Settings.Default["metadataOverlay"];
            datetimeFilenamesMenuItem.Checked = (bool)Properties.Settings.Default["datetimeFilename"];
        }

        private void loadProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Load all Snapmatic pictures from profile folder";
            folderBrowserDialog1.ShowNewFolderButton = false;
            folderBrowserDialog1.SelectedPath = getProfilePath();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                clearItems();

                string[] fileNames = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "PGTA*.", SearchOption.TopDirectoryOnly);
                loadSnaps(fileNames);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Snapmatic picture|PGTA*";
            //openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loadSnaps(openFileDialog1.FileNames);
            }
        }


        private void loadSnaps(string[] fileArr)
        {
            foreach (var snapFile in fileArr)
            {
                using (BinaryReader reader = new BinaryReader(File.OpenRead(snapFile)))
                {
                    int magicNumber = reader.ReadInt32();
                    if (magicNumber == 0x01000000)
                    {
                        Snap newSnap = new Snap();
                        newSnap.filePath = snapFile;
                        newSnap.fileName = Path.GetFileName(snapFile);

                        reader.BaseStream.Position += 256; //Unicode string with padding
                        int crc = reader.ReadInt32();
                        int eof = (int)reader.BaseStream.Position + reader.ReadInt32();
                        int jsonOffset = 264 + reader.ReadInt32();
                        int titleOffset = 264 + reader.ReadInt32();
                        int descOffset = 264 + reader.ReadInt32();
                        int imageMarker = reader.ReadInt32();
                        int bufferSize = reader.ReadInt32();
                        int imageSize = reader.ReadInt32();

                        switch (imageMarker)
                        {
                            case 1195724874:
                                newSnap.imageFormat = "JPEG";
                                break;
                            default:
                                newSnap.imageFormat = "Unknown";
                                break;
                        }

                        reader.BaseStream.Position = jsonOffset;
                        int jsonMarker = reader.ReadInt32(); //"JSON"
                        int jsonLength = reader.ReadInt32();
                        newSnap.rawJSON = ReadStringToNull(reader); //rest is random filler data

                        JavaScriptSerializer JSONserializer = new JavaScriptSerializer();
                        newSnap.deserializedJSON = JSONserializer.Deserialize<snapJSON>(newSnap.rawJSON);

                        newSnap.date = UnixTimeStampToDateTime(newSnap.deserializedJSON.creat);

                        reader.BaseStream.Position = titleOffset;
                        int titleMarker = reader.ReadInt32(); //"TITL"
                        int titleLength = reader.ReadInt32();
                        newSnap.title = ReadStringToNull(reader);

                        reader.BaseStream.Position = descOffset;
                        int descMarker = reader.ReadInt32(); //"DESC"
                        int descLength = reader.ReadInt32();
                        newSnap.description = ReadStringToNull(reader);

                        snapList.Add(newSnap);
                    }
                }
            }

            buildListView(snapList);
            StatusStripUpdate(string.Format("Finished loading {0} {1}", fileArr.Length, fileArr.Length == 1 ? "file" : "files")); 
        }
        
        private void buildListView(List<Snap> loadedList)
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            //potential issue: the list is always completely reiterated instead of parsing only new items

            foreach (var snapItem in loadedList)
            {
                ListViewItem newItem = new ListViewItem(new string[] { snapItem.title, snapItem.fileName, snapItem.date.ToString() });
                newItem.Checked = snapItem.chekd;
                newItem.Selected = snapItem.sel;
                listView1.Items.Add(newItem);
            }

            listView1.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
            resizeTitleColumn();
            listView1.EndUpdate();
        }


        private Image previewSnap(string snapFile)
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(snapFile)))
            {
                reader.BaseStream.Position = 288;
                int imageSize = reader.ReadInt32();

                byte[] imageBuffer = reader.ReadBytes(imageSize);
                MemoryStream imageStream = new MemoryStream(imageBuffer);
                return Image.FromStream(imageStream);
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!sortingNow)
            {
                snapList[e.ItemIndex].sel = e.IsSelected;

                if (e.IsSelected)
                {
                    Image snapImage = previewSnap(snapList[e.ItemIndex].filePath);
                    //splitContainer1.Panel2.BackgroundImage = snapImage;
                    pictureBox1.Image = snapImage;
                    //jsonDetails.Text = snapList[e.ItemIndex].rawJSON.Replace(",", "\r\n");
                    metadataLabel.Text = JSONtoString(snapList[e.ItemIndex].deserializedJSON);
                }
                else
                {
                    //splitContainer1.Panel2.BackgroundImage.Dispose();
                    //splitContainer1.Panel2.BackgroundImage = null;
                    if (pictureBox1.Image != null) //failsafe
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }
                    metadataLabel.Text = "";
                }
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            sortingNow = true;
            listView1.BeginUpdate();
            //listView1.SelectedIndices.Clear();

            switch (e.Column)
            {
                case 0:
                    if (isTitleSorted) { snapList.Reverse(); }
                    else
                    {
                        snapList.Sort((x, y) => x.title.CompareTo(y.title));
                        isTitleSorted = true;
                        isFileSorted = isDateSorted = false;
                    }

                    break;
                case 1:
                    if (isFileSorted) { snapList.Reverse(); }
                    else
                    {
                        snapList.Sort((x, y) => x.fileName.CompareTo(y.fileName));
                        isFileSorted = true;
                        isTitleSorted = isDateSorted = false;
                    }
                    break;
                case 2:
                    if (isDateSorted) { snapList.Reverse(); }
                    else
                    {
                        snapList.Sort((x, y) => x.date.CompareTo(y.date));
                        isDateSorted = true;
                        isTitleSorted = isFileSorted = false;
                    }
                    break;
            }

            buildListView(snapList);
            listView1.EndUpdate();
            sortingNow = false;
        }

        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            snapList[e.Item].title = e.Label;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            snapList[e.Item.Index].chekd = e.Item.Checked;
        }

        private void checkSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.BeginUpdate();
            foreach (ListViewItem selectedItem in listView1.SelectedItems)
            {
                selectedItem.Checked = true;
            }
            listView1.EndUpdate();
        }


        private void saveSnaps(List<Snap> toSaveList, string saveLocation)
        {
            foreach (var snapItem in toSaveList)
            {
                string outputPath = saveLocation;
                if (saveLocation == null) { outputPath = Path.GetDirectoryName(snapItem.filePath); }

                string outputfileName = snapItem.fileName;
                if (titleAsFilenameMenuItem.Checked)
                {
                    outputfileName = snapItem.title;

                    if (datetimeFilenamesMenuItem.Checked)
                    {
                        /*int n = 1;
                        while (File.Exists(output))
                        {
                            output = string.Format("{0}\\{1} ({2}){3}", outputPath, outputfileName, n++, outputExtension);
                        }*/

                        outputfileName += snapItem.date.ToString(" yyyy-MM-dd HH-mm-ss");
                    }
                }

                string outputExtension = "";
                switch (snapItem.imageFormat)
                {
                    case "JPEG":
                        outputExtension = ".jpg";
                        break;
                    default:
                        outputExtension = ".image";
                        break;
                }

                string output = outputPath + "\\" + outputfileName + outputExtension;

                if (!File.Exists(output))
                {
                    using (BinaryReader reader = new BinaryReader(File.OpenRead(snapItem.filePath)))
                    {
                        reader.BaseStream.Position = 288;
                        int imageSize = reader.ReadInt32();
                        byte[] imageBuffer = reader.ReadBytes(imageSize);

                        using (BinaryWriter writer = new BinaryWriter(File.Create(output)))
                        {
                            writer.Write(imageBuffer);
                        }
                    }
                }

                if (metadataOverlayMenuItem.Checked)
                {
                    string outputMeta = outputPath + "\\" + outputfileName + ".log";

                    if (!File.Exists(outputMeta))
                    {
                        using (StreamWriter sw = new StreamWriter(outputMeta))
                        {
                            using (TextWriter ssw = TextWriter.Synchronized(sw))
                            {
                                ssw.Write(JSONtoString(snapItem.deserializedJSON));
                                ssw.WriteLine("\r\n### RAW JSON data ###");
                                ssw.Write(snapItem.rawJSON);
                            }
                        }
                    }
                }
            }

            StatusStripUpdate(string.Format("Finished exporting {0} {1}", toSaveList.Count, toSaveList.Count == 1 ? "picture" : "pictures"));
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (snapList.Count > 0) { saveSnaps(snapList, null); }
            else { StatusStripUpdate("No items available"); }
        }

        private void saveAllToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (snapList.Count > 0)
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                folderBrowserDialog1.Description = "Select destination";
                folderBrowserDialog1.ShowNewFolderButton = true;
                folderBrowserDialog1.SelectedPath = getProfilePath();

                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    saveSnaps(snapList, folderBrowserDialog1.SelectedPath);
                }
            }
            else { StatusStripUpdate("No items available"); }
        }

        private void saveSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var checkedIndices = listView1.CheckedIndices.Cast<int>().ToArray();
            var checkedSnaps = snapList.Where((s, index) => checkedIndices.Contains(index)).ToList();

            if (checkedSnaps.Count > 0) { saveSnaps(checkedSnaps, null); }
            else { StatusStripUpdate("No items selected"); }
        }

        private void saveSelectedToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var checkedIndices = listView1.CheckedIndices.Cast<int>().ToArray();
            var checkedSnaps = snapList.Where((s, index) => checkedIndices.Contains(index)).ToList();

            if (checkedSnaps.Count > 0)
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                folderBrowserDialog1.Description = "Select destination";
                folderBrowserDialog1.ShowNewFolderButton = true;
                folderBrowserDialog1.SelectedPath = getProfilePath();

                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    saveSnaps(checkedSnaps, folderBrowserDialog1.SelectedPath);
                }
            }
            else { StatusStripUpdate("No items selected"); }
        }


        private string JSONtoString(snapJSON dsJS)
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("Location: (x:{0}, y:{1}, z:{2})\r\n", dsJS.loc.x, dsJS.loc.y, dsJS.loc.z);
            result.AppendFormat("Area: {0}\r\n", dsJS.area);
            result.AppendFormat("Street: {0}\r\n", dsJS.street);
            result.AppendFormat("nm: {0}\r\n", dsJS.nm);
            result.AppendFormat("rds: {0}\r\n", dsJS.rds);
            result.AppendFormat("scr: {0}\r\n", dsJS.scr);
            result.AppendFormat("sid: {0}\r\n", dsJS.sid);
            result.AppendFormat("Crew ID: {0}\r\n", dsJS.crewid);
            result.AppendFormat("mid: {0}\r\n", dsJS.mid);
            result.AppendFormat("Game mode: {0}\r\n", (dsJS.mode == "SP" ? "Single player" : "Online"));
            result.AppendFormat("Meme: {0}\r\n", (dsJS.meme ? "Yes" : "No"));
            result.AppendFormat("Mug shot: {0}\r\n", (dsJS.mug ? "Yes" : "No"));
            result.AppendFormat("uid: {0}\r\n", dsJS.uid);
            DateTime gameTime = new DateTime(dsJS.time.year, dsJS.time.month, dsJS.time.day, dsJS.time.hour, dsJS.time.minute, dsJS.time.second);
            result.AppendFormat("Game time: {0}\r\n", gameTime);
            DateTime creatTime = UnixTimeStampToDateTime(dsJS.creat);
            result.AppendFormat("Created time: {0}\r\n", creatTime);
            result.AppendFormat("Selfie: {0}\r\n", (dsJS.slf ? "Yes" : "No"));
            result.AppendFormat("Director mode: {0}\r\n", (dsJS.drctr ? "Yes" : "No"));

            return result.ToString();
        }

        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        private string getProfilePath()
        {
            string profilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Rockstar Games\\GTA V\\Profiles";
            if (Directory.Exists(profilePath))
            {
                var profiles = Directory.GetDirectories(profilePath);
                if (profiles.Length > 0) { profilePath = profiles[0]; }

                return profilePath;
            }
            else { return ""; }

        }

        private string ReadStringToNull(BinaryReader stream)
        {
            string result = "";
            char c;
            for (int i = 0; i < stream.BaseStream.Length; i++)
            {
                if ((c = (char)stream.ReadByte()) == 0)
                {
                    break;
                }
                result += c.ToString();
            }
            return result;
        }

        /*private void getScaledSize()
        {
            int boxWidth = pictureBox1.ClientSize.Width;
            int boxHeight = pictureBox1.ClientSize.Width;
            int imageWidth = pictureBox1.Image.Width;
            int imageHeight = pictureBox1.Image.Width;
            int scaledWidth = imageWidth;
            int scaledHeight = imageHeight;

            int imageAR = imageWidth / imageHeight;
            int boxAR = boxWidth / boxHeight;

            if (boxAR < imageAR)
            {
                scaledWidth = boxWidth;
                scaledHeight = imageHeight * (boxWidth / imageWidth);
            }
            else
            {
                scaledWidth = imageWidth * (boxHeight / imageHeight);
                scaledHeight = boxHeight;
            }
        }*/


        /*private void pictureBox1_Resize(object sender, EventArgs e)
        {
            if (fitImageMenuItem.Checked)
            {
                float boxWidth = (float)pictureBox1.ClientSize.Width;
                float boxHeight = (float)pictureBox1.ClientSize.Height;
                float imageWidth = (float)pictureBox1.Image.Width;
                float imageHeight = (float)pictureBox1.Image.Height;
                float scaledWidth = imageWidth;
                float scaledHeight = imageHeight;

                float imageAR = imageWidth / imageHeight;
                float boxAR = boxWidth / boxHeight;

                if (boxAR < imageAR)
                {
                    scaledWidth = boxWidth;
                    scaledHeight = imageHeight * (boxWidth / imageWidth);

                    if ((boxHeight - scaledHeight) > metadataLabel.Height * 1.5) { metadataLabel.ForeColor = Color.Black; }
                    else { metadataLabel.ForeColor = Color.LimeGreen; }
                }
                else
                {
                    scaledWidth = imageWidth * (boxHeight / imageHeight);
                    scaledHeight = boxHeight;

                    if ((boxWidth - scaledWidth) > metadataLabel.Width * 1.5) { metadataLabel.ForeColor = Color.Black; }
                    else { metadataLabel.ForeColor = Color.LimeGreen; }
                }
            }
        }*/

        private void resizeTitleColumn()
        {
            //bool vscroll = (snapList.Count * 17 + 28) > listView1.Height;
            //titleHeader.Width = listView1.Width - fileHeader.Width -dateHeader.Width - (vscroll ? 21 : 4);
            var newWidth = listView1.ClientSize.Width - fileHeader.Width - dateHeader.Width;
            titleHeader.Width = newWidth > 0 ? newWidth : 32;
        }

        private void listView1_Layout(object sender, LayoutEventArgs e)
        {
            resizeTitleColumn();
        }

        private void listView1_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            if (e.ColumnIndex != 0) { resizeTitleColumn(); }
            //stupid loop
        }

        /*private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = this.listView1.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }*/


        private void closeSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var checkedIndices = listView1.CheckedIndices.Cast<int>().ToArray();
            //var checkedSnaps = snapList.Where((s, index) => checkedIndices.Contains(index)).ToList();

            for (int i = checkedIndices.Length; i > 0; i--)
            {
                int ind = checkedIndices[i - 1];
                listView1.Items.RemoveAt(ind);
                snapList.RemoveAt(ind);
            }
            
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearItems();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void clearItems()
        {
            snapList.Clear();
            listView1.Items.Clear(); //not needed

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }

            metadataLabel.Text = "";
        }

        private void titleAsFilenameMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            //if (titleAsFilenameMenuItem.Checked) { datetimeFilenamesMenuItem.Visible = true; }
            //else { datetimeFilenamesMenuItem.Visible = false; }

            datetimeFilenamesMenuItem.Visible = titleAsFilenameMenuItem.Checked;
            Properties.Settings.Default["titleAsFilename"] = titleAsFilenameMenuItem.Checked;
        }

        private void datetimeFilenamesMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["datetimeFilename"] = datetimeFilenamesMenuItem.Checked;
        }

        private void metadataExportMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["metadataExport"] = metadataExportMenuItem.Checked;
        }

        private void metadataOverlayMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            metadataLabel.Visible = metadataOverlayMenuItem.Checked;
            Properties.Settings.Default["metadataOverlay"] = metadataOverlayMenuItem.Checked;
        }

        private void fitImageMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = fitImageMenuItem.Checked ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.Normal;
            Properties.Settings.Default["fitImage"] = fitImageMenuItem.Checked;

            /*if (fitImageMenuItem.Checked)
            {
                //splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                //splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            }*/
        }

        private void resizeWindowToFitImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (this.WindowState == FormWindowState.Maximized) { this.WindowState = FormWindowState.Normal; }
                this.Width = splitContainer1.SplitterDistance + pictureBox1.Image.Width + 22;
                this.Height = pictureBox1.Image.Height + menuStrip1.Height + 40;
            }
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = "Readme.txt";
            if (!System.IO.File.Exists(filename))
                System.IO.File.WriteAllText(filename, Properties.Resources.Readme);
            // let windows decide which program it will use to open the file ...
            // whatever registered application for .txt extension is on the user system
            System.Diagnostics.Process.Start(filename);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutWindow = new AboutBox();
            aboutWindow.Show();
        }

        private void StatusStripUpdate(string statusText)
        {
            toolStripStatusLabel1.Text = statusText;
            statusStrip1.Update();
        }

        /*private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default["titleAsFilename"] = titleAsFilenameMenuItem.Checked;
            Properties.Settings.Default["metadataExport"] = metadataExportMenuItem.Checked;
            Properties.Settings.Default["fitImage"] = fitImageMenuItem.Checked;
            Properties.Settings.Default["metadataOverlay"] = metadataOverlayMenuItem.Checked;
            Properties.Settings.Default["datetimeFilename"] = datetimeFilenamesMenuItem.Checked;
            Properties.Settings.Default.Save();
        }*/

    }
}
