
namespace eAutobus.WinUI
{
    partial class frmPocetna
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip = new MenuStrip();
            autobusiToolStripMenuItem = new ToolStripMenuItem();
            pretragaToolStripMenuItem = new ToolStripMenuItem();
            novoVoziloToolStripMenuItem = new ToolStripMenuItem();
            korisniciToolStripMenuItem = new ToolStripMenuItem();
            pregledKorisnikaToolStripMenuItem = new ToolStripMenuItem();
            noviKorsnikToolStripMenuItem = new ToolStripMenuItem();
            karteToolStripMenuItem = new ToolStripMenuItem();
            pregledKarataToolStripMenuItem = new ToolStripMenuItem();
            cjenovnikToolStripMenuItem = new ToolStripMenuItem();
            dodajNovuKartuToolStripMenuItem = new ToolStripMenuItem();
            izdajKartuToolStripMenuItem = new ToolStripMenuItem();
            zahtjeviZaKartuToolStripMenuItem = new ToolStripMenuItem();
            onlineKarteToolStripMenuItem = new ToolStripMenuItem();
            preuzećemKarteToolStripMenuItem = new ToolStripMenuItem();
            rasporedVoznjiToolStripMenuItem = new ToolStripMenuItem();
            pregledRasporedaToolStripMenuItem = new ToolStripMenuItem();
            dodajNovuLinijuToolStripMenuItem = new ToolStripMenuItem();
            recenzijeToolStripMenuItem = new ToolStripMenuItem();
            toolTip = new ToolTip(components);
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { autobusiToolStripMenuItem, korisniciToolStripMenuItem, karteToolStripMenuItem, rasporedVoznjiToolStripMenuItem, recenzijeToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(4, 2, 0, 2);
            menuStrip.Size = new Size(1234, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            // 
            // autobusiToolStripMenuItem
            // 
            autobusiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pretragaToolStripMenuItem, novoVoziloToolStripMenuItem });
            autobusiToolStripMenuItem.Name = "autobusiToolStripMenuItem";
            autobusiToolStripMenuItem.Size = new Size(67, 20);
            autobusiToolStripMenuItem.Text = "Autobusi";
            // 
            // pretragaToolStripMenuItem
            // 
            pretragaToolStripMenuItem.Name = "pretragaToolStripMenuItem";
            pretragaToolStripMenuItem.Size = new Size(137, 22);
            pretragaToolStripMenuItem.Text = "Pretraga";
            pretragaToolStripMenuItem.Click += pretragaToolStripMenuItem_Click;
            // 
            // novoVoziloToolStripMenuItem
            // 
            novoVoziloToolStripMenuItem.Name = "novoVoziloToolStripMenuItem";
            novoVoziloToolStripMenuItem.Size = new Size(137, 22);
            novoVoziloToolStripMenuItem.Text = "Novo vozilo";
            novoVoziloToolStripMenuItem.Click += novoVoziloToolStripMenuItem_Click;
            // 
            // korisniciToolStripMenuItem
            // 
            korisniciToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pregledKorisnikaToolStripMenuItem, noviKorsnikToolStripMenuItem });
            korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            korisniciToolStripMenuItem.Size = new Size(64, 20);
            korisniciToolStripMenuItem.Text = "Korisnici";
            // 
            // pregledKorisnikaToolStripMenuItem
            // 
            pregledKorisnikaToolStripMenuItem.Name = "pregledKorisnikaToolStripMenuItem";
            pregledKorisnikaToolStripMenuItem.Size = new Size(164, 22);
            pregledKorisnikaToolStripMenuItem.Text = "Pregled korisnika";
            pregledKorisnikaToolStripMenuItem.Click += pregledKorisnikaToolStripMenuItem_Click;
            // 
            // noviKorsnikToolStripMenuItem
            // 
            noviKorsnikToolStripMenuItem.Name = "noviKorsnikToolStripMenuItem";
            noviKorsnikToolStripMenuItem.Size = new Size(164, 22);
            noviKorsnikToolStripMenuItem.Text = "Novi korsnik";
            noviKorsnikToolStripMenuItem.Click += noviKorsnikToolStripMenuItem_Click;
            // 
            // karteToolStripMenuItem
            // 
            karteToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pregledKarataToolStripMenuItem, izdajKartuToolStripMenuItem, zahtjeviZaKartuToolStripMenuItem });
            karteToolStripMenuItem.Name = "karteToolStripMenuItem";
            karteToolStripMenuItem.Size = new Size(46, 20);
            karteToolStripMenuItem.Text = "Karte";
            // 
            // pregledKarataToolStripMenuItem
            // 
            pregledKarataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cjenovnikToolStripMenuItem, dodajNovuKartuToolStripMenuItem });
            pregledKarataToolStripMenuItem.Name = "pregledKarataToolStripMenuItem";
            pregledKarataToolStripMenuItem.Size = new Size(180, 22);
            pregledKarataToolStripMenuItem.Text = "Pregled karata";
            pregledKarataToolStripMenuItem.Click += pregledKarataToolStripMenuItem_Click;
            // 
            // cjenovnikToolStripMenuItem
            // 
            cjenovnikToolStripMenuItem.Name = "cjenovnikToolStripMenuItem";
            cjenovnikToolStripMenuItem.Size = new Size(165, 22);
            cjenovnikToolStripMenuItem.Text = "Cjenovnik";
            cjenovnikToolStripMenuItem.Click += cjenovnikToolStripMenuItem_Click;
            // 
            // dodajNovuKartuToolStripMenuItem
            // 
            dodajNovuKartuToolStripMenuItem.Name = "dodajNovuKartuToolStripMenuItem";
            dodajNovuKartuToolStripMenuItem.Size = new Size(165, 22);
            dodajNovuKartuToolStripMenuItem.Text = "Dodaj novu kartu";
            dodajNovuKartuToolStripMenuItem.Click += dodajNovuKartuToolStripMenuItem_Click;
            // 
            // izdajKartuToolStripMenuItem
            // 
            izdajKartuToolStripMenuItem.Name = "izdajKartuToolStripMenuItem";
            izdajKartuToolStripMenuItem.Size = new Size(180, 22);
            izdajKartuToolStripMenuItem.Text = "Izdaj kartu";
            izdajKartuToolStripMenuItem.Click += izdajKartuToolStripMenuItem_Click;
            // 
            // zahtjeviZaKartuToolStripMenuItem
            // 
            zahtjeviZaKartuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { onlineKarteToolStripMenuItem, preuzećemKarteToolStripMenuItem });
            zahtjeviZaKartuToolStripMenuItem.Name = "zahtjeviZaKartuToolStripMenuItem";
            zahtjeviZaKartuToolStripMenuItem.Size = new Size(180, 22);
            zahtjeviZaKartuToolStripMenuItem.Text = "Zahtjevi za kartu";
            zahtjeviZaKartuToolStripMenuItem.Click += zahtjeviZaKartuToolStripMenuItem_Click;
            // 
            // onlineKarteToolStripMenuItem
            // 
            onlineKarteToolStripMenuItem.Name = "onlineKarteToolStripMenuItem";
            onlineKarteToolStripMenuItem.Size = new Size(180, 22);
            onlineKarteToolStripMenuItem.Text = "Plaćene karte";
            onlineKarteToolStripMenuItem.Click += onlineKarteToolStripMenuItem_Click;
            // 
            // preuzećemKarteToolStripMenuItem
            // 
            preuzećemKarteToolStripMenuItem.Name = "preuzećemKarteToolStripMenuItem";
            preuzećemKarteToolStripMenuItem.Size = new Size(180, 22);
            preuzećemKarteToolStripMenuItem.Text = "Preuzećem karte";
            preuzećemKarteToolStripMenuItem.Click += preuzećemKarteToolStripMenuItem_Click;
            // 
            // rasporedVoznjiToolStripMenuItem
            // 
            rasporedVoznjiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pregledRasporedaToolStripMenuItem, dodajNovuLinijuToolStripMenuItem });
            rasporedVoznjiToolStripMenuItem.Name = "rasporedVoznjiToolStripMenuItem";
            rasporedVoznjiToolStripMenuItem.Size = new Size(102, 20);
            rasporedVoznjiToolStripMenuItem.Text = "Raspored voznji";
            rasporedVoznjiToolStripMenuItem.Click += rasporedVoznjiToolStripMenuItem_Click;
            // 
            // pregledRasporedaToolStripMenuItem
            // 
            pregledRasporedaToolStripMenuItem.Name = "pregledRasporedaToolStripMenuItem";
            pregledRasporedaToolStripMenuItem.Size = new Size(172, 22);
            pregledRasporedaToolStripMenuItem.Text = "Pregled rasporeda ";
            pregledRasporedaToolStripMenuItem.Click += pregledRasporedaToolStripMenuItem_Click;
            // 
            // dodajNovuLinijuToolStripMenuItem
            // 
            dodajNovuLinijuToolStripMenuItem.Name = "dodajNovuLinijuToolStripMenuItem";
            dodajNovuLinijuToolStripMenuItem.Size = new Size(172, 22);
            dodajNovuLinijuToolStripMenuItem.Text = "Dodaj novu liniju";
            dodajNovuLinijuToolStripMenuItem.Click += dodajNovuLinijuToolStripMenuItem_Click;
            // 
            // recenzijeToolStripMenuItem
            // 
            recenzijeToolStripMenuItem.Name = "recenzijeToolStripMenuItem";
            recenzijeToolStripMenuItem.Size = new Size(68, 20);
            recenzijeToolStripMenuItem.Text = "Recenzije";
            recenzijeToolStripMenuItem.Click += recenzijeToolStripMenuItem_Click;
            // 
            // frmPocetna
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(1234, 680);
            Controls.Add(menuStrip);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(4);
            Name = "frmPocetna";
            Text = "frmPocetna";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion


        private MenuStrip menuStrip;
        private ToolTip toolTip;
        private ToolStripMenuItem autobusiToolStripMenuItem;
        private ToolStripMenuItem pretragaToolStripMenuItem;
        private ToolStripMenuItem novoVoziloToolStripMenuItem;
        private ToolStripMenuItem korisniciToolStripMenuItem;
        private ToolStripMenuItem pregledKorisnikaToolStripMenuItem;
        private ToolStripMenuItem noviKorsnikToolStripMenuItem;
        private ToolStripMenuItem karteToolStripMenuItem;
        private ToolStripMenuItem rasporedVoznjiToolStripMenuItem;
        private ToolStripMenuItem pregledKarataToolStripMenuItem;
        private ToolStripMenuItem pregledRasporedaToolStripMenuItem;
        private ToolStripMenuItem dodajNovuLinijuToolStripMenuItem;
        private ToolStripMenuItem cjenovnikToolStripMenuItem;
        private ToolStripMenuItem dodajNovuKartuToolStripMenuItem;
        private ToolStripMenuItem izdajKartuToolStripMenuItem;
        private ToolStripMenuItem recenzijeToolStripMenuItem;
        private ToolStripMenuItem zahtjeviZaKartuToolStripMenuItem;
        private ToolStripMenuItem onlineKarteToolStripMenuItem;
        private ToolStripMenuItem preuzećemKarteToolStripMenuItem;
    }
}



