using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace xytextreader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(tabMain_DragEnter);
            this.DragDrop += new DragEventHandler(tabMain_DragDrop);
            richTextBox1.AllowDrop = true;
            richTextBox1.DragEnter += new DragEventHandler(tabMain_DragEnter);
            richTextBox1.DragDrop += new DragEventHandler(tabMain_DragDrop);
        }
        private void parse(string path)
        {
            
            string newline = "\\n";
            string buttonnew = "\\r";
            if (CHK_Readable.Checked)
            {
                newline = buttonnew = " ";
            }
            byte[] data = File.ReadAllBytes(path);

            // handling bad input, poorly
            if (data.Length < 2) return;
            if (BitConverter.ToUInt16(data, 0) != 0x1) return;

            // start gathering
            int linect = BitConverter.ToUInt16(data, 0x2);
            // storage for lines
            string[] linestrings = new string[linect];

            for (int i = 0; i < linect; i++)
            {
                int offset = BitConverter.ToInt32(data, 0x14 + i * 8);
                int length = BitConverter.ToInt16(data, 0x18 + i * 8) * 2;
                byte[] linehex = new Byte[length];
                Array.Copy(data, offset + 0x10, linehex, 0, length);
                string line = "";
                ushort key = BitConverter.ToUInt16(linehex,length-2);
                ushort[] vals = new ushort[length / 2];

                // Unroll the key and gather our characters...
                for (int c = length; c > 0;)
                {
                    c -= 2; // at start...
                    ushort val = BitConverter.ToUInt16(linehex, c);
                    vals[c/2] = (ushort)(val ^ key);
                    key = (ushort)((key << 13) | (key >> 3));
                }
                // Roll forwards and parse our text to a line.
                for (int c = 0; c < length; c += 2)
                {
                    ushort newval = vals[c / 2];

                    if (newval == 0xA)
                        line += newline;
                    else if (newval == 0xD)
                        line += newline;
                    else if (newval == 0)
                        line += "\n"; // Null terminated lines.
                    else if (newval == 0xE07F)
                        line += (char)0x202F;
                    else if (newval == 0xE08D)
                        line += (char)0x2026;
                    else if (newval == 0xE08E)
                        line += (char)0x2642;
                    else if (newval == 0xE08F)
                        line += (char)0x2640;

                    //
                    else if (newval == 0x10)
                    {
                        // Begin Text Variable
                        c += 2;
                        ushort tvlen = vals[c / 2];
                        c += 2;
                        ushort tvcode = vals[c / 2];
                        c += 2;

                        string tv = "[VAR ";

                        switch (tvcode)
                        {
                            case 0xBE00: // "Waitbutton then scroll text;; \r"
                            case 0xBE01: // "Waitbutton then clear text;; \r"
                                { line += buttonnew; c -= 2; break; }
                            case 0xBE02: // Dramatic pause for a text line. New!
                                { line += "[Wait: " + vals[c / 2].ToString() + "]"; c += 2; break; }
                            case 0xBDFF: // Empty Text line? Includes linenum so maybe for betatest finding used-unused lines?
                                { line += "[-" + vals[c / 2].ToString() + "-]"; break; }
                            default:
                                {
                                    string tvname = tvcode.ToString("X4");
                                    switch (tvcode) // get variable's info name
                                    {
                                        case 0xFF00: tvname = "COLOR"; break; // Change text line color (0 = white, 1 = red, 2 = blue...)
                                        case 0x0100: tvname = "TRNAME"; break; // 
                                        case 0x0101: tvname = "PKNAME"; break;
                                        case 0x0102: tvname = "PKNICK"; break;
                                        case 0x0103: tvname = "TYPE"; break;
                                        case 0x0105: tvname = "LOCATION"; break;
                                        case 0x0106: tvname = "ABILITY"; break;
                                        case 0x0107: tvname = "MOVE"; break;
                                        case 0x0108: tvname = "ITEM1"; break;
                                        case 0x0109: tvname = "ITEM2"; break;
                                        case 0x010A: tvname = "sTRBAG"; break;
                                        case 0x010B: tvname = "BOX"; break;
                                        case 0x010D: tvname = "EVSTAT"; break;
                                        case 0x0110: tvname = "OPOWER"; break;
                                        case 0x0127: tvname = "RIBBON"; break;
                                        case 0x0134: tvname = "MIINAME"; break;
                                        case 0x013E: tvname = "WEATHER"; break;
                                        case 0x0189: tvname = "TRNICK"; break;
                                        case 0x018A: tvname = "1stchrTR"; break;
                                        case 0x018B: tvname = "SHOUTOUT"; break;
                                        case 0x018E: tvname = "BERRY"; break;
                                        case 0x018F: tvname = "REMFEEL"; break;
                                        case 0x0190: tvname = "REMQUAL"; break;
                                        case 0x0191: tvname = "WEBSITE"; break;
                                        case 0x019C: tvname = "CHOICECOS"; break;
                                        case 0x01A1: tvname = "GSYNCID"; break;
                                        case 0x0192: tvname = "PRVIDSAY"; break;
                                        case 0x0193: tvname = "BTLTEST"; break;
                                        case 0x0195: tvname = "GENLOC"; break;
                                        case 0x0199: tvname = "CHOICEFOOD"; break;
                                        case 0x019A: tvname = "HOTELITEM"; break;
                                        case 0x019B: tvname = "TAXISTOP"; break;
                                        case 0x019F: tvname = "MAISTITLE"; break;
                                        case 0x1000: tvname = "ITEMPLUR0"; break;
                                        case 0x1001: tvname = "ITEMPLUR1"; break;
                                        case 0x1100: tvname = "GENDBR"; break;
                                        case 0x1101: tvname = "NUMBRNCH"; break;
                                        case 0x1302: tvname = "iCOLOR2"; break;
                                        case 0x1303: tvname = "iCOLOR3"; break;
                                        case 0x0200: tvname = "NUM1"; break;
                                        case 0x0201: tvname = "NUM2"; break;
                                        case 0x0202: tvname = "NUM3"; break;
                                        case 0x0203: tvname = "NUM4"; break;
                                        case 0x0204: tvname = "NUM5"; break;
                                        case 0x0205: tvname = "NUM6"; break;
                                        case 0x0206: tvname = "NUM7"; break;
                                        case 0x0207: tvname = "NUM8"; break;
                                        case 0x0208: tvname = "NUM9"; break;
                                        //case 0xBDFF: tv = "["; tvname = ""; break; // now handled above 
                                        default: break;
                                    }
                                    tv += tvname;
                                    for (int z = 0; z < tvlen - 1; z++)
                                    {
                                        tv += "," + vals[c / 2].ToString();
                                        c += 2;
                                    }
                                    tv += "]";
                                    line += tv;
                                    c -= 2;
                                    break;
                                }
                        }
                    }

                    else
                    {
                        char letter = (char)newval;
                        line += letter;
                    }
                }
                // Store line result.
                linestrings[i] = line;
            }

            // Print
            richTextBox1.Clear();
            for (int i = 0; i < linect; i++)
            {
                richTextBox1.AppendText(linestrings[i]);
            }
            if (CHK_AutoSave.Checked)
            {
                FileInfo fi = new FileInfo(path);
                string newname = fi.DirectoryName + "\\" + Path.GetFileNameWithoutExtension(fi.Name) + ".txt";
                File.WriteAllText(newname, richTextBox1.Text, Encoding.UTF8);
            }
        }



        private void tabMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        private void tabMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string path = files[0]; // open first D&D
            TB_Path.Text = path;
            for (int i = 0; i < files.Length; i++)
            {
                parse(files[i]);
            }
        }
        private void B_TextDiff_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            string path1 = "C:\\Users\\Kurt\\Desktop\\Pokemon X 1.2 Update\\romfs\\a\\0\\7\\4_";
            string path2 = "C:\\Users\\Kurt\\Desktop\\Pokemon Y Decrypted\\romfs\\a\\0\\7\\4_";

            string[] files1 = Directory.GetFiles(path1, "*.*", SearchOption.AllDirectories);
            string[] files2 = Directory.GetFiles(path2, "*.*", SearchOption.AllDirectories);

            byte[] data1; byte[] data2;

            for (int i = 0; i < files1.Length; i++)
            {
                data1 = File.ReadAllBytes(files1[i]);
                data2 = File.ReadAllBytes(files2[i]);

                if (!data1.SequenceEqual(data2))
                {
                    FileInfo fi = new FileInfo(files1[i]);
                    richTextBox1.AppendText(fi.Name + " was changed!\n");
                }
            }
            
        }
        private void B_Parse_Click(object sender, EventArgs e)
        {
            parse(TB_Path.Text);
        }
        private void B_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);

                if (br.ReadUInt16() == 1)
                {
                    br.Close();
                    parse(path);
                }
                else { br.Close(); MessageBox.Show("Invalid Input"); }

            }
        }
    }
}
